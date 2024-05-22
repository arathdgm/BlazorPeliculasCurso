using BlazorPeliculasCurso.Shared.Entidades;
using System.Text;
using System.Text.Json;

namespace BlazorPeliculasCurso.Client.Repositorios
{
    public class Repositorio : IRepositorio
    {
        private readonly HttpClient httpClient;

        public Repositorio(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar)
        {
            var enviarJSON = JsonSerializer.Serialize(enviar);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PostAsync(url, enviarContent);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }

        public List<Pelicula> ObtenerPeliculas()
        {

            return new List<Pelicula>()
        {
            new Pelicula{Titulo = "Spider-Man",Lanzamiento = new DateTime(2009, 11, 11), Poster = "https://cinembrollos.com/wp-content/uploads/2012/05/amazing_spiderman_ver10.jpg"},
            new Pelicula{Titulo = "Avengers Endgame",Lanzamiento = new DateTime(2024, 03, 21), Poster = "https://cdnb.artstation.com/p/assets/images/images/015/679/313/large/xero-art-avengershepsivarposter.jpg?1549226606"},
            new Pelicula{Titulo = "Daredevil",Lanzamiento = new DateTime(2008, 04, 02), Poster = "https://upload.wikimedia.org/wikipedia/en/0/04/Daredevil_poster.JPG"}
        };

        }
    }
}
