using System.ComponentModel.Design;
using System.Security;
using App;

SaveUserSystem userSystem = new();
List<IUser> users = userSystem.LoadUser();

// IMPORT AppointmentFather FRÅN APOINTMENT.CS
Event AddEvent = new();
AppointmentFather Appointment = new();
//

bool found = false;
bool running = true;
IUser active_user = null;

while (running)
{
      if (active_user == null)
      {
            Console.Clear();
            Console.WriteLine("\nVerify that youre not a robot.");
            Console.WriteLine("\n--------------------");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXX\nXXHXXXXXXXXXXXXXXXXX\nXXXXXXXXXXXXXXXXXXXX\nXXXXXXXXXXXXXXXXXXXX\nXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("--------------------");
            Console.WriteLine("\nWrite the odd letter hidden in the board(small letter):");

            string verify = Console.ReadLine();

            if (verify == "h")
            {
                  // ACTIVE USER = INTE HITTAD.
                  Console.Clear();
                  Console.WriteLine("----- Menu -----");
                  Console.WriteLine("[1] Login\n[2] Register admin\n[3] Register doctor\n[4] Register patient\n[5] Quit\n");
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
                                    if (found == false)
                                    {
                                          Console.WriteLine("User wasnt found...");
                                    }
                              }
                              break;
                        case "2":
                              {
                                    Console.Clear();
                                    Console.WriteLine("----- Register -----");
                                    Console.WriteLine("Username: ");
                                    string input_username = Console.ReadLine();
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
                        case "3":
                              {
                                    Console.Clear();
                                    Console.WriteLine("----- Register -----");
                                    Console.WriteLine("Username: ");
                                    string input_username = Console.ReadLine();
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
                        case "4":
                              {
                                    Console.Clear();
                                    Console.WriteLine("----- Register -----");
                                    Console.WriteLine("Username: ");
                                    string input_username = Console.ReadLine();
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
                        case "5":
                              {
                                    running = false;
                              }
                              break;
                        default:
                              continue;

                  }
            }
            else
            {
                  Console.WriteLine("You stupid looking machine...");
                  Console.WriteLine($"where the f*** did you find the letter: {verify}??\nPress ENTER if your stupid ass acually is human...");
                  Console.ReadLine();
                  continue;
            }
            Console.ReadLine();
      }
      else if (active_user.GetType().Name == "Patient")
      {
            Console.Clear();
            // ACTIVE USER = HITTAD USER OCH MAN ÄR INLOGGAD
            Console.WriteLine("Logged in as Patient");
            Console.WriteLine("[1] profile\n[2] Make a appointment \n[3] Show appointments \n[L]logout");
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.KeyChar)
            {
                  case '1':
                        Console.Clear();
                        Console.WriteLine("Profile");
                        Console.ReadLine();
                        break;
                  case '2':
                        Console.Clear();
                        Console.WriteLine("----- Make a appointment -----");
                        Appointment.MakeAppointment();
                        Console.ReadLine();


                        break;
                  case '3':
                        Console.Clear();
                        Console.WriteLine("----- Show a appointment -----");
                        // if active user finns i Appointment list
                        //{
                        Appointment.ShowAppointments();
                        //}
                        break;
                  case 'L':
                        active_user = null;
                        break;
            }


            Console.ReadLine();
      }
      else if (active_user.GetType().Name == "Doctor")
      {
            Console.Clear();
            // ACTIVE USER = HITTAD USER OCH MAN ÄR INLOGGAD
            Console.Clear();
            Console.WriteLine("logged in as doctor");
            Console.WriteLine("[1] Add appointment \n[2] Show appointment \n[3] add Event \n[L] logout ");
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
                                          foreach (var user in users)
                                                if (user is Admin admin)
                                                {
                                                      Console.WriteLine($"{admin.Username} has permissions: {HasPermission()}");
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