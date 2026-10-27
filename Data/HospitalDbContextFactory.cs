
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HospitalConsoleApp.Data;

public class HospitalDbContextFactory
    : IDesignTimeDbContextFactory<HospitalDbContext>
{
    public HospitalDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder =
            new DbContextOptionsBuilder<HospitalDbContext>();

        optionsBuilder.UseSqlite("Data Source=hospital.db");

        return new HospitalDbContext(optionsBuilder.Options);
    }
}
