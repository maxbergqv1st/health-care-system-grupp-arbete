namespace App;

public class SaveUserSystem
{
      public void SaveUser(List<IUser> users)
      {
            List<string> lines = new List<string>();
            foreach (IUser user in users)
            {
                  lines.Add($"{user.GetType().Name},{user.FirstName},{user.LastName},{user.Username},{user._password},{user.UserStatus}");
            }
            File.WriteAllLines("users.txt", lines); 
      }
      public List<IUser> LoadUser()
      {
            List<IUser> users = new List<IUser>();
            if (!File.Exists("users.txt"))
            {
                  return users;
            }
            string[] lines = File.ReadAllLines("users.txt");
            foreach (string line in lines)
            {
                  string[] split = line.Split(",");
                  if (split.Length == 6)
                  {
                        string type = split[0];
                        string firstname = split[1];
                        string lastname = split[2];
                        string username = split[3];
                        string _password = split[4];
                        Enum.TryParse(split[5], out Region eRegion);
                        if (type == "Patient")
                        {
                              users.Add(new Patient(firstname, lastname, username, _password, eRegion));
                        }
                        else if (type == "Doctor")
                        {
                              users.Add(new Doctor(firstname, lastname, username, _password, eRegion));
                        }
                        else if (type == "Admin")
                        {
                              users.Add(new Admin(firstname, lastname, username, _password, eRegion));
                        }
                  }
            }
            return users;
      }
}