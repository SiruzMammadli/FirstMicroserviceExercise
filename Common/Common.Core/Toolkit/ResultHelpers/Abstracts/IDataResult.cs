namespace Common.Core.Tools.ResultHelpers.Abstracts
{
    public interface IDataResult<TResult> : IResult
    {
        TResult Data { get; }
    }
}
