
namespace HospitalClassLibrary
{
    public abstract class AppointmentAbstract
    {
        public List<Appointment> Appointments { get; private set; } = new List<Appointment>();
        /// <summary>
        /// virtual method to add appointment
        /// </summary>
        /// <param name="appointment"></param>
        public virtual void AddAppointment(Appointment appointment)
        {
            Appointments.Add(appointment);
        }
    }
}
