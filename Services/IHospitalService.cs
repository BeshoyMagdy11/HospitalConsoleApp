
using HospitalConsoleApp.Models;

namespace HospitalConsoleApp.Services;

public interface IHospitalService
{
    bool AddPatient(string name,int specializationId,PatientStatus status,out string message);

    List<Specialization> GetSpecializationsWithWaitingPatients();

    List<Patient> GetWaitingPatients(int specializationId);

    Patient? CallNextPatient(int specializationId,out string message);
}
