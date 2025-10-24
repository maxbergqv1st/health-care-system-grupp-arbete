namespace App;

class Patient : IUser // Patient klassen representerar patienten med sina egenskaper
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string _password { get; set; }

    public Region UserStatus { get; set; }

    public Patient(string firstname, string lastname, string username, string password, Region region) //konstruktorn i pat. klassen, används för att skapa en ny patient i systemet
    {
        FirstName = firstname;
        LastName = lastname;
        Username = username;
        _password = password;
        UserStatus = region;
    }

    public bool TryLogin(string username, string password) //Metod för inloggning kontrollerar om den angivna username och password stämmer
    {
        return username == Username && password == _password;
    }
}