/// <summary>
/// This import statement is used to import the HospitalAppointments namespace
/// </summary>
using HospitalAppointments;

class Program
{
    /// <summary>
    /// Main method to run the program
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        Hospital hospital = new Hospital();

        hospital.Run();
    }
}