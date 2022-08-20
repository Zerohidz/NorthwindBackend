using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public static class BusinessRules
    {
        public static IResult Run(params IResult[] logicResults)
        {
            foreach (var logicResult in logicResults)
                if (logicResult.Success == false)
                    return logicResult;

            return new SuccessResult();
        }
    }
}