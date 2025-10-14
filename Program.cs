using System.ComponentModel.Design;
using App;

SaveUserSystem userSystem = new();
List<IUser> users = userSystem.LoadUser();

bool found = false;
bool running = true;
IUser active_user = null;

while (running)
{
      if (active_user == null)
      {
            // ACTIVE USER = INTE HITTAD.
            Console.Clear();
            Console.WriteLine("----- Menu -----");
            Console.WriteLine("Login [1]\nRegister admin [2]\nRegister doctor [3]\nRegister patient [4]\nQuit [5]\n");
            switch (Console.ReadLine())
            {
                  case "1":
                        {
                              Console.Clear();
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
                  case "2":
                        {
                              Console.Clear();
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
                  case "3":
                        {
                              Console.Clear();
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
                  case "4":
                        {
                              Console.Clear();
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
                  case "5":
                        {
                              running = false;
                        }
                        break;
                  default:
                        continue;

            }
            Console.ReadLine();
      }
      else if (active_user.GetType().Name == "Patient")
      {
            Console.Clear();
            // ACTIVE USER = HITTAD USER OCH MAN ÄR INLOGGAD
            Console.WriteLine("Logged in as Patient");
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
      else if (active_user.GetType().Name == "Admin")
      {
            Console.Clear();
            //MACKISH ADMIN
            // ACTIVE USER = HITTAD USER OCH MAN ÄR INLOGGAD
            Console.WriteLine("----- Admin Menu -----");
            Console.WriteLine("[1] manage permissons\n[2] Assign Regions\n[3] Handle Registrations\n[4] Add Locations\n[5] Create Personell Accounts\n[6] View Permissions List");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int choice)) //Kollar om input går att konvertera till en int. 

                  switch ((AdminPermission)choice)//Switchen använder min enum AdminPermission.choice om den inte hittar caset körs default.
                  {
                        case AdminPermission.ManagePermissions:
                              {
                                    Console.Clear();
                                    Console.WriteLine("----- Manage Permissions -----");
                                    Console.ReadLine();
                                    break;
                              }
                        case AdminPermission.AssignRegions:
                              {
                                    Console.Clear();
                                    Console.WriteLine("----- Assign Regions -----");
                                    Console.ReadLine();
                                    break;
                              }
                        case AdminPermission.HandleRegistrations:
                              {
                                    Console.Clear();
                                    Console.WriteLine("----- Handle Registrations -----");
                                    //Accept
                                    //Deny
                                    Console.ReadLine();
                                    break;
                              }
                        case AdminPermission.AddLocations:
                              {
                                    Console.Clear();
                                    Console.WriteLine("----- Add Locations -----");
                                    Console.ReadLine();
                                    break;
                              }

                        case AdminPermission.CreatePersonellAccounts:
                              {
                                    Console.Clear();
                                    Console.WriteLine("----- Create Personell Accounts -----");
                                    Console.ReadLine();
                                    break;
                              }
                        case AdminPermission.ViewPermissionsList:
                              {
                                    Console.Clear();
                                    Console.WriteLine("----- View Permissions List -----");
                                    Console.ReadLine();

                              }


                              break;
                  }

      }
}
