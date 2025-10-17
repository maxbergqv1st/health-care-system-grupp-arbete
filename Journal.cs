using System.Reflection.Metadata;

namespace App;



public class Event
{
      SaveUserSystem userSystem = new();
      public Event()
      {
            users = userSystem.LoadUser();
      }
      public class Journal
      {
            public string? OwnerUsername { get; set; } // IUser.Username, make it so no username is the same
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Description { get; set; }
            public string? Document { get; set; }
            public DateTime Date { get; set; }
            public Region Location { get; set; }

            public Journal(string ownerUsername, string firstName, string lastName, string description, string document, Region location)
            {
                  OwnerUsername = ownerUsername;
                  FirstName = firstName;
                  LastName = lastName;
                  Description = description;
                  Document = document;
                  Location = location;
                  Date = DateTime.Now;
            }
      }
      List<IUser> users = new();

      bool found = false;
      public void AddEvent(IUser active_user)
      {
            Console.Clear();
            Console.WriteLine("[1] Add a event to patient\n[2] Back");
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.KeyChar)
            {
                  case '1':
                        {
                              Console.Clear();
                              Console.WriteLine("----- Add Event ------");
                              Console.WriteLine("Patient name: ");
                              string? input_new_patient = Console.ReadLine();
                              List<IUser> matchedUsers = new();
                              Region doctorRegion = active_user.UserStatus;
                              foreach (IUser user in users)
                              {
                                    if (input_new_patient == user.FirstName && doctorRegion == user.UserStatus)
                                    {
                                          matchedUsers.Add(user);
                                    }
                              }
                              if (matchedUsers.Count > 0)
                              {
                                    Console.Clear();
                                    Console.WriteLine($"\n----- Users {input_new_patient} ------");
                                    found = true;
                                    foreach (IUser matched in matchedUsers)
                                    {
                                          Console.WriteLine($"Patient {matched.FirstName} {matched.LastName} {matched.Username} {matched.UserStatus}");
                                    }
                                    Console.WriteLine("Lastname: ");
                                    string? input_lastname = Console.ReadLine();
                                     List<IUser> matchedUsersLastname = new();
                                    foreach (IUser matched in matchedUsers)
                                    {
                                          if (input_lastname == matched.LastName) //SKA VARA MATCHED.LASTNAME
                                          {
                                                Console.Clear();
                                                matchedUsersLastname.Add(matched);
                                                for (int i = 1; i <= matchedUsersLastname.Count; ++i)
                                                {
                                                      Console.WriteLine($"Patient [{i}] {matched.FirstName} {matched.LastName} {matched.Username} {matched.UserStatus}");
                                                }
                                          }
                                    }
                                    Console.WriteLine("Is this the right patient");
                                    Console.WriteLine("[A] accept | [D] denie");
                                    ConsoleKeyInfo key2 = Console.ReadKey(true);
                                    switch (key2.KeyChar)
                                    {
                                          case 'A':
                                          case 'a':
                                                Console.WriteLine("MAKE A JOURNAL TO PATIENT");
                                                Console.WriteLine("Title: ");

                                                Console.WriteLine("Description: ");

                                                Console.WriteLine("Medication: ");

                                                Console.WriteLine("Date");

                                                //.Add JOURNAL SPARA TILL LISTA.
                                                break;
                                          case 'D':
                                          case 'd':
                                                found = false;
                                                break;
                                          default:
                                                Console.WriteLine("Unvalid option");
                                                break;
                                    }
                              }

                              if (!found)
                              {
                                    Console.WriteLine("NAMN EJ MATCHAT, KÖR DENNA SCOPE");
                                    Console.Clear();
                                    Console.WriteLine($"Patient name: {input_new_patient} ");
                                    string? name = input_new_patient;
                                    Console.WriteLine($"Patient lastname:");
                                    string? lastname = Console.ReadLine();
                                    Console.WriteLine("Patient username: ");
                                    string? username = Console.ReadLine();
                                    Console.WriteLine("Patient password: ");
                                    string? _password = Console.ReadLine();
                                    Console.WriteLine($"Patient reigon set to your reigon {doctorRegion} ");
                                    Patient newPatient = new Patient(name, lastname, username, _password, doctorRegion);
                                    users.Add(newPatient);
                                    userSystem.SaveUser(users);
                                    users = userSystem.LoadUser();//efter jag kört denna loadar jag den nya listan, eftersom jag eventuellt skapat en ny användare.
                              }
                        }
                        break;
                  case '2':
                        break;
                  default:
                        break;
            }
      }
}


