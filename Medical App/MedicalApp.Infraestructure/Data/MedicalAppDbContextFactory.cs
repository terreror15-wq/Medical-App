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
            optionsBuilder.UseNpgsql("Host=aws-0-ca-central-1.pooler.supabase.com;Database=postgres;Username=postgres.wjkgfclsvfuzhbzzyips;Password=Medical.com0011;SSL Mode=Require;Trust Server Certificate=true");

            return new MedicalAppDbContext(optionsBuilder.Options);
        }
    }
}