using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client
{
    public class SingletonClass
    {
        public int Value { get; set; }
    }

    public class TransientClass
    {
        public int Value { get; set; }
    }
}
