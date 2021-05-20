using ChallengeBlog_Corrales.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeBlog_Corrales.Data
{
    //Clase para crear el dbContext

    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //Propiedad para realizar la migracion a la db
        public DbSet<Post> Post { get; set; }
    }
}
