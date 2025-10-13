using System.Net;

namespace App;

class Patient : IUser
{
    public string Name { get; set; }
    public string Username { get; set; }
    public string _password { get; set; }

    public Region UserStatus { get; set; }

    public Patient(string name, string username, string password, Region region)
    {
        Name = name;
        Username = username;
        _password = password;
        UserStatus = region;
    }

    public bool TryLogin(string username, string password)
    {
        return username == Username && password == _password;
    }
}