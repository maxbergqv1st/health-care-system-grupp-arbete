using App;

bool running = true;
bool active_user = false;

while(running)
{
      if (!active_user)
      {
            Console.WriteLine("Login Page");
            Console.ReadLine();
      }
      else
      {
            Console.WriteLine("Logged in page");
            Console.ReadLine();
      }
}