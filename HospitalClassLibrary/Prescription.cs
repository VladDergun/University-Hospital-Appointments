
namespace HospitalClassLibrary
{
    public class Prescription
    {
        
        public Medicine Medicine { get; set; }
        public DateTime? ValidDue { get; set; }
        public string? Description { get; set; }
       
        /// <summary>
        /// Constructor for Prescription
        /// </summary>
        public Prescription()
        {
            Medicine = new Medicine();
        }

        
    }
}
