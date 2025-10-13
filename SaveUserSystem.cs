namespace App;

public class SaveUserSystem
{
      public void SaveUser(List<IUser> users)
      {
            List<string> lines = new List<string>();
            foreach (IUser user in users)
            {
                  lines.Add($"{user.GetType().Name},{user.Name},{user.Username},{user._password}");
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
                  if (split.Length == 4)
                  {
                        string type = split[0];
                        string name = split[1];
                        string username = split[2];
                        string _password = split[3];
                        if (type == "Patient")
                        {
                              users.Add(new Patient(name, username, _password));
                        }
                        else if (type == "Doctor")
                        {
                              users.Add(new Doctor(name, username, _password));
                        }
                        else if (type == "Admin")
                        {
                              users.Add(new Admin(name, username, _password));
                        }
                  }
            }
            return users;
      }
}