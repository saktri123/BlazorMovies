using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorMovies.Shared.Entities
{
   public class Movie
    {
        public int MovieId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Summary { get; set; }
        public bool InTheaters { get; set; }
        public string Trailer { get; set; }
        [Required]
        public DateTime? ReleaseDate { get; set; }
        public string PosterImage { get; set; }
        public string NameBrief {
            get {
                return !String.IsNullOrEmpty(Name) && Name.Length>60 ? Name.Substring(0, 60) + "..." : Name;
            }
        }
    }
}
