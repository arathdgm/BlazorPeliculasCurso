using BlazorPeliculasCurso.Shared.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace BlazorPeliculasCurso.Server.Controllers
{
    [Route ("api/genero")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        //realizamor la inyeccion de dependencias para traer una instancia del dbcontext
        //atraves de dbcontext tenemos acceso a la bd
        private readonly ApplicationDBContext context;

        public GenerosController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Genero genero)
        {
            context.Add(genero);
            await context.SaveChangesAsync();
            return genero.Id;
        }
    }
}
