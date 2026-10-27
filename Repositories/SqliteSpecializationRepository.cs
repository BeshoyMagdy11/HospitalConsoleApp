using System;
using HospitalConsoleApp.Data;
using HospitalConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalConsoleApp.Repositories;

public class SqliteSpecializationRepository : ISpecializationRepository
{
    private readonly HospitalDbContext  _hospitalDbContext;

    public SqliteSpecializationRepository(HospitalDbContext hospitalDbContext)
    {
        _hospitalDbContext = hospitalDbContext;
    }

    public List<Specialization> GetAll()
    {
    return _hospitalDbContext.
    Specializations.
    AsNoTracking().
    OrderBy(s=>s.Id).
    ToList();
    
    }

    public Specialization? GetById(int id)
    {
        Specialization? specialization=_hospitalDbContext.
        Specializations.
        AsNoTracking().
        FirstOrDefault(p=>p.Id==id);
        if(specialization is null) return null;
        return specialization;
        
    }
}
