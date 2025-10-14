namespace App;

public class SaveUserSystem
{
      public void SaveUser(List<IUser> users)
      {
            List<string> lines = new List<string>();
            foreach (IUser user in users)
            {
                  lines.Add($"{user.GetType().Name},{user.Name},{user.Username},{user._password},{user.UserStatus}");
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
                  if (split.Length == 5)
                  {
                        string type = split[0];
                        string name = split[1];
                        string username = split[2];
                        string _password = split[3];
                        Enum.TryParse(split[4], out Region eRegion);
                        if (type == "Patient")
                        {
                              users.Add(new Patient(name, username, _password, eRegion));
                        }
                        else if (type == "Doctor")
                        {
                              users.Add(new Doctor(name, username, _password, eRegion));
                        }
                        else if (type == "Admin")
                        {
                              users.Add(new Admin(name, username, _password, eRegion));
                        }
                  }
            }
            return users;
      }
}