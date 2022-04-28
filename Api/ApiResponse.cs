using RotmgNetworkingLib.Api.Models;
using System;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api
{
    public class ApiResponse<T> where T : IXMLElement, new()
    {
        public readonly string Response;

        public IXMLElement XML { get; private set; }
        public Exception Exception { get; private set; }
        public bool IsSuccess { get; private set; }
        public bool IsErrorResponse { get; private set; }
        public bool IsParseFailure { get; private set; }
        public bool IsPostFailure { get; private set; }

        public T CastResult => (T)XML;
        public string ErrorResponseMessage => ((ErrorElement)XML).ErrorMessage;

        internal ApiResponse(string response)
        {
            Response = response;

            IsPostFailure = false;
            Exception = null;
        }

        internal ApiResponse(Exception exception)
        {
            Exception = exception;

            IsPostFailure = true;
            Response = null;
        }


        internal void Parse()
        {
            if (Response is null)
            {
                Exception = new ArgumentNullException(nameof(Response));
                IsParseFailure = true;
                IsSuccess = false;
                return;
            }

            if (Response.StartsWith("<Error>"))
            {
                IsErrorResponse = true;
                IsSuccess = false;
                XML = new ErrorElement();
            }
            else
            {
                XML = new T();
                IsSuccess = true;
            }

            try
            {
                XML.Read(XElement.Parse(Response));
            }
            catch (Exception e)
            {
                Exception = e;
                IsParseFailure = true;
                IsSuccess = false;
            }
        }
    }
}
