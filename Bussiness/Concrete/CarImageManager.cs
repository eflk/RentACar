using Bussiness.Abstract;
using Bussiness.Constants;
using Bussiness.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess;
using Core.Utilities.Business;
using Core.Utilities.FileSystem;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class CarImageManager : ManagerBase<CarImage>, ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal) : base(carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public override IResult Add(CarImage entity)
        {
            IResult businessRuleResult = BusinessRules.Run(CheckIfImageCountLimitExceeded(entity.CarId));
            if (!businessRuleResult.Success)
                return new ErrorResult(businessRuleResult.Message);

            var uploadResult = UploadImageFile(entity.ImageFile);
            if (!uploadResult.Success)
                return new ErrorResult(uploadResult.Message);

            entity.ImagePath = uploadResult.Message;
            entity.Date = DateTime.UtcNow;

            var addResult = base.Add(entity);
            if (!addResult.Success)
                FileSystemOperations.RemoveFile(entity.ImagePath);

            return addResult;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public override IResult Update(CarImage entity)
        {
            var uploadResult = UploadImageFile(entity.ImageFile);
            if (!uploadResult.Success)
                return new ErrorResult(uploadResult.Message);

            entity.ImagePath = uploadResult.Message;
            entity.Date = DateTime.UtcNow;

            return base.Update(entity);
        }

        
        public override IResult Delete(CarImage entity)
        {
            if (!Path.GetFileName(entity.ImagePath).ToString().Equals("default.png"))
                if (!FileSystemOperations.RemoveFile(entity.ImagePath).Success) return new ErrorResult();

            return base.Delete(entity);
        }

        private IResult CheckIfImageCountLimitExceeded(int carId)
        {
            if (_carImageDal.GetAll(c => c.CarId == carId).Count == 5)
                return new ErrorResult(Messages.MaximumImageCountError);
            return new SuccessResult();
        }
        private IResult UploadImageFile(FileDto imageFile)
        {
            string imageDirectory = System.IO.Directory.GetCurrentDirectory() + "\\uploads\\images\\";
            string fullPath = imageDirectory + "default.png";
            if (imageFile != null)
            {
                string fileName = Guid.NewGuid().ToString() + "." + imageFile.FileExtension;
                fullPath = imageDirectory + fileName;
                if (!FileSystemOperations.WriteFile(fullPath, Convert.FromBase64String(imageFile.FileContent)).Success)
                    return new ErrorResult(Messages.SystemError);
            }
            return new SuccessResult(fullPath);
        }
    }
}
