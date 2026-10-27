using System;
using HospitalConsoleApp.Models;

namespace HospitalConsoleApp.Repositories;

public interface IPatientRepository
{
    int CountWaiting(int specializationId);

    void Add(Patient patient);

    List<Patient> GetAllWaiting();

    Patient? RemoveNext(int specializationId);
}
