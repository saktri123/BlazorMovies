using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMovies.Shared.Entities
{
   public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public DateTime? Dob { get; set; }
        public string Biography { get; set; }
        public string Picture { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Person P2) {
                return Id == P2.Id;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public List<MoviesActors> MoviesActors { get; set; }
        [NotMapped]
        public string Charachter { get; set; }
    }
}
