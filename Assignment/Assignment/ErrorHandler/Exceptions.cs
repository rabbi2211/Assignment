using System;
using System.Net;

namespace Assignment.ErrorHandlers
{
    public class BaseCustomException : Exception
    {
        private int _code;
        private string _description;

        public int Code
        {
            get { return _code; }
        }
        public string Description
        {
            get { return _description; }
        }

        public BaseCustomException(string message, string description, int code) : base(message)
        {
            _code = code;
            _description = description;
        }
    }

    public class CustomErrorResponse
    {
        public string Message { get; set; }
        public string Description { get; set; }
    }

    public class NotFoundCustomException : BaseCustomException
    {
        public NotFoundCustomException(string message, string description) : base(message, description, (int)HttpStatusCode.NotFound)
        {
        }
    }
}
