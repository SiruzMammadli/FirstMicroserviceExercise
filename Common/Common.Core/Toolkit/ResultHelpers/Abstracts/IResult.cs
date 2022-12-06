namespace Common.Core.Tools.ResultHelpers.Abstracts
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
