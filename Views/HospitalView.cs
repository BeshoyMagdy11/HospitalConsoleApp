
using HospitalConsoleApp.Models;

namespace HospitalConsoleApp.Views;

public class HospitalView
{
    public void ShowMainMenu()
    {
        Console.WriteLine("\n=== Hospital Management System ===");
        Console.WriteLine("1. Add patient");
        Console.WriteLine("2. Display specializations with waiting patients");
        Console.WriteLine("3. Display patients in a specialization");
        Console.WriteLine("4. Call next patient");
        Console.WriteLine("0. Exit");
        Console.Write("Choose an option: ");
    }

    public string ReadInput()
    {
        return Console.ReadLine() ?? string.Empty;
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void ShowSpecializations(
        List<Specialization> specializations)
    {
        if (specializations.Count == 0)
        {
            Console.WriteLine("No specializations have waiting patients.");
            return;
        }

        foreach (var specialization in specializations)
        {
            Console.WriteLine(
                $"{specialization.Id}. {specialization.Name}");
        }
    }

    public void ShowPatients(List<Patient> patients)
    {
        if (patients.Count == 0)
        {
            Console.WriteLine("No waiting patients.");
            return;
        }

        foreach (var patient in patients)
        {
            Console.WriteLine(
                $"ID: {patient.Id} | " +
                $"Name: {patient.Name} | " +
                $"Status: {patient.Status}");
        }
    }
}
