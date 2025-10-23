namespace App;

class Patient : IUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string _password { get; set; }

    public Region UserStatus { get; set; }

    public Patient(string firstname, string lastname, string username, string password, Region region)
    {
        FirstName = firstname;
        LastName = lastname;
        Username = username;
        _password = password;
        UserStatus = region;
    }

    public bool TryLogin(string username, string password)
    {
        return username == Username && password == _password;
    }
}