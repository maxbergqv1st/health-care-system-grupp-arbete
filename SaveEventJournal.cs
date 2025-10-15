namespace App;
public class Event
{
      SaveUserSystem userSystem = new();
      public Event()
      {
            users = userSystem.LoadUser();
      }
      public class PatientEvent
      {
            public string OwnerUsername { get; set; } // IUser.Username, make it so no username is the same
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Description { get; set; }
            public string Document { get; set; }
            public Region Location { get; set; }
      }
      List<IUser> users = new();

      bool found = false;
      public void AddEvent()
      {
            Console.Clear();
            Console.WriteLine("[1] Add a event to patient\n[2] Back");
            switch (Console.ReadLine())
            {
                  case "1":
                        {
                              Console.Clear();
                              Console.WriteLine("----- Add Event ------");
                              Console.WriteLine("Description: ");
                              Console.WriteLine("Document");
                              Console.WriteLine("Location");

                              // foreach (IUser user in users)
                              // {
                              //       Console.WriteLine($"{user.Name} {user.Username}");
                              // }

                              Console.WriteLine("Patient name: ");
                              string? input_new_patient = Console.ReadLine();
                              List<IUser> matchedUsers = new();
                              foreach (IUser user in users)
                              {
                                    if (input_new_patient == user.Name)
                                    {
                                          matchedUsers.Add(user);
                                    }
                              }
                              if (matchedUsers.Count > 0)
                              {
                                    Console.Clear();
                                    Console.WriteLine($"| [N]orth | [W]est | [E]ast | [S]outh |");
                                    Console.WriteLine($"\n----- Users {input_new_patient} ------");
                                    found = true;
                                    foreach (IUser matched in matchedUsers)
                                    {
                                          Console.WriteLine($"Patient {matched.Name} {matched.Username} {matched.UserStatus}");

                                    }

                                    ConsoleKeyInfo key = Console.ReadKey(true);

                                    bool backToPatientMenu = false;

                                    while (!backToPatientMenu)
                                    {
                                          switch (key.KeyChar)
                                          {
                                                case 'N': //'N' kan hålla ett värde jämfört med "N" //visste inte innnan
                                                case 'n':
                                                      Console.Clear();

                                                      Console.WriteLine("\n----- North -----\n");
                                                      foreach (IUser matched in matchedUsers)
                                                      {
                                                            if (matched.UserStatus == Region.North) // Kollar om enumen är north på 
                                                            {
                                                                  Console.WriteLine($"Patient {matched.Name} [Last Name] {matched.Username} {matched.UserStatus}");
                                                            }
                                                      }
                                                      Console.ReadLine();


                                                      break;
                                                case 'W': //'N' kan hålla ett värde jämfört med "N" //visste inte innnan
                                                case 'w':
                                                      Console.Clear();

                                                      Console.WriteLine("----- West -----\n");
                                                      foreach (IUser matched in matchedUsers)
                                                      {
                                                            if (matched.UserStatus == Region.West) // Kollar om enumen är north på 
                                                            {
                                                                  Console.WriteLine($"Patient: {matched.Name} [Last Name] {matched.Username} {matched.UserStatus}");
                                                            }
                                                      }
                                                      Console.ReadLine();
                                                      break;
                                                case 'E': //'N' kan hålla ett värde jämfört med "N" //visste inte innnan
                                                case 'e':
                                                      Console.Clear();

                                                      Console.WriteLine("----- East -----\n");
                                                      foreach (IUser matched in matchedUsers)
                                                      {
                                                            if (matched.UserStatus == Region.East) // Kollar om enumen är north på 
                                                            {
                                                                  Console.WriteLine($"Patient {matched.Name} [Last Name] {matched.Username} {matched.UserStatus}");
                                                            }
                                                      }
                                                      Console.ReadLine();
                                                      break;
                                                case 'S': //'N' kan hålla ett värde jämfört med "N" //visste inte innnan
                                                case 's':
                                                      Console.Clear();

                                                      Console.WriteLine("----- South -----\n");
                                                      foreach (IUser matched in matchedUsers)
                                                      {
                                                            if (matched.UserStatus == Region.South) // Kollar om enumen är north på 
                                                            {
                                                                  Console.WriteLine($"Patient {matched.Name} [Last Name] {matched.Username} {matched.UserStatus}");
                                                            }
                                                      }
                                                      Console.WriteLine($"Patient: {input_new_patient}");
                                                      Console.WriteLine($"Lastname: MOCK");
                                                      Console.WriteLine("Description: ");
                                                      Console.WriteLine("Document");
                                                      Console.WriteLine("Location");
                                                      Console.ReadLine();
                                                      break;
                                                case 'B': //'N' kan hålla ett värde jämfört med "N" //visste inte innnan
                                                case 'b':
                                                      backToPatientMenu = true;
                                                      break;
                                                case 'A': //'N' kan hålla ett värde jämfört med "N" //visste inte innnan
                                                case 'a':
                                                      Console.Clear();
                                                      Console.WriteLine($"Patient {input_new_patient}");
                                                      string? FirstName = input_new_patient;
                                                      Console.WriteLine($"Patient {input_new_patient}");
                                                      //string? FirstName = input_new_patient;
                                                      Console.WriteLine($"Lastname: MOCK");
                                                      string? patient_lastname = Console.ReadLine();
                                                      Console.WriteLine("Description: ");
                                                      string? patient_description = Console.ReadLine();
                                                      Console.WriteLine("Document");
                                                      string? patient_document = Console.ReadLine();
                                                      Console.WriteLine("Location N/W/E/S");
                                                      string? location_input = Console.ReadLine();

                                                      Region region = Region.North; // defaultar till north // change to doctors region as default
                                                      if (location_input == "N") region = Region.North;
                                                      else if (location_input == "W") region = Region.West;
                                                      else if (location_input == "E") region = Region.East;
                                                      else if (location_input == "S") region = Region.South;

                                                      PatientEvent newEvent = new PatientEvent
                                                      {
                                                            // FirstName = patient_name;
                                                      };

                                                      break;
                                                default:
                                                      Console.WriteLine("Unvalid input...");
                                                      backToPatientMenu = true;
                                                      Console.ReadLine();
                                                      backToPatientMenu = false;
                                                      break;
                                          }
                                    }
                              }
                              if (!found)
                              {
                                    Console.Clear();
                                    Console.WriteLine("NAMN EJ MATCHAT, KÖR DENNA SCOPE");
                              }
                        }
                        break;
                  case "2":
                        {

                        }
                        break;
            }


            // foreach (IUser user in users)
            // {
            //       Console.WriteLine($"");
            // }
      }


}