using System;
using HospitalConsoleApp.Models;

namespace HospitalConsoleApp.Repositories;

public interface ISpecializationRepository
{
    Specialization? GetById(int id);

    List<Specialization> GetAll();

}
