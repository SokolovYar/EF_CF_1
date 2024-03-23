using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WpfApp1
{
    internal class AppContext : DbContext
    {
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<Style> Styles { get; set; } = null!;
        public DbSet<Studio> Studios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=homework;Trusted_Connection=True;");
        }

    }


    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int StudioId { get; set; }
        public int StyleId { get; set; }
        public DateTime Release {  get; set; }
        public string Mode { get; set; } = null!;
        public int Copies { get; set; }

        public virtual Style? Style { get; set; }
        public virtual Studio? Studio { get; set; }

    }

    public class Style
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Game> Games { get; set; }
    }

    public class Studio
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ? Descriprion { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }

}
