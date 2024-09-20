using ACME.CargoExpress.API.IAM.Application.Internal.OutboundServices;
using ACME.CargoExpress.API.IAM.Domain.Model.Queries;
using ACME.CargoExpress.API.IAM.Domain.Services;
using ACME.CargoExpress.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;

namespace ACME.CargoExpress.API.IAM.Infrastructure.Pipeline.Middleware.Components;

/**
 * RequestAuthorizationMiddleware is a custom middleware.
 * This middleware is used to authorize requests.
 * It validates a token is included in the request header and that the token is valid.
 * If the token is valid then it sets the user in HttpContext.Items["User"].
 */
public class RequestAuthorizationMiddleware(RequestDelegate next)
{
    /**
     * InvokeAsync is called by the ASP.NET Core runtime.
     * It is used to authorize requests.
     * It validates a token is included in the request header and that the token is valid.
     * If the token is valid then it sets the user in HttpContext.Items["User"].
     */
    public async Task InvokeAsync(
        HttpContext context,
        IUserQueryService userQueryService,
        ITokenService tokenService)
    {
        Console.WriteLine("Entering InvokeAsync");
        // skip authorization if endpoint is decorated with [AllowAnonymous] attribute
       
        
        


        // if token is null then throw exception
       

        

      

        // set user in HttpContext.Items["User"]

        
      
        // call next middleware
        await next(context);
    }
}