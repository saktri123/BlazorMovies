﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMovies.Shared.Entities
{
   public class MovieGener
    {
        public int MovieId { get; set; }
        public int GenerId { get; set; }
        public Movie Movie { get; set; }
        public Gener Gener { get; set; }

    }
}
