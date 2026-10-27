
using HospitalConsoleApp.Controllers;
using HospitalConsoleApp.Data;
using HospitalConsoleApp.Repositories;
using HospitalConsoleApp.Services;
using HospitalConsoleApp.Views;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var options = new DbContextOptionsBuilder<HospitalDbContext>()
            .UseSqlite("Data Source=hospital.db")
            .Options;

        using var dbContext = new HospitalDbContext(options);
        DataSeeder.Seed(dbContext);

        var patientRepository =
            new SqlitePatientRepository(dbContext);

        var specializationRepository =
            new SqliteSpecializationRepository(dbContext);

        var hospitalService = new HospitalService(
            patientRepository,
            specializationRepository);

        var view = new HospitalView();

        var controller = new HospitalController(
            hospitalService,
            view);

        controller.Run();
    }
}
