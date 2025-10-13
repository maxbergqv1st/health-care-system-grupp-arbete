namespace App;

class Doctor : IUser
{
    public string Username;
    public string _password;

    public Doctor(string username, string password)
    {
        Username = username;
        _password = password;
    }
    
    public bool TryLogin(string username, string password) //Metod för att använda Account till IUsern loggin.
    {
        return username == Username && password == _password; //Skickar username och password till metoden. Returnar true eller false.
    }
}
