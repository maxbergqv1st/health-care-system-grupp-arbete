namespace App;

public interface IUser
{
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Username { get; set; }
      public string _password { get; set; }
      public Region UserStatus { get; set; }

      public bool TryLogin(string username, string password);
}