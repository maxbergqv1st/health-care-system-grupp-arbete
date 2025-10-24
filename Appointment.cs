namespace App;

public class AppointmentFather //klass övanför vår appointment klass är osäkert väför har vi den, max hjälpte mig för att jag hade problem att koppla alla metoder med saveappointmentsystem
{
      public class Appointment //klass som lagrar information om en bokning
      {
            public string Name { get; set; }
            public string Doctor { get; set; }
            public string Description { get; set; }
            public Appointment(string name, string doctor, string description) //konstruktorn som används när skaffar ny bokning
            {
                  Name = name;
                  Doctor = doctor;
                  Description = description;
            }

            //public Appointment(string? name, string? description)
            //{
            //   Name = name;
            //  Description = description;
            //}
      }
      public List<Appointment> appointments_list = new(); //listan som sparar bokningar medan program körs
      SaveAppointmentSystem appointmentSystem = new(); 

      public void MakeAppointment() //metod för att skapa ny bokning
      {
            Console.Clear();
            Console.WriteLine($"Patient: "); //information som krävs för ny bokning, kan utökas med mer information i senare versioner av programet
            string? name = Console.ReadLine();
            Console.WriteLine($"Description: ");
            string? description = Console.ReadLine();
            string? doctor = "dasdsa";

            //Skapa en ny Appointment
            Appointment newAppointment = new Appointment(name, doctor, description);
            //Appointment newAppointment = new ();
            appointments_list.Add(newAppointment); //lägger till bokningen i listan
            appointmentSystem.SaveAppointments(appointments_list); //sparar bokningen i fil
            appointmentSystem.LoadAppointments(); //Lässer in bokningar igen
      }
      public void ShowAppointments() //visar bokningar i listan
      {

            if (appointments_list.Count == 0) //om det finns inga bokningar, visas meddelande
            {
                  Console.Clear();
                  Console.WriteLine("No appointments..");
                  Console.ReadLine();
            }
            else
            {
                  foreach (Appointment a in appointments_list) //om det finns bokningar...
                  {
                        Console.WriteLine($"{a.Name} {a.Description}"); //...så visas dessa med sina egenskaper
                  }
            }

      }
      public void AddDoctorToAppointment() //metod för att tilldela läkare obs funktionen är inte utvecklat till slut pga projektets tidsbegränsning
      {
            for (int i = 1; i > appointments_list.Count; ++i)
            {
                  Console.WriteLine($"[{i}] {appointments_list[i].Name} {appointments_list[i].Description}");
            }
            Console.ReadLine();
      }
}