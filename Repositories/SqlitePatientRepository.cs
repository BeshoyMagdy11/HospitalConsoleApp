using System;
using HospitalConsoleApp.Data;
using HospitalConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalConsoleApp.Repositories;

public class SqlitePatientRepository : IPatientRepository
{
    private readonly HospitalDbContext _dbContext;

    public SqlitePatientRepository(HospitalDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Add(Patient patient)
    {
        _dbContext.Patients.Add(patient);
        _dbContext.SaveChanges();
    }

    public int CountWaiting(int specializationId)
    {
        return _dbContext.Patients.
        Count(x => x.SpecializationId == specializationId);


    }

    public List<Patient> GetAllWaiting()
    {
        return _dbContext.Patients.
        AsNoTracking().
        OrderBy(p => p.SpecializationId).
        ThenByDescending(p => p.Status).
        ThenBy(p => p.Id).
        ToList();
    }

    public Patient? RemoveNext(int specializationId)
    {
        Patient? nextPatient=_dbContext.
        Patients.
        Where(p=>p.SpecializationId==specializationId).
        OrderBy(p=>p.Status).
        ThenBy(p=>p.Id).
        FirstOrDefault();
        if(nextPatient is null) return null;
        _dbContext.Patients.Remove(nextPatient);
        _dbContext.SaveChanges();
        return nextPatient;
    }
}
