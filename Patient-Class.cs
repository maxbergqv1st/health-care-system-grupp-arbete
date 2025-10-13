namespace App;

class Patient : IUser
{
    public string Name;
    public string Email;
    public string _password;

    public Patient(string name, string email, string password)
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