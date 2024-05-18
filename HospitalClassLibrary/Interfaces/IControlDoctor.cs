namespace HospitalClassLibrary.Interfaces
{
    public interface IControlDoctor
    {
        /// <summary>
        /// Virtual method to add appointment
        /// </summary>
        /// <param name="appointment"></param>
        public void AddAppointment(Appointment appointment);
        /// <summary>
        /// Virtual method to add medicine to the list of medicines of a patient
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="medicine"></param>
        public void AddMedicine(Patient patient, Medicine medicine);
        /// <summary>
        /// Virtual method to edit medicine of a patient
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="medicine"></param>
        /// <param name="newMedicine"></param>
        public void EditMedicine(Patient patient, Medicine medicine, Medicine newMedicine);
        /// <summary>
        /// Virtual method to delete medicine of a patient
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="medicine"></param>
        public void DeleteMedicine (Patient patient, Medicine medicine);
        /// <summary>
        /// Virtual method to add a procedure to the list of procedures of a patient
        /// </summary>
        /// <param name="procedure"></param>
        public void AddProcedure(Procedure procedure);
        /// <summary>
        /// Virtual method to edit a procedure of a patient
        /// </summary>
        /// <param name="procedure"></param>
        /// <param name="newProcedure"></param>
        public void EditProcedure(Procedure procedure, Procedure newProcedure);
        /// <summary>
        /// Virtual method to delete a procedure of a patient
        /// </summary>
        /// <param name="procedure"></param>
        public void DeleteProcedure(Procedure procedure);
        /// <summary>
        /// Virtual method to add a medical record entry to the patient
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="entry"></param>
        public void AddMedicalRecordEntry(Patient patient, Entry entry);
        /// <summary>
        /// Virtual method to create an entry
        /// </summary>
        /// <param name="diagnose"></param>
        /// <param name="prescription"></param>
        /// <returns>Created entry</returns>
        public Entry CreateEntry(Diagnose diagnose, Prescription prescription);



    }
}
