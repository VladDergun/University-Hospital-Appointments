
namespace HospitalClassLibrary
{
    public class Appointment
    {
        Random random = new Random();
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; private set; }
        public string Description { get; private set; }
        public DateTime Date { get; private set; }
        /// <summary>
        /// Constructor for Appointment
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="doctor"></param>
        /// <param name="description"></param>
        /// <param name="date"></param>
        public Appointment(Patient patient, Doctor doctor, string description, DateTime date)
        {
            Id = random.Next(1,10000);
            Patient = patient;
            Doctor = doctor;
            Description = description;
            Date = date;
        }

    }
}
