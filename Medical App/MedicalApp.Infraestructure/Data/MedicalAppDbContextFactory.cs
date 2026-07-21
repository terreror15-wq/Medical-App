using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace MedicalApp.Infraestructure.Data
{
    public class MedicalAppDbContextFactory : IDesignTimeDbContextFactory<MedicalAppDbContext>
    {
        public MedicalAppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MedicalAppDbContext>();
            optionsBuilder.UseNpgsql("YOUR PASSWORD");

            return new MedicalAppDbContext(optionsBuilder.Options);
        }
    }
}
