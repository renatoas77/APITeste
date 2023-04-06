using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITeste.Controllers
{
    [Route("api/[controller]/{id}")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        [HttpGet(Name = "Teste")]
        public String Get(int id)
        {
            if(id == 0)
            {
                return "A id é igual a " + id;
            }
            else if(id == 1)
            {
                return "A id é igual a " + id;
            }
            else
            {
                return $"A id escolhida '{id}' é maior que 1!";
            }
        }
    }
}
