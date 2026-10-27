
using HospitalConsoleApp.Models;
using HospitalConsoleApp.Services;
using HospitalConsoleApp.Views;

namespace HospitalConsoleApp.Controllers;

public class HospitalController
{
    private readonly IHospitalService _hospitalService;
    private readonly HospitalView _view;

    public HospitalController(
        IHospitalService hospitalService,
        HospitalView view)
    {
        _hospitalService = hospitalService;
        _view = view;
    }

    public void Run()
    {
        while (true)
        {
            _view.ShowMainMenu();

            string choice = _view.ReadInput();

            switch (choice)
            {
                case "1":
                    AddPatient();
                    break;

                case "2":
                    ShowSpecializations();
                    break;

                case "3":
                    ShowPatients();
                    break;

                case "4":
                    CallNextPatient();
                    break;

                case "0":
                    _view.ShowMessage("Goodbye!");
                    return;

                default:
                    _view.ShowMessage("Invalid choice. Try again.");
                    break;
            }
        }
    }

    private void AddPatient()
    {
        _view.ShowMessage("Enter patient name:");
        string name = _view.ReadInput();

        _view.ShowMessage("Enter specialization ID (1-20):");

        if (!int.TryParse(_view.ReadInput(), out int specializationId))
        {
            _view.ShowMessage("Invalid specialization ID.");
            return;
        }

        _view.ShowMessage("Enter status (0 = Regular, 1 = Urgent):");

        if (!int.TryParse(_view.ReadInput(), out int statusValue) ||
            !Enum.IsDefined(typeof(PatientStatus), statusValue))
        {
            _view.ShowMessage("Invalid patient status.");
            return;
        }

        bool success = _hospitalService.AddPatient(
            name,
            specializationId,
            (PatientStatus)statusValue,
            out string message);

        _view.ShowMessage(message);
    }

    private void ShowSpecializations()
    {
        var specializations =
            _hospitalService.GetSpecializationsWithWaitingPatients();

        _view.ShowSpecializations(specializations);
    }

    private void ShowPatients()
    {
        _view.ShowMessage("Enter specialization ID:");

        if (!int.TryParse(_view.ReadInput(), out int specializationId))
        {
            _view.ShowMessage("Invalid specialization ID.");
            return;
        }

        var patients =
            _hospitalService.GetWaitingPatients(specializationId);

        _view.ShowPatients(patients);
    }

    private void CallNextPatient()
    {
        _view.ShowMessage("Enter specialization ID:");

        if (!int.TryParse(_view.ReadInput(), out int specializationId))
        {
            _view.ShowMessage("Invalid specialization ID.");
            return;
        }

        var patient = _hospitalService.CallNextPatient(
            specializationId,
            out string message);

        _view.ShowMessage(message);
    }
}
