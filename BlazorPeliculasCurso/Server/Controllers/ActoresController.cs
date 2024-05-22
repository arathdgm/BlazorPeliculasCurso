using BlazorPeliculasCurso.Shared.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace BlazorPeliculasCurso.Server.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class ActoresController : ControllerBase
    {
        private readonly ApplicationDBContext context;

        public ActoresController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Actor actor)
        {
            context.Add(actor);
            await context.SaveChangesAsync();
            return actor.Id;
        }
    }
}
