
namespace App;

public class SaveAppointmentSystem //klassen för automatisk sparande och inläsning av bokningsfilen
{
    public void SaveAppointments(List<AppointmentFather.Appointment> appointments_list) //Metod som sparar en lista med bokningar till filen
    {
        List<string> lines = new List<string>();
        foreach (AppointmentFather.Appointment a in appointments_list) //loopar igenom varje bokning och sparar information som en sträng med information och kommatecken imellan
        {
            lines.Add($"{a.Name},{a.Doctor},{a.Description}");
        }
        File.WriteAllLines("appointments.txt", lines); //skriver alla rader i filen
    }
    public List<AppointmentFather.Appointment> LoadAppointments() //metod för attt läsa in bokningar
    {
        List<AppointmentFather.Appointment> appointments = new List<AppointmentFather.Appointment>(); //skapar en tom lista för att lagra bokningar
        if (!File.Exists("appointments.txt")) //om filen redan finns, returnerar vi den toma listan
        {
            return appointments;
        }
        string[] lines = File.ReadAllLines("appointments.txt"); //om filen finns så läses den in i strängar
        foreach (string line in lines) 
        {
            string[] split = line.Split(","); //delar upp raden i delar
            if (split.Length == 3) //kontrollerar om det finns 3 delar
            {
                string name = split[0];
                string doctor = split[1];
                string description = split[2];
                {
                    appointments.Add(new AppointmentFather.Appointment(name, doctor, description)); //skapar en ny bokningshändelse som läggs till i listan
                }
            }

        }
        return appointments;
    }
}