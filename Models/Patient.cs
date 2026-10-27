using System;

namespace HospitalConsoleApp.Models;

public class Patient
{
public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int SpecializationId { get; set; }

    public PatientStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }
}
