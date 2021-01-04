using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMovies.Shared.Entities
{
   public class Gener
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is rquired!")]
        public string Name { get; set; }
    }
}
