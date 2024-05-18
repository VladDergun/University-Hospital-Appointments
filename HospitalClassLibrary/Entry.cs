
namespace HospitalClassLibrary
{
    public class Entry
    {
        public string EntryId { get; set; }
        public DateTime DateOfEntry { get; set; }
        public Diagnose Diagnose { get; set; }
        public Prescription? Receipt { get; set; }
        /// <summary>
        /// Constructor for Entry
        /// </summary>
        /// <param name="diagnose"></param>
        /// <param name="receipt"></param>
        public Entry(Diagnose diagnose, Prescription receipt)
        {
            DateOfEntry = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
            Diagnose = diagnose;
            Receipt = receipt;
            EntryId = Guid.NewGuid().ToString();
        }
    }
}
