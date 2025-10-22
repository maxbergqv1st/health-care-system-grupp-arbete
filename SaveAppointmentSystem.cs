
namespace App;

public class SaveAppointmentSystem
{
    public void SaveAppointments(List<AppointmentFather.Appointment> appointments_list)
    {
        List<string> lines = new List<string>();
        foreach (AppointmentFather.Appointment a in appointments_list)
        {
            lines.Add($"{a.Name},{a.Doctor},{a.Description}");
        }
        File.WriteAllLines("appointments.txt", lines);
    }
    public List<AppointmentFather.Appointment> LoadAppointments()
    {
        List<AppointmentFather.Appointment> appointments = new List<AppointmentFather.Appointment>();
        if (!File.Exists("appointments.txt"))
        {
            return appointments;
        }
        string[] lines = File.ReadAllLines("appointments.txt");
        foreach (string line in lines)
        {
            string[] split = line.Split(",");
            if (split.Length == 3)
            {
                string name = split[0];
                string doctor = split[1];
                string description = split[2];
                {
                    appointments.Add(new AppointmentFather.Appointment(name, doctor, description));
                }
            }

        }
        return appointments;
    }
}