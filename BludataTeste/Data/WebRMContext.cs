using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BludataTeste.Data
{
    public class WebRMContext : DbContext
    {
        public WebRMContext(DbContextOptions<WebRMContext> options)
            : base(options)
        {
        }

        public DbSet<Bludata.Models.Empresa> Empresa { get; set; }
        public DbSet<Bludata.Models.Fornecedor> Fornecedor { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var converter = new ValueConverter<long[], string>(
            v => string.Join(";", v),
            v => v.Split(";", StringSplitOptions.RemoveEmptyEntries).Select(val => long.Parse(val)).ToArray());
            modelBuilder.ForSqlServerUseIdentityColumns();

        }
    }
}

