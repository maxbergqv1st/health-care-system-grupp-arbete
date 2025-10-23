namespace App;

public class SaveUserSystem 
{
      public void SaveUser(List<IUser> users) // metod för att savea users, används när man vill skapa en users.
      {
            List<string> lines = new List<string>();
            foreach (IUser user in users)
            {                                // GetType().Name är satt för att hämta namnet på usern/klassen. 
                  lines.Add($"{user.GetType().Name},{user.FirstName},{user.LastName},{user.Username},{user._password},{user.UserStatus}");
            }
            File.WriteAllLines("users.txt", lines); // skriver till users.txt med nya listan lines. där varje user in users är en lines.
      }
      public List<IUser> LoadUser() // metod för att hämta users. Används varje gång vi vill läsa av får databas av users.
      {
            List<IUser> users = new List<IUser>();
            if (!File.Exists("users.txt")) // Om inte users.txt finns. För användarn, istället för att crasha returna en tom sträng av users.
            {
                  return users;
            }
            string[] lines = File.ReadAllLines("users.txt"); // Läser den av alla users som är sparade i en line, från users.txt.
            foreach (string line in lines) // Loopar ut alla lines. 
            {
                  string[] split = line.Split(",");  //Skapar en split vid varje comma i strängen av en user.
                  if (split.Length == 6) // bestämmer att datan av en user alltid delas in i 6 styckna värden, vilket är ett måste för att skapa en user.
                  {
                        string type = split[0]; // Region
                        string firstname = split[1]; 
                        string lastname = split[2];
                        string username = split[3];
                        string _password = split[4];
                        Enum.TryParse(split[5], out Region eRegion); // tryParse ut regionen för enum.  
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