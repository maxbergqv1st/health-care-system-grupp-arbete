namespace App;

public enum Status
{
    active,
    inactive,

}
public enum Val
{
    home,

}
public enum Regionhalland
{
    
}

public class User
{
    public string Username { get; set; }
    private string _password = "test";
    public bool TryLogin(string username, string password)
    {
        return username == Username && password == _password;
    }
}