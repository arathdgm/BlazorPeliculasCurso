using BlazorPeliculasCurso.Shared.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BlazorPeliculasCurso.Server
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //configuracion de llave primaria compuesta manual
            modelBuilder.Entity<GeneroPelicula>().HasKey(e => new {e.GeneroId, e.PeliculaId });
            modelBuilder.Entity<PeliculaActor>().HasKey(e => new {e.ActorId, e.PeliculaId });
        }

        public DbSet<Genero> Generos => Set<Genero>();
        public DbSet<Actor> Actores => Set<Actor>();
        public DbSet<Pelicula> Peliculas => Set<Pelicula>();
        public DbSet<GeneroPelicula> GenerosPeliculas => Set<GeneroPelicula>();
        public DbSet<PeliculaActor> PeliculasActores => Set<PeliculaActor>();
    }
}
