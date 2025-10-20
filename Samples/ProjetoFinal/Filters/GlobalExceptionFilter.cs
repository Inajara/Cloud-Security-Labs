using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ProjetoFinal.Filters;

public class GlobalExceptionFilter : IExceptionFilter
{
    private readonly ILogger<GlobalExceptionFilter> _logger;

    public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception, "Erro não tratado");

        var result = new ObjectResult(new
        {
            Sucesso = false,
            Mensagem = "Ocorreu um erro inesperado.",
            Detalhes = context.Exception.Message
        })
        {
            StatusCode = (int)HttpStatusCode.InternalServerError
        };

        context.Result = result;
        context.ExceptionHandled = true;
    }
}
