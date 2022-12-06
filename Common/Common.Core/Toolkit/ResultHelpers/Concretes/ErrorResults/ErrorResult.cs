namespace Common.Core.Tools.ResultHelpers.Concretes.ErrorResults
{
    public class ErrorResult : Result
    {
        public ErrorResult() : base(false)
        {
        }
        public ErrorResult(string message) : base(false, message)
        {
        }
    }
}
