using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace CMS.Common
{
    public class OperationResult
    {
        public bool IsSucceed { get; private set; }

        public IEnumerable<string> FailureResult { get; private set; }

        public Exception Exception { get; private set; }

        public string ExceptionMessage
        {
            get
            {
                if (Exception != null)
                    return Exception.Message;
                else if (FailureResult?.Count() > 0)
                    return string.Join(Environment.NewLine, FailureResult);
                else
                    return String.Empty;
            }
        }

        public static OperationResult Failure(params string[] failureResult)
        {
            var actionResult = new OperationResult();

            Failure(actionResult, failureResult);

            return actionResult;
        }

        public static OperationResult Failure(Exception exception)
        {
            var actionResult = new OperationResult();

            Failure(actionResult, exception);

            return actionResult;
        }

        public static OperationResult Succeed()
        {
            var result = new OperationResult();

            Succeed(result);

            return result;
        }

        protected static void Succeed(OperationResult result)
        {
            result.IsSucceed = true;
            result.FailureResult = new string[0];
        }

        protected static void Failure(OperationResult result, params string[] failureResult)
        {
            Contract.Requires(failureResult != null);
            Contract.Requires(failureResult.Any());

            result.IsSucceed = false;
            result.FailureResult = failureResult;
        }


        protected static void Failure(OperationResult result, Exception exception)
        {
            Contract.Requires(exception != null);
            result.IsSucceed = false;

            result.Exception = exception;

            var errorMessages = new List<string>();

            while (exception != null)
            {
                errorMessages.Add(exception.Message);
                exception = exception.InnerException;
            }

            result.FailureResult = errorMessages.ToArray();
        }
    }

    public class OperationResult<T> : OperationResult
    {
        public T Data { get; set; }

        public new static OperationResult<T> Failure(params string[] failureResult)
        {
            var result = new OperationResult<T>();
            Failure(result, failureResult);
            return result;
        }

        public new static OperationResult<T> Failure(Exception exception)
        {
            var result = new OperationResult<T>();
            Failure(result, exception);
            return result;
        }

        public static OperationResult<T> Succeed(T data)
        {
            var result = new OperationResult<T>() { Data = data };
            Succeed(result);
            return result;
        }
    }
}
