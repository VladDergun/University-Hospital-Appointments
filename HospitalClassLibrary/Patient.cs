/// <summary>
/// System.Globalization namespace is used to provide culture-specific information, including format patterns for dates.
/// </summary>
using System.Globalization;

namespace HospitalClassLibrary
{
    public class Patient : AppointmentAbstract
    {

        public int PatientId { get; set; }
        public string Name { get; private set; } = string.Empty;
        public int Age { get; private set; }
        public string? Address { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public MedicalRecord MedicalRecord { get; private set; } = new MedicalRecord();
        public List<Procedure> Procedures { get; private set; } = new List<Procedure>();
        public List<Medicine> Medicines { get; private set; } = new List<Medicine>();
        /// <summary>
        /// Constructor for Patient
        /// </summary>
        /// <param name="patientName"></param>
        /// <param name="address"></param>
        /// <param name="dateOfBirth"></param>
        /// <exception cref="ArgumentException"></exception>
        public Patient(string patientName, string address, string dateOfBirth)
        {
            if (string.IsNullOrWhiteSpace(patientName))
                throw new ArgumentException("Patient name cannot be null or empty.", nameof(patientName));

            if (string.IsNullOrWhiteSpace(dateOfBirth))
                throw new ArgumentException("Date of birth cannot be null or empty.", nameof(dateOfBirth));

            Name = patientName;
            DateOfBirth = DateTime.ParseExact(dateOfBirth, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            Age = CalculateAge(DateOfBirth);
            Address = address;
        }

        /// <summary>
        /// Constructor for Patient
        /// </summary>
        /// <param name="patientName"></param>
        /// <param name="dateOfBirth"></param>
        public Patient(string patientName, string dateOfBirth) : this(patientName, null, dateOfBirth) { }
        /// <summary>
        /// Constructor for Patient
        /// </summary>
        public Patient() { }
        /// <summary>
        /// calculates the age of the patient
        /// </summary>
        /// <param name="dateOfBirth"></param>
        /// <returns>age</returns>
        private int CalculateAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }

        /// <summary>
        /// Method to add a medicine to the list of medicines
        /// </summary>
        /// <param name="medicine"></param>
        public void AddMedicine(Medicine medicine) => Medicines.Add(medicine);
        /// <summary>
        /// Method to add a medical record to the patient
        /// </summary>
        /// <param name="medicalRecord"></param>
        public void AddMedicalRecord(MedicalRecord medicalRecord) => MedicalRecord = medicalRecord;
        /// <summary>
        /// Method to add a procedure to the list of procedures
        /// </summary>
        /// <param name="procedure"></param>
        public void AddProcedure(Procedure procedure) => Procedures.Add(procedure);
        /// <summary>
        /// Method to remove a procedure from the list of procedures
        /// </summary>
        /// <param name="procedure"></param>
        public void DeleteProcedure(Procedure procedure) => Procedures.Remove(procedure);
        /// <summary>
        /// Method to remove a medicine from the list of medicines
        /// </summary>
        /// <param name="medicine"></param>
        public void RemoveMedicine(Medicine medicine) => Medicines.Remove(medicine);
        

    }
}
