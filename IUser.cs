namespace App;

public interface IUser
{
      public string Name { get; set; }
      public string Username { get; set; }
      public string _password { get; set; }
      public Region UserStatus { get; set; }

      public bool TryLogin(string username, string password);
}