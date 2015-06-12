using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiers.Core;
using Tiers.Service;

namespace Tiers.WebConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                System.Console.WriteLine("Getting random user w/sensitive data from Service Layer:\r\n");

                var u = new UserService().Get(new Random().Next(5) + 1);
                System.Console.WriteLine(u.ID + "," + u.Name + "," + u.Data.ToString("0.##"));

                System.Console.WriteLine("\r\nGetting data from Service Layer:\r\n");

                var users = new UserService().GetAll();

                if (!String.IsNullOrEmpty(users.ToString()))
                {
                    foreach (UserDTO user in users.ToList())
                    {
                        System.Console.WriteLine(user.ID + "," + user.Name + "," + user.Data.ToString("0.##"));
                    }
                }
                else
                {
                    System.Console.WriteLine("No data found!\r\n");
                }

                System.Console.WriteLine("\r\nGetting data from WebApi:\r\n");
                
                // Use shared service WebApi client: UserApiClient
                UserWebApiClient client = new UserWebApiClient();

                var apiUsers = client.Get();

                if (!String.IsNullOrEmpty(apiUsers.ToString()))
                {
                    System.Console.WriteLine(apiUsers.ToString());
                }
                else
                {
                    System.Console.WriteLine("No data found!");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("An Exception Occured: " + ex.Message);
            }

            System.Console.WriteLine("\r\nPress enter to exit...");
            System.Console.ReadLine();
        }
    }
}
