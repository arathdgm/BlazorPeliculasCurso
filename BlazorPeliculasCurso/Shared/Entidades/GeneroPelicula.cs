﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPeliculasCurso.Shared.Entidades
{
    public class GeneroPelicula
    {
        public int PeliculaId { get; set; }
        public int GeneroId { get; set; }
        public Genero? Genero { get; set; }
        public Pelicula? Pelicula { get; set; }
    }
}
