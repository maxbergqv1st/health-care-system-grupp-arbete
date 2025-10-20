namespace App;

public class SaveJournalSystem
{
      public void SaveJournal(List<Journal> journals)
      {
            List<string> lines = new();
            foreach (Journal journal in journals)
            {
                  lines.Add($"{journal.OwnerUsername},{journal.FirstName},{journal.LastName},{journal.Description},{journal.Document},{journal.Date},{journal.Location}");
            }
            File.WriteAllLines("journal.txt", lines);
      }
      public List<Journal> LoadJournal()
      {
            List<Journal> journals = new();
            if (!File.Exists("journal.txt"))
            {
                  return journals;
            }
            string[] lines = File.ReadAllLines("journal.txt");
            foreach (string line in lines)
            {
                  string[] split = line.Split(",");
                  if (split.Length == 7)
                  {
                        string owner = split[0];
                        string firstname = split[1];
                        string lastname = split[2];
                        string description = split[3];
                        string document = split[4];
                        string date = split[5];
                        string location = split[6];
                  
                  Journal journal = new Journal(owner, firstname, lastname, description, document, date, location);
                        journals.Add(journal);
                  }
            }
            return journals;
      }
}