using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProjetoFinal.Filters;

public class ModelValidationFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var erros = context.ModelState
                .Where(e => e.Value.Errors.Count > 0)
                .Select(e => new
                {
                    Campo = e.Key,
                    Erros = e.Value.Errors.Select(er => er.ErrorMessage)
                });

            context.Result = new BadRequestObjectResult(new
            {
                Sucesso = false,
                Mensagem = "Modelo inválido",
                Erros = erros
            });
        }
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}