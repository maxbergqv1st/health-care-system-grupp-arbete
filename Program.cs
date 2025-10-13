using App;

SaveUserSystem userSystem = new();
List<IUser> users = userSystem.LoadUser();

bool running = true;
IUser active_user = null;

while(running)
{
      if (active_user == null)
      {
            // ACTIVE USER = INTE HITTAD.
            Console.Clear();
            Console.WriteLine("----- Menu -----");
            Console.WriteLine("login\nregister\nquit");
            switch(Console.ReadLine())
            {
                  case "login":
                        {
                              Console.WriteLine("----------");
                              Console.WriteLine("Username: ");
                              string input_username = Console.ReadLine();
                              Console.WriteLine("Password: ");
                              string input_password = Console.ReadLine();
                              foreach(IUser user in users)
                              {
                                    if (user.TryLogin(input_username, input_password))
                                    {
                                          active_user = user;
                                          break;
                                    }
                                    else
                                    {
                                          Console.WriteLine("User wasnt found...");
                                    }
                              }
                        }break;
                  case "register":
                        {
                              Console.WriteLine("----- Register -----");
                              Console.WriteLine("Name: ");
                              string input_name = Console.ReadLine();
                              Console.WriteLine("Username: ");
                              string input_username = Console.ReadLine();
                              Console.WriteLine("Password: ");
                              string input_password = Console.ReadLine();
                              users.Add(new Patient(input_name, input_username, input_password));
                              userSystem.SaveUser(users);
                        }break;
                  case "quit":
                        {
                              running = false;
                        }break;
            }
            Console.ReadLine();
      }
      else
      {
            // ACTIVE USER = HITTAD USER OCH MAN ÄR INLOGGAD
            Console.WriteLine("Logged in page");
            Console.ReadLine();
      }
} 