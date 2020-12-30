using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorMovies.Shared.Entities
{
   public class Movie
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterImage { get; set; }
        public string NameBrief {
            get {
                return !String.IsNullOrEmpty(Name) && Name.Length>60 ? Name.Substring(0, 60) + "..." : Name;
            }
        }
    }
}
