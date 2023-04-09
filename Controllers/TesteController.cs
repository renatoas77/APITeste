using APITeste.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITeste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TesteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost(Name = "CreateCategoria")]
        public ActionResult Post(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return Created("Criado com sucesso!", categoria);
        }

        [HttpGet("{id:int}")]
        public ActionResult Get(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);

            if(categoria != null)
            {
                return Ok(categoria);
            }

            return NotFound();
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if(id != categoria.CategoriaId)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok("Atualizado com sucesso!");
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);

            if(categoria is null)
            {
                return NotFound("Categoria não existe");
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return Ok("Categoria deleteda com sucesso!");
        }
    }
}
