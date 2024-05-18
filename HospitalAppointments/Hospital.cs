///<summary>
///This header file is used to import the HospitalClassLibrary namespace
///</summary>
using HospitalClassLibrary;


namespace HospitalAppointments
{
    public class Hospital
    {
        public Doctor doctor = new Doctor("Helsinki", 20, "Overall doctor", "444-33-222");
        /// <summary>
        /// Constructor to create a hospital and add test patients, appointments, procedures
        /// </summary>
        public Hospital()
        {
            Patient patient1 = new Patient("Vladyslav Derhun", "23.08.2005");
            Patient patient2 = new Patient("Max Luter", "24.08.2005");
            Patient patient3 = new Patient("Antony Wellman", "24.05.2005");

            Appointment appointment1 = new Appointment(patient1, doctor, "Breast pain", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddHours(0).Hour, 30, 0));
            Appointment appointment2 = new Appointment(patient2, doctor, "Headaches", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddHours(1).Hour, 0, 0));
            Appointment appointment3 = new Appointment(patient3, doctor, "Coughing and sneezing", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddHours(1).Hour, 30, 0));

            Procedure procedure1 = new Procedure("Vacation", "Recreation", patient1, new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, DateTime.Now.Day, DateTime.Now.AddHours(0).Hour, 30, 0));
            Procedure procedure2 = new Procedure("Tumor ejection Operation", "Operation", patient2, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(7).Day, DateTime.Now.AddHours(0).Hour, 30, 0));
            Procedure procedure3 = new Procedure("Allergy test", "Medical test", patient3, new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, DateTime.Now.AddDays(9).Day, DateTime.Now.AddHours(0).Hour, 30, 0));

            doctor.AddAppointment(appointment1);
            doctor.AddAppointment(appointment2);
            doctor.AddAppointment(appointment3);

            patient1.AddProcedure(procedure1);
            patient2.AddProcedure(procedure2);
            patient3.AddProcedure(procedure3);
        }
        /// <summary>
        /// Method to run the hospital
        /// </summary>
        public void Run()
        {
            while (true)
            {
                Console.WriteLine($"Welcome, doctor {doctor.Name}!");
                int choice = GetChoice(new List<string> { "1. My patients", "2. My appointments", "3. Exit" }, "Select option: ");

                switch (choice)
                {
                    case 1:
                        ManagePatients();
                        break;
                    case 2:
                        ManageAppointments();

                        break;
                    case 3:
                        return;
                }
            }
        }
        /// <summary>
        /// Method to manage patients
        /// </summary>
        public void ManagePatients()
        {
            while (true)
            {
                GetAllPatients(doctor.Patients);
                int choice = GetChoice(new List<string> { "1. Select patient", "2. Back" }, "Select option: ");

                if (choice == 1)
                {
                    
                    Patient patient = GetPatientChoice();

                    if (patient == null)
                        continue;

                    ManagePatientOptions(patient);
                }
                else
                {
                    break;
                }
            }
        }
        /// <summary>
        /// Method to manage appointments
        /// </summary>
        public void ManageAppointments()
        {

            GetAppointments(doctor.Appointments);
            int choice = 0;

            choice = GetChoice(new List<string> { "1. Select an appointment", "2. Back" }, "Select option: ");

            switch (choice)
            {
                case 1:
                    AppointmentManager();
                    break;
                case 2:
                    return;
            }


        }
        /// <summary>
        /// Method to manage appointments
        /// </summary>
        public void AppointmentManager()
        {
            int id = -1;
            while(id == -1)
            {
                id = GetChoice(new List<string> { }, "Enter appointment id: ");
                Appointment appointment = doctor.Appointments.FirstOrDefault(a => a.Id == id);

                if(appointment == null)
                {
                    Console.WriteLine("Appointment not found. Try again.");
                    id = -1;
                    continue;
                }
                Patient patient = appointment.Patient;
                Console.WriteLine("Would you like to confirm this appointment and create a medical entry?");
                int choice = GetChoice(new List<string> { "1. Confirm appointment", "2. Back" }, "Select option: ");
                switch (choice)
                {
                    case 1:

                        Entry patientEntry = doctor.CreateEntry(CreateDiagnose(), CreateReceipt());
                        doctor.AddMedicalRecordEntry(patient, patientEntry);
                        if (patientEntry.Receipt != null)
                        {
                            doctor.AddMedicine(patient, patientEntry.Receipt.Medicine);
                        }
                        doctor.Appointments.Remove(appointment);
                        patient.Appointments.Remove(appointment);
                        Console.WriteLine("\n========================");
                        Console.WriteLine("Medical record added successfully");
                        Console.WriteLine("========================\n");

                        break;
                    case 2:
                        return;
                }
                break;
                
            }
            


        }
        /// <summary>
        /// Method to get patient choice
        /// </summary>
        /// <returns></returns>
        public Patient GetPatientChoice()
        {
            int choice = GetChoice(new List<string>(), "Enter patient id: ");
            try
            {
                return doctor.Patients[choice - 1];
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Patient id not found, try again");
                return null;
            }
        }
        /// <summary>
        /// method to manage patient options
        /// </summary>
        /// <param name="patient"></param>
        public void ManagePatientOptions(Patient patient)
        {
            while (true)
            {
                int choice = GetChoice(new List<string> { "1. Appointments", "2. Procedures", "3. Medicines", "4. Medical Record", "5. Back" }, "Select option: ");
                switch (choice)
                {
                    case 1:
                        GetAppointments(patient.Appointments);
                        break;
                    case 2:
                        ManageProcedures(patient);
                        break;
                    case 3:
                        ManageMedicines(patient);
                        break;
                    case 4:
                        ReadMedicalRecord(patient.MedicalRecord);
                        break;
                    case 5:
                        return;
                }
            }
        }
        /// <summary>
        /// method to manage procedures
        /// </summary>
        /// <param name="patient"></param>
        public void ManageProcedures(Patient patient)
        {
            while (true)
            {
                GetAllProcedures(patient.Procedures);
                int choice = GetChoice(new List<string> { "1. Add procedure", "2. Edit procedure", "3. Remove procedure", "4. Back" }, "Select option: ");

                switch (choice)
                {
                    case 1:
                        AddProcedure(patient);
                        break;
                    case 2:
                        if (patient.Procedures.Count != 0)
                            EditProcedure(patient);
                        else
                            Console.WriteLine("No procedures to edit. ");
                        break;
                    case 3:
                        if (patient.Procedures.Count != 0)
                            RemoveProcedure(patient);
                        else
                            Console.WriteLine("No procedures to remove. ");
                        break;
                    case 4:
                        return;
                }
            }
        }
        /// <summary>
        /// method to manage medicines
        /// </summary>
        /// <param name="patient"></param>
        public void ManageMedicines(Patient patient)
        {
            while (true)
            {
                GetAllMedicines(patient.Medicines);
                int choice = GetChoice(new List<string> { "1. Add medicine", "2. Edit medicine", "3. Remove medicine", "4. Back" }, "Select option: ");
                Medicine medicine = new Medicine();
                switch (choice)
                {
                    case 1:
                        medicine = CreateMedicines();
                        doctor.AddMedicine(patient, medicine);

                        break;
                    case 2:
                        if (patient.Medicines.Count != 0)
                            EditMedicine(patient);
                        else
                            Console.WriteLine("No medicines to edit. ");

                        break;
                    case 3:
                        if (patient.Medicines.Count != 0)
                            RemoveMedicine(patient);
                        else
                            Console.WriteLine("No medicines to delete. ");

                        break;
                    case 4:
                        return;
                }
            }
        }
        /// <summary>
        /// Method to add procedure
        /// </summary>
        /// <param name="patient"></param>
        public void AddProcedure(Patient patient)
        {
            Procedure procedure = CreateProcedure("create");
            procedure.ProcedurePatient = patient;
            doctor.AddProcedure(procedure);
        }
        /// <summary>
        /// Method to edit procedure
        /// </summary>
        /// <param name="patient"></param>
        public void EditProcedure(Patient patient)
        {
            while (true)
            {
                GetAllProcedures(patient.Procedures);

                int id = GetChoice(new List<string> { }, "Enter procedure id: ");

                Procedure procedure = patient.Procedures.FirstOrDefault(pr => pr.Id == id);
                if (procedure != null)
                {
                    Procedure newProcedure = CreateProcedure("edit");
                    doctor.EditProcedure(procedure, newProcedure);
                    break;
                }
                else
                    Console.WriteLine("Procedure not found. Try again");
            }

        }
        /// <summary>
        /// Method to edit medicine
        /// </summary>
        /// <param name="patient"></param>
        public void EditMedicine(Patient patient)
        {
            while (true)
            {
                GetAllMedicines(patient.Medicines);
                int id = GetChoice(new List<string> { }, "Enter medicine id: ");

                Medicine medicine = patient.Medicines.FirstOrDefault(pr => pr.Id == id);
                if (medicine != null)
                {
                    Medicine newMedicine = CreateMedicines();

                    newMedicine.Id = medicine.Id;
                    doctor.EditMedicine(patient, medicine, newMedicine);
                    break;
                }
                else
                    Console.WriteLine("Medicine not found. Try again");
            }
        }
        /// <summary>
        /// method to remove medicine
        /// </summary>
        /// <param name="patient"></param>
        public void RemoveMedicine(Patient patient)
        {
            while (true)
            {
                GetAllMedicines(patient.Medicines);
                int id = GetChoice(new List<string> { }, "Enter medicine id: ");

                Medicine medicine = patient.Medicines.FirstOrDefault(pr => pr.Id == id);
                if (medicine != null)
                {
                    doctor.DeleteMedicine(patient, medicine);
                    break;
                }
                else
                    Console.WriteLine("Medicine not found. Try again");
            }
        }
        /// <summary>
        /// method to remove procedure
        /// </summary>
        /// <param name="patient"></param>
        public void RemoveProcedure(Patient patient)
        {
            while (true)
            {
                GetAllProcedures(patient.Procedures);

                int id = GetChoice(new List<string> { }, "Enter procedure id: ");

                Procedure procedure = patient.Procedures.FirstOrDefault(pr => pr.Id == id);
                if (procedure != null)
                {
                    doctor.DeleteProcedure(procedure);
                    break;
                }
                else
                    Console.WriteLine("Procedure not found. Try again");
            }
        }

        /// <summary>
        /// method to get choice
        /// </summary>
        /// <param name="options"></param>
        /// <param name="prompt"></param>
        /// <returns></returns>

        public int GetChoice(List<string> options, string prompt)
        {
            Console.WriteLine("\n========================");
            if (options.Count > 0)
                Console.WriteLine("Please, choose one of the following:");

            foreach (object o in options)
            {
                Console.WriteLine(o);
            }
            Console.Write(prompt);
            int choice = -1;
            while(choice == -1)
            {
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Try again.");
                    Console.Write("Enter: ");
                }
                if(choice > options.Count && options.Count != 0)
                {
                    Console.WriteLine("Invalid input. Try again.");
                    Console.Write("Enter: ");
                    choice = -1;
                    continue;
                }
            }

            Console.WriteLine("========================\n");
            return choice;
        }
        /// <summary>
        /// method to get appointments
        /// </summary>
        /// <param name="appointments"></param>
        public void GetAppointments(List<Appointment> appointments)
        {
            if (appointments.Count == 0)
            {
                Console.WriteLine("No appointments to display.");
            }
            else
            {
                foreach (Appointment appointment in appointments)
                {
                    Console.WriteLine("Appointment id: " + appointment.Id);
                    Console.WriteLine("Appointment date: " + appointment.Date.ToString("dd.MM.yyyy HH:mm"));
                    Console.WriteLine("Appointment patient: " + appointment.Patient.Name);
                    Console.WriteLine("Appointment description: " + appointment.Description);
                    Console.WriteLine();
                }
            }

        }
        /// <summary>
        /// method to create procedure
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public Procedure CreateProcedure(string mode)
        {
            Procedure procedure = new Procedure();
            Console.Write("Name of procedure: ");
            procedure.NameOfProcedure = Console.ReadLine();
            if (mode == "edit")
            {
                Console.WriteLine("Leave empty to keep the same date: ");
                procedure.ProcedureDate = CreateDate("Date of procedure (dd-MM-yyyy HH:mm): ", "edit");
            }
            else
            {
                procedure.ProcedureDate = CreateDate("Date of procedure (dd-MM-yyyy HH:mm): ", "create");
            }

            Console.Write("Type of procedure: ");
            procedure.ProcedureType = Console.ReadLine();
            Console.WriteLine("\n========================");
            Console.WriteLine("Procedure added successfully!");
            Console.WriteLine("========================\n");
            return procedure;
        }

        /// <summary>
        /// method to create date
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public DateTime CreateDate(string prompt, string mode)
        {
            Console.Write(prompt);
            string dateFormat = "dd-MM-yyyy HH:mm";
            DateTime date;

            while (true)
            {
                string input = Console.ReadLine();
                if (mode == "edit" && string.IsNullOrEmpty(input))
                {
                    date = DateTime.MinValue;
                    return date;
                }

                if (DateTime.TryParseExact(input, dateFormat, null, System.Globalization.DateTimeStyles.None, out date))
                {
                    if (date < DateTime.Now)
                    {
                        Console.WriteLine("Incorrect date. Please enter future date.");
                        Console.Write("Enter date again: ");
                        continue;
                    }
                    return date;
                }
                else
                {
                    Console.WriteLine("Incorrect date format. Please enter date in format dd-MM-yyyy HH:mm.");
                    Console.Write("Enter date again: ");
                }
            }
        }
        /// <summary>
        /// method to create medicines
        /// </summary>
        /// <returns></returns>
        public Medicine CreateMedicines()
        {
            Medicine medicine = new Medicine();
            Console.Write("Name of medicine: ");
            medicine.NameOfMedication = Console.ReadLine();
            Console.Write("Description of medicine: ");
            medicine.DescriptionOfMedication = Console.ReadLine();
            Console.WriteLine("========================\n");
            return medicine;
        }
        /// <summary>
        /// method to get all patients
        /// </summary>
        /// <param name="patients"></param>
        public void GetAllPatients(List<Patient> patients)
        {
            int i = 1;
            if (patients.Count == 0)
            {
                Console.WriteLine("No patients to display.");
            }
            else
            {
                foreach (Patient patient in patients)
                {
                    patient.PatientId = i++;
                    Console.WriteLine("Patient id: " + patient.PatientId);
                    Console.WriteLine("Name: " + patient.Name);
                    Console.WriteLine("Age: " + patient.Age);
                    Console.WriteLine("Date of birth: " + patient.DateOfBirth);
                    Console.WriteLine();
                }
            }
        }
        /// <summary>
        /// method to create diagnose
        /// </summary>
        /// <returns></returns>
        public Diagnose CreateDiagnose()
        {
            Diagnose diagnose = new Diagnose();
            Console.Write("Name of diagnose: ");
            diagnose.Name = Console.ReadLine();
            return diagnose;

        }
        /// <summary>
        /// method to create a receipt
        /// </summary>
        /// <returns></returns>
        public Prescription CreateReceipt()
        {
            string answer = "";
            while (answer != "Y" && answer != "N")
            {
                Console.Write("Does the patient need receipt? Y/N: ");
                answer = Console.ReadLine();
            }

            if (answer == "Y")
            {
                Prescription receipt = new Prescription();
                Medicine medicine = new Medicine();
                Console.Write("Name of medicine: ");
                medicine.NameOfMedication = Console.ReadLine();
                Console.Write("Description of medicine: ");
                medicine.DescriptionOfMedication = Console.ReadLine();
                receipt.Description = medicine.DescriptionOfMedication;
                receipt.Medicine = medicine;
                receipt.ValidDue = CreateDate("Receipt valid due (dd-MM-yyyy HH:mm format): ", "create");
                Console.WriteLine("========================\n");
                return receipt;

            }
            else
            {
                Console.WriteLine("========================\n");
                return null;

            }


        }
        /// <summary>
        /// method to get all procedures
        /// </summary>
        /// <param name="procedures"></param>
        public void GetAllProcedures(List<Procedure> procedures)
        {
            if (procedures.Count > 0)
            {
                foreach (Procedure procedure in procedures)
                {
                    Console.WriteLine("Procedure id: " + procedure.Id);
                    Console.WriteLine("Procedure name: " + procedure.NameOfProcedure);
                    Console.WriteLine("Procedure date: " + procedure.ProcedureDate.ToString("dd.MM.yyyy HH:mm"));
                    Console.WriteLine("Procedure type: " + procedure.ProcedureType);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Nothing to display.");
            }

        }
        /// <summary>
        /// method to get all medicines
        /// </summary>
        /// <param name="medicines"></param>
        public void GetAllMedicines(List<Medicine> medicines)
        {
            if (medicines.Count > 0)
            {
                foreach (Medicine medicine in medicines)
                {
                    Console.WriteLine("Medicine id: " + medicine.Id);
                    Console.WriteLine("Medicine name: " + medicine.NameOfMedication);
                    Console.WriteLine("Medicine description: " + medicine.DescriptionOfMedication);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Nothing to display.");
            }
        }

        /// <summary>
        /// method to read medical record
        /// </summary>
        /// <param name="medicalRecord"></param>
        public void ReadMedicalRecord(MedicalRecord medicalRecord)
        {
            if (medicalRecord.Entries.Count != 0)
            {
                foreach (var entry in medicalRecord.Entries)
                {
                    Console.WriteLine("Entry id: " + entry.EntryId);
                    Console.WriteLine("Entry date: " + entry.DateOfEntry);
                    Console.WriteLine("Diagnose: " + entry.Diagnose.Name);
                    if (entry.Receipt != null)
                    {
                        Console.WriteLine("Medication name: " + entry.Receipt.Medicine.NameOfMedication);
                        Console.WriteLine("Receipt valid due: " + entry.Receipt.ValidDue);
                        Console.WriteLine("Receipt description: " + entry.Receipt.Description);


                    }
                }
            }
            else
            {
                Console.WriteLine("No entries to display.");
            }
        }
    }
}
