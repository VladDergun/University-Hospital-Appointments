/// <summary>
/// This import is used to import the files in HospitalClassLibrary.Interfaces folder
/// </summary>
using HospitalClassLibrary.Interfaces;

namespace HospitalClassLibrary
{

    public class Doctor : AppointmentAbstract, IControlDoctor
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string PhoneNumber { get; private set; }
        public List<Patient> Patients { get; private set; } = new List<Patient>();
        //public List<Appointment> Appointments { get; private set; } = new List<Appointment>();
        public string Title { get; private set; }

        public Doctor(string name, int age, string title, string phoneNumber)
        {
            Name = name;
            Age = age;
            Title = title;
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// doctor adds an appointment to the list of appointments
        /// sets the patient to the appointment
        /// </summary>
        public override void AddAppointment(Appointment appointment)
        {
            Patient patient = appointment.Patient;
            if (!Patients.Contains(patient))
                Patients.Add(patient);
            Appointments.Add(appointment);
            patient.AddAppointment(appointment);
        }
        /// <summary>
        /// doctor adds an entry to the medical record of a patient
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="entry"></param>
        public void AddMedicalRecordEntry(Patient patient, Entry entry)
        {
            patient.MedicalRecord.AddEntry(entry);
        }
        /// <summary>
        /// doctor adds a procedure to the list of procedures of a patient
        /// </summary>
        /// <param name="procedure"></param>

        public void AddProcedure(Procedure procedure) => procedure.ProcedurePatient.AddProcedure(procedure);

        /// <summary>
        /// doctor edits a procedure of a patient
        /// </summary>
        /// <param name="procedure"></param>
        /// <param name="newProcedure"></param>
        public void EditProcedure(Procedure procedure, Procedure newProcedure)
        {
            Patient patient = procedure.ProcedurePatient;
            
            newProcedure.Id = procedure.Id;
            patient.Procedures.Remove(procedure);
            if(string.IsNullOrEmpty(newProcedure.ProcedureType))
            {
                newProcedure.ProcedureType = procedure.ProcedureType;
            }
            if (string.IsNullOrEmpty(newProcedure.NameOfProcedure))
            {
                newProcedure.NameOfProcedure = procedure.NameOfProcedure;
            }
            if (newProcedure.ProcedureDate == DateTime.MinValue)
            {
                newProcedure.ProcedureDate = procedure.ProcedureDate;
            }
            newProcedure.ProcedurePatient = procedure.ProcedurePatient;
            patient.Procedures.Add(newProcedure);
        }

        /// <summary>
        /// doctor deletes a procedure of a patient
        /// </summary>
        /// <param name="procedure"></param>
        public void DeleteProcedure(Procedure procedure) => procedure.ProcedurePatient.DeleteProcedure(procedure);

        /// <summary>
        /// doctor adds a medicine to the list of medicines of a patient
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="medicine"></param>
        public void AddMedicine(Patient patient, Medicine medicine) => patient.AddMedicine(medicine);

        /// <summary>
        /// Method to edit medicine of a patient
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="medicine"></param>
        /// <param name="newMedicine"></param>
        public void EditMedicine(Patient patient, Medicine medicine, Medicine newMedicine)
        {
            patient.RemoveMedicine(medicine);
            patient.AddMedicine(newMedicine);
        }

        /// <summary>
        /// Doctor deletes a medicine of a patient
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="medicine"></param>
        public void DeleteMedicine(Patient patient, Medicine medicine) => patient.RemoveMedicine(medicine);

        /// <summary>
        /// doctor creates an entry for a patient
        /// </summary>
        /// <param name="diagnose"></param>
        /// <param name="prescription"></param>
        /// <returns>Entry</returns>
        public Entry CreateEntry(Diagnose diagnose, Prescription prescription)
        {
            return new Entry(diagnose, prescription);

        }
        


    }
}
