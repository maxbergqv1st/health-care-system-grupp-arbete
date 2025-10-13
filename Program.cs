using App;

SaveUserSystem userSystem = new();
List<IUser> users = userSystem.LoadUser();

bool found = false;
bool running = true;
IUser active_user = null;

while(running)
{
      if (active_user == null)
      {
            // ACTIVE USER = INTE HITTAD.
            Console.Clear();
            Console.WriteLine("----- Menu -----");
            Console.WriteLine("login\n[admin] [patient] [doctor] register\nadmin\nquit");
            switch (Console.ReadLine())
            {
                  case "login":
                        {
                              Console.WriteLine("----------");
                              Console.WriteLine("Username: ");
                              string input_username = Console.ReadLine();
                              Console.WriteLine("Password: ");
                              string input_password = Console.ReadLine();
                              foreach (IUser user in users)
                              {
                                    if (user.TryLogin(input_username, input_password))
                                    {
                                          active_user = user;
                                          found = true;
                                          break;
                                    }
                              }
                              if (found = false)
                              {
                                    Console.WriteLine("User wasnt found...");
                              }
                        }
                        break;
                  case "admin":
                        {
                              Console.WriteLine("----- Register -----");
                              Console.WriteLine("Name: ");
                              string input_name = Console.ReadLine();
                              Console.WriteLine("Username: ");
                              string input_username = Console.ReadLine();
                              Console.WriteLine("Password: ");
                              string input_password = Console.ReadLine();
                              Console.WriteLine("Region: North, East, West, South");
                              Enum.TryParse(Console.ReadLine(), out Region parsedRegion); //Enum.TryParse(Console.ReadLine(), true, out Region parsedRegion);
                              users.Add(new Admin(input_name, input_username, input_password, parsedRegion));
                              userSystem.SaveUser(users);
                        }
                        break;
                  case "doctor":
                        {
                              Console.WriteLine("----- Register -----");
                              Console.WriteLine("Name: ");
                              string input_name = Console.ReadLine();
                              Console.WriteLine("Username: ");
                              string input_username = Console.ReadLine();
                              Console.WriteLine("Password: ");
                              string input_password = Console.ReadLine();
                              Console.WriteLine("Region: North, East, West, South");
                              Enum.TryParse(Console.ReadLine(), out Region parsedRegion); //Enum.TryParse(Console.ReadLine(), true, out Region parsedRegion);
                              users.Add(new Doctor(input_name, input_username, input_password, parsedRegion));
                              userSystem.SaveUser(users);
                        }
                        break;
                  case "patient":
                        {
                              Console.WriteLine("----- Register -----");
                              Console.WriteLine("Name: ");
                              string input_name = Console.ReadLine();
                              Console.WriteLine("Username: ");
                              string input_username = Console.ReadLine();
                              Console.WriteLine("Password: ");
                              string input_password = Console.ReadLine();
                              Console.WriteLine("Region: North, East, West, South");
                              Enum.TryParse(Console.ReadLine(), out Region parsedRegion); //Enum.TryParse(Console.ReadLine(), true, out Region parsedRegion);
                              users.Add(new Patient(input_name, input_username, input_password, parsedRegion));
                              userSystem.SaveUser(users);
                        }
                        break;
                  case "quit":
                        {
                              running = false;
                        }
                        break;
            }
            Console.ReadLine();
      }
      else if (active_user.GetType().Name == "Patient")
      {
            Console.Clear();
            // ACTIVE USER = HITTAD USER OCH MAN ÄR INLOGGAD
            Console.WriteLine("Logged in as PAtient");
            Console.WriteLine("profile\nlogout");
            Console.ReadLine();
      }
      else if (active_user.GetType().Name == "Doctor")
      {
            Console.Clear();
            // ACTIVE USER = HITTAD USER OCH MAN ÄR INLOGGAD
            Console.WriteLine("Logged in as Doctor");
            Console.ReadLine();
      }
      else if(active_user.GetType().Name == "Admin")
      {
            Console.Clear();
            //MACKISH ADMIN
            // ACTIVE USER = HITTAD USER OCH MAN ÄR INLOGGAD
            Console.WriteLine("Logged in as Admin");
            Console.ReadLine();
      }
} 