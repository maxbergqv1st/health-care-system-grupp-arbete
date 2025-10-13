namespace App;

class Patient : IUser
{
    public string Name { get; set; }
    public string Username { get; set; }
    public string _password { get; set; }

    public Patient(string name, string username, string password)
    {
        Name = name;
        Username = username;
        _password = password;
    }

    public bool TryLogin(string username, string password)
    {
        return username == Username && password == _password;
    }
}