using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AnimalShelter.Models
{
    public class AnimalShelterContext : DbContext
    {
        public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options)
            : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
          builder.Entity<Animal>()
              .HasData(
                  new Animal { AnimalId = 2, Name = "Daisy", Species = "Dog", Age = 1},
                  new Animal { AnimalId = 3, Name = "Spot", Species = "Cat", Age = 2},
                  new Animal { AnimalId = 4, Name = "Max", Species = "Dog", Age = 3},
                  new Animal { AnimalId = 5, Name = "Pepper", Species = "Dog", Age = 4},
                  new Animal { AnimalId = 6, Name = "Penelope", Species = "Cat", Age = 15}
              );
        }
    }
}