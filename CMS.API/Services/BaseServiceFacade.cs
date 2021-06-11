using CMS.API.Resources;
using CMS.Common;
using NLog;
using System;

namespace CMS.API.Services
{
    public static class Extensions
    {
        private static ILogger _logger;
        public static OperationResult<T> HandleResponse<T>(this OperationResult<T> OperationResult)
        {
            if (OperationResult == null) return null;

            _logger = _logger ?? LogManager.GetCurrentClassLogger();
            if (OperationResult.IsSucceed) return OperationResult;
            OperationResult.Exception?.HandleException();
            _logger.Error("HandleResponse<T>.ExceptionMessage:", OperationResult.ExceptionMessage);
            return OperationResult;
        }

        public static void HandleException(this Exception exception)
        {
            if (exception == null) return;
            if (_logger == null) return;

            _logger.Info(exception);
            var level = 0;
            while (exception != null)
            {
                _logger.Error(exception, "BSF.Exception[" + level++ + "]" + exception.Message);
                exception = exception.InnerException;
            }
        }
        public static OperationResult HandleResponse(this OperationResult OperationResult)
        {
            if (OperationResult == null) return null;
            if (OperationResult.IsSucceed) return OperationResult;
            OperationResult.Exception?.HandleException();
            _logger.Error("HandleResponse.ExceptionMessage:", OperationResult.ExceptionMessage);
            return OperationResult;
        }
    }
    public class BaseServiceFacade
    {
        protected ILogger Logger { get; }

        protected BaseServiceFacade()
        {
            Logger = LogManager.GetCurrentClassLogger();
        }

        protected OperationResult<T> Succeed<T>(T data)
        {
            return OperationResult<T>.Succeed(data);
        }

        protected OperationResult Succeed()
        {
            return OperationResult.Succeed();
        }

        protected OperationResult<T> Failure<T>(Exception e)
        {
            e.HandleException();

            if (e is ApplicationException)
            {
                return OperationResult<T>.Failure(e);
            }
            return OperationResult<T>.Failure(Messages.ErrorOccured);
        }

        protected OperationResult<T> Failure<T>(string errorMessage)
        {
            return OperationResult<T>.Failure(errorMessage);
        }

        protected OperationResult Failure(Exception e)
        {
            e.HandleException();
            if (e is ApplicationException)
            {
                return OperationResult.Failure(e);
            }

            return OperationResult.Failure(Messages.ErrorOccured);
        }
    }
}