
namespace HospitalClassLibrary
{
    public class Procedure
    {
        private Random random = new Random();
        public int Id { get; set; }
        public string NameOfProcedure { get; set; }
        public string ProcedureType { get; set; }
        public Patient ProcedurePatient { get; set; }
        public DateTime ProcedureDate { get; set; }
        /// <summary>
        /// Constructor for Procedure
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="patient"></param>
        /// <param name="procedureDate"></param>
        public Procedure(string name, string type, Patient patient, DateTime procedureDate ) 
        {
            Id = random.Next(1,1000);
            NameOfProcedure = name;
            ProcedureType = type;
            ProcedurePatient = patient;
            ProcedureDate = procedureDate;
        }
        /// <summary>
        /// Empty constructor for Procedure
        /// </summary>
        public Procedure() 
        {
            Id=random.Next(1,1000);
        }
       
    }
}
