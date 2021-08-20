using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ShopBridge
{
  public class ExceptionHandlingMiddleware : IMiddleware
  {
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
      try
      {
        await next(context);
      }
      catch (Exception e)
      {
        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
        await context.Response.WriteAsync(e.Message);
      }
    }
  }
}
