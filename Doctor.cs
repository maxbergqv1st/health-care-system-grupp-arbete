namespace App;

class Doctor : IUser
{
    public string Name { get; set; } = ""; //Tomt namn för admin, måste ha ett namn för att hantera data till users.txt.
    public string Username { get; set; }
    public string _password { get; set; }

    public Doctor(string name, string username, string password)
    {
        Name = name;
        Username = username;
        _password = password;
    }
    
    public bool TryLogin(string username, string password) //Metod för att använda Account till IUsern loggin.
    {
        return username == Username && password == _password; //Skickar username och password till metoden. Returnar true eller false.
    }
}
