using App;

SaveUserSystem userSystem = new();
//
SaveAppointmentSystem appointmentSystem = new();
//
List<IUser> users = userSystem.LoadUser();

Event AddEvent = new();
AppointmentFather Appointment = new();

bool running = true;
IUser active_user = null;

while (running)
{
      bool found = false;
      bool notARobot = false;
      if (active_user == null && notARobot == false)
      {
            Console.Clear();
            Console.WriteLine("Verify that youre not a robot.");
            Console.WriteLine("\n--------------------");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXX\nXXHXXXXXXXXXXXXXXXXX\nXXXXXXXXXXXXXXXXXXXX\nXXXXXXXXXXXXXXXXXXXX\nXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("--------------------");
            Console.WriteLine("\nWrite the odd letter hidden in the board:");
            string verify = Console.ReadLine();
            if (verify.ToLower() == "h")
            {
                  notARobot = true;
            }
            else
            {
                  Console.Clear();
                  Console.WriteLine("You stupid looking machine...");
                  Console.WriteLine($"where the f*** did you find the letter: {verify}??\nPress ENTER if your stupid ass acually is human...");
                  Console.ReadLine();
                  continue;
            }
            if(notARobot == true)
            {
                  // ACTIVE USER = INTE HITTAD.
                  Console.Clear();
                  Console.WriteLine("----- Menu -----");
                  Console.WriteLine("[1] Login\n[Q] Quit\n");
                  ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.KeyChar)
                  {
                        case '1':
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
                                    if (found == false)
                                    {
                                          Console.WriteLine("User wasnt found...");
                                          Console.ReadLine();
                                          continue;
                                    }
                              }
                              break;
                        case '2':
                              {
                                    Console.Clear();
                                    Console.WriteLine("----- Register Admin -----");
                                    Console.WriteLine("Username: ");
                                    string input_username = Console.ReadLine();
                                    foreach (IUser user in users)
                                    {
                                          if (input_username == user.Username)
                                          {
                                                System.Console.WriteLine("Username already exists.");
                                                Console.ReadLine();
                                                continue;
                                          }
                                    }
                                    Console.WriteLine("First name: ");
                                    string input_firstname = Console.ReadLine();
                                    Console.WriteLine("Last name: ");
                                    string input_lastname = Console.ReadLine();
                                    Console.WriteLine("Password: ");
                                    string input_password = Console.ReadLine();
                                    Console.WriteLine("Region: North, East, West, South");
                                    Enum.TryParse(Console.ReadLine(), out Region parsedRegion); //Enum.TryParse(Console.ReadLine(), true, out Region parsedRegion);
                                    users.Add(new Admin(input_firstname, input_lastname, input_username, input_password, parsedRegion));
                                    userSystem.SaveUser(users);
                              }
                              break;
                        case '3':
                              {
                                    Console.Clear();
                                    Console.WriteLine("----- Register Doctor -----");
                                    Console.WriteLine("Username: ");
                                    string input_username = Console.ReadLine();
                                    foreach (IUser user in users)
                                    {
                                          if (input_username == user.Username)
                                          {
                                                System.Console.WriteLine("Username already exists.");
                                                Console.ReadLine();
                                                continue;
                                          }
                                    }
                                    Console.WriteLine("First name: ");
                                    string input_firstname = Console.ReadLine();
                                    Console.WriteLine("Last name: ");
                                    string input_lastname = Console.ReadLine();
                                    Console.WriteLine("Password: ");
                                    string input_password = Console.ReadLine();
                                    Console.WriteLine("Region: North, East, West, South");
                                    Enum.TryParse(Console.ReadLine(), out Region parsedRegion); //Enum.TryParse(Console.ReadLine(), true, out Region parsedRegion);
                                    users.Add(new Doctor(input_firstname, input_lastname, input_username, input_password, parsedRegion));
                                    userSystem.SaveUser(users);
                              }
                              break;
                        case '4':
                              {
                                    Console.Clear();
                                    Console.WriteLine("----- Register Patient -----");
                                    Console.WriteLine("Username: ");
                                    string input_username = Console.ReadLine();
                                    foreach (IUser user in users)
                                    {
                                          if (input_username == user.Username)
                                          {
                                                System.Console.WriteLine("Username already exists.");
                                                Console.ReadLine();
                                                continue;
                                          }
                                    }
                                    Console.WriteLine("First name: ");
                                    string input_firstname = Console.ReadLine();
                                    Console.WriteLine("Last name: ");
                                    string input_lastname = Console.ReadLine();
                                    Console.WriteLine("Password: ");
                                    string input_password = Console.ReadLine();
                                    Console.WriteLine("Region: North, East, West, South");
                                    Enum.TryParse(Console.ReadLine(), out Region parsedRegion); //Enum.TryParse(Console.ReadLine(), true, out Region parsedRegion);
                                    users.Add(new Patient(input_firstname, input_lastname, input_username, input_password, parsedRegion));
                                    userSystem.SaveUser(users);
                              }
                              break;
                        case 'Q':
                        case 'q':
                              {
                                    running = false;
                              }
                              break;
                        default:
                              Console.WriteLine("Unvalid option...");
                              break;
                  }
            }
      }
      else if (active_user.GetType().Name == "Patient")
      {
            Console.Clear();
            // ACTIVE USER = HITTAD USER OCH MAN ÄR INLOGGAD
            Console.WriteLine($"----- Welcome {active_user.FirstName} -----");
            Console.WriteLine("\n[1] View my Journal\n[2] Request an Appointment\n[3] View my Schedule\n[4] profile\n[5] Logout\n[6] Exit");    
            ConsoleKeyInfo key = Console.ReadKey(true);       
            switch (key.KeyChar)
            {
                  case '1':
                        Console.Clear();
                        Console.WriteLine("----- Your Journal -----");
                        AddEvent.ShowJournal(active_user); // SaveEventJournal.cs
                        break;
                  case '2':
                        Console.Clear();
                        Console.WriteLine("----- Request Appointemnt -----");
                        Appointment.MakeAppointment();
                        break;
                  case '3':
                        Console.Clear();
                        Console.WriteLine("----- Schedules -----");
                        // if active user finns i Appointment list
                        //{
                        Appointment.ShowAppointments();
                        //}
                        break;
                  case 'L':
                  case 'l':
                        active_user = null;
                        break;
                  case 'Q':
                  case 'q':
                        running = false;
                        break;

                  default:
                        Console.WriteLine("Unvalid input...");
                        Console.ReadLine();
                        break;
            }
      }
      else if (active_user.GetType().Name == "Doctor")
      {
            Console.Clear();
            // ACTIVE USER = HITTAD USER OCH MAN ÄR INLOGGAD
            Console.Clear();
            Console.WriteLine("logged in as doctor");
            Console.WriteLine("[1] Add appointment \n[2] Show appointment \n[3] add Event\n[4] Journals\n[L] logout ");
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.KeyChar)
            {

                  case '1':
                        Console.WriteLine("----- Add appointments -----");
                        Appointment.MakeAppointment();
                        break;

                  case '2':
                        Console.WriteLine("----- Show appointments -----");
                        Appointment.ShowAppointments();
                        break;

                  case '3':
                        AddEvent.AddEvent(active_user); // SaveEventJournal.cs
                        break;
                  case '4':
                         AddEvent.ShowJournal(active_user); // SaveEventJournal.cs
                        break;
                  case 'L':
                  case 'l':
                        active_user = null;
                        Console.WriteLine("logged out");
                        break;
                  default:
                        Console.WriteLine("Unvalid input...");
                        break;
            }
      }
      else if (active_user.GetType().Name == "Admin")
      {
            Console.Clear();
            //MACKISH ADMIN
            // ACTIVE USER = HITTAD USER OCH MAN ÄR INLOGGAD
            Console.WriteLine("----- Admin Menu -----");
            Console.WriteLine("[1] manage permissons\n[2] Assign Regions\n[3] Handle Registrations\n[4] Add Locations\n[5] Create Personell Accounts\n[6] View Permissions List\n[0] Logout");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int choice)) //Kollar om input går att konvertera till en int. 
            {
                  if (choice != 0 && ((Admin)active_user).HasPermission((AdminPermission)choice))
                  {
                        Console.WriteLine("Duuude what are you doing here? to acces this you need to be atleast 5ft tall...(and have permission)");
                        Console.ReadKey();
                  }
                  else
                  {
                        switch ((AdminPermission)choice)//Switchen använder min enum AdminPermission.choice om den inte hittar caset körs default.
                        {

                              case AdminPermission.None:
                                    {
                                          active_user = null;
                                          Console.WriteLine("You've been logged out.");
                                          Console.ReadLine();
                                          break;
                                    }
                              case AdminPermission.ManagePermissions:
                                    {
                                          Console.Clear();
                                          Console.WriteLine("----- Manage Permissions -----");
                                          Console.WriteLine("Grant or revoke permissions here");

                                          int i = 1;
                                          List<Admin> adminList = new();

                                          foreach (var user in users)
                                          {
                                                if (user is Admin admin)
                                                {
                                                      Console.WriteLine($"[{i}] {admin.Username}:");
                                                      adminList.Add(admin);
                                                      i++;
                                                }
                                          }

                                          if (adminList.Count == 0)
                                          {
                                                Console.WriteLine("No admins here mate");
                                                Console.ReadLine();
                                                break;
                                          }

                                          Console.WriteLine("\nWrite the number of the admin you would like to edit permissions for");
                                          if (int.TryParse(Console.ReadLine(), out int adminChoice) && adminChoice > 0 && adminChoice <= adminList.Count)
                                          {
                                                Admin selectedAdmin = adminList[adminChoice - 1];

                                                while (true)
                                                {
                                                      Console.Clear();
                                                      Console.WriteLine($"Editing permissions for {selectedAdmin.Username}");
                                                      Console.WriteLine("\nPermissions:");
                                                      int j = 1;

                                                      foreach (AdminPermission perm in Enum.GetValues(typeof(AdminPermission)))
                                                      {
                                                            if (perm == AdminPermission.None)
                                                            {
                                                                  continue;
                                                            }

                                                            bool has = selectedAdmin.HasPermission(perm);
                                                            string mark;

                                                            if (has)
                                                            {
                                                                  mark = "[X]";
                                                            }
                                                            else
                                                            {
                                                                  mark = "[ ]";
                                                            }

                                                            Console.WriteLine($"[{j}] {perm} {mark}");
                                                            j++;
                                                      }

                                                      Console.WriteLine("\nEnter a number to toggle permission, press 0 to go back");
                                                      string permInput = Console.ReadLine();

                                                      if (int.TryParse(permInput, out int permIndex))
                                                      {
                                                            if (permIndex == 0)
                                                            {
                                                                  break;
                                                            }

                                                            List<AdminPermission> allPerms = new();
                                                            foreach (AdminPermission perm in Enum.GetValues(typeof(AdminPermission)))
                                                            {
                                                                  if (perm != AdminPermission.None)
                                                                  {
                                                                        allPerms.Add(perm);
                                                                  }
                                                            }

                                                            if (permIndex > 0 && permIndex <= allPerms.Count)
                                                            {
                                                                  AdminPermission chosenPerm = allPerms[permIndex - 1];
                                                                  if (selectedAdmin.HasPermission(chosenPerm))
                                                                  {
                                                                        selectedAdmin.RevokePermission(chosenPerm);
                                                                        Console.WriteLine($"{chosenPerm} revoked.");
                                                                  }
                                                                  else
                                                                  {
                                                                        selectedAdmin.GrantPermission(chosenPerm);
                                                                        Console.WriteLine($"{chosenPerm} granted.");
                                                                  }

                                                                  userSystem.SaveUser(users);
                                                            }
                                                            else
                                                            {
                                                                  Console.WriteLine("Invalid choice");
                                                            }
                                                      }
                                                      else
                                                      {
                                                            Console.WriteLine("Invalid input");
                                                      }
                                                      Console.WriteLine("Press Enter to continue...");
                                                      Console.ReadLine();
                                                }
                                          }

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
                                          Console.WriteLine("Accept or Deny user registration...");
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
                                          //Läg in HasPermission här, tror jag..
                                          Console.ReadLine();


                                    }


                                    break;
                        }
                  }

            }
      }
}