using BlazorMovies.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Server
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Gener> Geners { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<MovieGener> MovieGeners { get; set; }
        public DbSet<MoviesActors> MoviesActors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoviesActors>().HasKey(x => new { x.MovieId, x.PersonId });
            modelBuilder.Entity<MovieGener>().HasKey(x => new { x.MovieId, x.GenerId });

            base.OnModelCreating(modelBuilder); 

        }

    }
}
