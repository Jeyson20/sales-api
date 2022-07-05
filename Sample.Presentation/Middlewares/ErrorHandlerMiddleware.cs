using Microsoft.AspNetCore.Http;
using Sample.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sample.Presentation.Middlewares
{
    // Modifica las respuestas por defecto que el httpcontext arroja al ocurrir un error

    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _neext;

        public ErrorHandlerMiddleware(RequestDelegate neext)
        {
            _neext = neext;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _neext(context);
            }
            catch (Exception error)
            {
                // Cuando ocurra un error se intercepta la respuesta 

                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>() { Succeeded = false, Message=error?.Message };

                // Se modifica la respuesta 
                switch (error)
                {
                    case Application.Exceptions.ApiException:
                        //custom application error 
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case Application.Exceptions.VallidationExceptions e:
                        //custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = e.Errors;
                        break;

                    case KeyNotFoundException:
                        //not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    case Exception:
                        //not found error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                // Se imprime el resultado de la respuesta
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}
