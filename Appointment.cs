public class AppointmentFather
{
      public class Appointment
      {
            public string Name { get; set; }
            public string Doctor { get; set;  }
            public string Description { get; set; }
            public Appointment(string name, string description)
            {
                  Name = name;
                  Description = description;
            }
      }
      public List<Appointment> appointments = new();
      public void MakeAppointment()
      {
            Console.Clear();
            Console.WriteLine($"Patient: ");
            string? name = Console.ReadLine();
            Console.WriteLine($"Description: ");
            string? description = Console.ReadLine();

            //Skapa en ny Appointment
            Appointment newAppointment = new Appointment(name, description);
            appointments.Add(newAppointment);
            }
      public void ShowAppointments()
      {

            if (appointments.Count == 0)
            {
                  Console.Clear();
                  Console.WriteLine("No appointments..");
                  Console.ReadLine();
            }
            else
            {
                  foreach (Appointment a in appointments)
                  {
                        Console.WriteLine($"{a.Name} {a.Description}");
                  }
            }

      }
      public void AddDoctorToAppointment()
      {
            for (int i = 1; i > appointments.Count; ++i)
            {
                  Console.WriteLine($"[{i}] {appointments[i].Name} {appointments[i].Description}");
            }
            Console.ReadLine();
      }
}