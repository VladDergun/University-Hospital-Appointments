
namespace HospitalClassLibrary
{
    public class Medicine
    {
        Random random = new Random();
        public int Id { get; set; }
        public string NameOfMedication { get; set; }
        public string DescriptionOfMedication { get; set; }
        /// <summary>
        /// Constructor for Medicine
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nameOfMedication"></param>
        /// <param name="descriptionOfMedication"></param>
        public Medicine(string nameOfMedication, string descriptionOfMedication)
        {
            Id = random.Next(1, 1000);
            NameOfMedication = nameOfMedication;
            DescriptionOfMedication = descriptionOfMedication;
        }
        /// <summary>
        /// Empty constructor for Medicine
        /// </summary>
        public Medicine()
        {
            Id = random.Next(1,1000);
        }
    }
}
