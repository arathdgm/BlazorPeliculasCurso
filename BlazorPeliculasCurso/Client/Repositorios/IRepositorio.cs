using BlazorPeliculasCurso.Shared.Entidades;

namespace BlazorPeliculasCurso.Client.Repositorios
{
    public interface IRepositorio
    {
        List<Pelicula> ObtenerPeliculas();
        Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar);
    }
}
