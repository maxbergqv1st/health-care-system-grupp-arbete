namespace App;

class Patient : IUser
{
    public Stream Name;
    public Stream Email;
    string _password;

    public Patient(string name, string email, string _password)
    {
        Name = name;
        Email = email;
        _password = password;
    }

    public bool TryLogin(string username, string password)
    {
        return username == Email && password == _password;
        
    }
}