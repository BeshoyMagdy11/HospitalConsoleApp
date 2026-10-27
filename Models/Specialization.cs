using System;

namespace HospitalConsoleApp.Models;

public class Specialization
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Capacity { get; set; } = 5;
}
