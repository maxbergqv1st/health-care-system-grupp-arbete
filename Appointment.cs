namespace App;

public class AppointmentFather
{
      public class Appointment
      {
            public string Name { get; set; }
            public string Doctor { get; set; }
            public string Description { get; set; }
            public Appointment(string name, string doctor, string description)
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
      public List<Appointment> appointments_list = new();
      SaveAppointmentSystem appointmentSystem = new();

      public void MakeAppointment()
      {
            Console.Clear();
            Console.WriteLine($"Patient: ");
            string? name = Console.ReadLine();
            Console.WriteLine($"Description: ");
            string? description = Console.ReadLine();
            string? doctor = "dasdsa";

            //Skapa en ny Appointment
            Appointment newAppointment = new Appointment(name, doctor, description);
            //Appointment newAppointment = new ();
            appointments_list.Add(newAppointment);
            appointmentSystem.SaveAppointments(appointments_list);
            appointmentSystem.LoadAppointments();
      }
      public void ShowAppointments()
      {

            if (appointments_list.Count == 0)
            {
                  Console.Clear();
                  Console.WriteLine("No appointments..");
                  Console.ReadLine();
            }
            else
            {
                  foreach (Appointment a in appointments_list)
                  {
                        Console.WriteLine($"{a.Name} {a.Description}");
                  }
            }

      }
      public void AddDoctorToAppointment()
      {
            for (int i = 1; i > appointments_list.Count; ++i)
            {
                  Console.WriteLine($"[{i}] {appointments_list[i].Name} {appointments_list[i].Description}");
            }
            Console.ReadLine();
      }
}