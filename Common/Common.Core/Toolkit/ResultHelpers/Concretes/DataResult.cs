using Common.Core.Tools.ResultHelpers.Abstracts;

namespace Common.Core.Tools.ResultHelpers.Concretes
{
    public class DataResult<TResult> : Result, IDataResult<TResult>
    {
        public DataResult(TResult data, bool success) : base(success)
        {
            Data = data;
        }
        public DataResult(TResult data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
        public TResult Data { get; }
    }
}
