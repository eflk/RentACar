using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                    return new ErrorResult(logic.Message);
            }
            return new SuccessResult();
        }
        public static List<IResult> RunWithAllResults(params IResult[] logics)
        {
            List<IResult> errorResults = new List<IResult>();
            foreach (var logic in logics)
            {
                if (!logic.Success)
                    errorResults.Add(logic);
            }
            return errorResults;
        }

    }
}
