using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace ProjetoFinal.Filters;

public class RequestResponseLoggingFilter : IActionFilter
{
    private readonly ILogger<RequestResponseLoggingFilter> _logger;

    public RequestResponseLoggingFilter(ILogger<RequestResponseLoggingFilter> logger)
    {
        _logger = logger;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var request = context.HttpContext.Request;
        _logger.LogInformation($"➡️ Requisição: {request.Method} {request.Path}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        var response = context.HttpContext.Response;
        _logger.LogInformation($"⬅️ Resposta: {response.StatusCode}");
    }
}