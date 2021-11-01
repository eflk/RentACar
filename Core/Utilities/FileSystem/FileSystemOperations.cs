using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileSystem
{
    public class FileSystemOperations
    {
        public static IResult WriteFile(string fullPath, byte[] content)
        {
            try
            {
                if (content.Length == 0) return new ErrorResult();
                string directory = Path.GetDirectoryName(fullPath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                    if (!Directory.Exists(directory))
                        return new ErrorResult();
                }

                File.WriteAllBytes(fullPath, content);
                if (!File.Exists(fullPath))
                    return new ErrorResult();
            }
            catch (Exception)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public static IDataResult<string> GetFileFromPath(string filePath)
        {
            if (!File.Exists(filePath))
                return new ErrorDataResult<string>();

            string fileContent = Convert.ToBase64String(File.ReadAllBytes(filePath));
            return new SuccessDataResult<string>(data: fileContent);
        }

        public static IResult RemoveFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                    return new ErrorDataResult<string>();

                File.Delete(filePath);
                return new SuccessResult();
            }
            catch (Exception)
            {
                return new ErrorResult();
            }
        }
    }
}
