namespace Common.Core.Tools.ResultHelpers.Concretes.SuccessResults
{
    public class SuccessResult : Result
    {
        public SuccessResult() : base(true)
        {
        }
        public SuccessResult(string message) : base(true, message)
        {
        }
    }
}
