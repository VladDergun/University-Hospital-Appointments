
namespace HospitalClassLibrary
{
    public class MedicalRecord
    {
        public Patient Patient { get; set; }
        public List<Entry> Entries { get; private set; } = new List<Entry>();
        /// <summary>
        /// Constructor for MedicalRecord
        /// </summary>
        /// <param name="patient"></param>
        public MedicalRecord(Patient patient)
        {
            Patient = patient;
        }
        /// <summary>
        /// Empty constructor for MedicalRecord
        /// </summary>
        public MedicalRecord()
        {

        }
        /// <summary>
        /// method to add entry to the medical record
        /// </summary>
        /// <param name="entry"></param>
        public void AddEntry(Entry entry)
        {
            Entries.Add(entry);
        }
    }
}
