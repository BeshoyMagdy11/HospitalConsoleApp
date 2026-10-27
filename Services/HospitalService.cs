using System;
using HospitalConsoleApp.Models;
using HospitalConsoleApp.Repositories;

namespace HospitalConsoleApp.Services;

public class HospitalService : IHospitalService
{
    private readonly IPatientRepository _patientRepository;
    private readonly ISpecializationRepository _specializationRepository;

    public HospitalService(IPatientRepository patientRepository, ISpecializationRepository specializationRepository)
    {
        _patientRepository = patientRepository;
        _specializationRepository = specializationRepository;

    }

    public bool AddPatient(string name, int specializationId, PatientStatus status, out string message)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            message = "Patient name cannot be empty.";
            return false;
        }
        Specialization? specialization = _specializationRepository.GetById(specializationId);
        if (specialization is null)
        {
            message = "Specialization not found.";
            return false;
        }
        if (_patientRepository.CountWaiting(specializationId)
            >= specialization.Capacity)
        {
            message = "This specialization is full.";
            return false;
        }
        if (!Enum.IsDefined(typeof(PatientStatus), status))
        {
            message = "Invalid patient status.";
            return false;

        }
        Patient patient = new Patient
        {
            Name = name.Trim(),
            SpecializationId = specializationId,
            Status = status,
            CreatedAt = DateTime.UtcNow,
        };
        _patientRepository.Add(patient);
        message = "Patient added successfully.";
        return true;
    }

 public Patient? CallNextPatient(
        int specializationId,
        out string message)
    {
        var specialization =
            _specializationRepository.GetById(specializationId);

        if (specialization is null)
        {
            message = "Invalid specialization ID.";
            return null;
        }

        var patient =
            _patientRepository.RemoveNext(specializationId);

        if (patient is null)
        {
            message = "No waiting patients in this specialization.";
            return null;
        }

        message = $"Next patient: {patient.Name}";
        return patient;
    }

    public List<Specialization> GetSpecializationsWithWaitingPatients()
    {
        var waitingPatients = _patientRepository.GetAllWaiting();

        var waitingSpecializationIds = waitingPatients
            .Select(patient => patient.SpecializationId)
            .Distinct()
            .ToHashSet();

        return _specializationRepository.GetAll()
            .Where(specialization =>
                waitingSpecializationIds.Contains(specialization.Id))
            .OrderBy(specialization => specialization.Id)
            .ToList();
    }
  public List<Patient> GetWaitingPatients(int specializationId)
    {
        var specialization =
            _specializationRepository.GetById(specializationId);

        if (specialization is null)
        {
            return new List<Patient>();
        }

        return _patientRepository.GetAllWaiting()
            .Where(patient =>
                patient.SpecializationId == specializationId)
            .OrderByDescending(patient => patient.Status)
            .ThenBy(patient => patient.Id)
            .ToList();
    }
}
