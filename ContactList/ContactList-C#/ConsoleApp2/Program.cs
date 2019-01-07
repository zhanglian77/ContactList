using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public IList<string> names = new List<string>();
        internal Dictionary<string, Contact> Record { get; set; } = new Dictionary<string, Contact>();


        static void Main(string[] args)
        {
            Program p = new Program();
            loadData(p.Record, p.names);
            show(p.Record, p.names);
            begin(p.Record, p.names);
            Console.ReadKey();
        }

        public static void loadData(Dictionary<String, Contact> r, IList<string> n)
        {
            string[] a = File.ReadAllLines(@"contact.txt", Encoding.Default);
            for (int i = 0; i < a.Length; i++)
            {
                string[] b = a[i].Split(new String[] { " " }, StringSplitOptions.None);
                string name = b[0];
                string number = b[1];
                string email = b[2];
                Contact c = new Contact();
                c.Number = number;
                c.Email = email;
                r.Add(name, c);
                n.Add(name);
            }
        }

        public static void add(Dictionary<String, Contact> r, IList<string> n)
        {
            Console.WriteLine("Add Contact ========>");
            Console.WriteLine("What is the contact name?");
            string name = Console.ReadLine();
                                 
            if (name == "" || name == " ")
            {
                Console.WriteLine("Contact name can not be empty.");
                add(r, n);
            }

            else
            {
                Console.WriteLine("What is the tel number?");
                string number = Console.ReadLine();
                Console.WriteLine("What is the email address?");
                string email = Console.ReadLine();
                Contact c = new Contact();
                c.Number = number;
                c.Email = email;
                try
                {
                    n.Add(name);
                    r.Add(name, c);
                }
                catch (System.ArgumentException)
                {
                    Console.WriteLine("The contact is already exist.");
                    add(r, n);
                }
                Console.WriteLine("Add Contact suceed.");
                }
        }

        public static void remove(Dictionary<String, Contact> r, IList<string> n)
        {
            Console.WriteLine("Remove Contact ========>");

            Console.WriteLine("Which one do you want to remove?");
            foreach (string name in n)
            {
                Console.WriteLine(name);
            }

            string s = Console.ReadLine();
            if (n.Contains(s))
            {
                Console.WriteLine("Removed Contact: " + s);
                n.Remove(s);
                r.Remove(s);
            }
            else
            {
                Console.WriteLine("This contact does not exist.");
            }
        }

        public static void update(Dictionary<String, Contact> r, IList<string> n)
        {
            Console.WriteLine("Update Contact ========>");
            Console.WriteLine("Which one do you want to update?");
            foreach (string name in n)
            {
                Console.WriteLine(name);
            }
            string s = Console.ReadLine();
            if (n.Contains(s))
            {
                Console.WriteLine("What is the new tel-number?");
                r[s].Number = Console.ReadLine();
                Console.WriteLine("What is the new email?");
                r[s].Email = Console.ReadLine();
                Console.WriteLine("Updated Contact " + s + "." + "The new contact information is : " + " Name: " + s + " Tel-Number: " + r[s].Number + " Email: " + r[s].Email);
            }
            else
            {
                Console.WriteLine("This contact does not exist.");
            }
        }

        public static void search(Dictionary<String, Contact> r, IList<string> n)
        {
            Console.WriteLine("Search Contact ========>");
            Console.WriteLine("Which contact do you want to search?");

            string s = Console.ReadLine();
            if (n.Contains(s))
            {
                Console.WriteLine("The contact information is : " + " Name: " + s + " Tel-Number: " + r[s].Number + " Email: " + r[s].Email);
            }

            else
            {
                Console.WriteLine("This contact does not exist.");
            }

        }

        public static void quit(Dictionary<String, Contact> r, IList<string> n)
        {
            Console.WriteLine("Quit ========>");
            Console.WriteLine("Do you want to quit Contact List? Y/N");
            if (Console.ReadLine().Equals("Y") || Console.ReadLine().Equals("y"))
            {
                save(r, n);
                Console.WriteLine("Bye bye !");
                Environment.Exit(0);
            }
            else
            {
                begin(r, n);
            }
        }

        public static void save(Dictionary<String, Contact> r, IList<string> n)
        {
            FileStream fs = new FileStream(@"contact.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);

            for (int i = 0; i < n.Count; i++)
            {
                sw.WriteLine(string.Format("{0} {1} {2} ", n[i], r[n[i]].Number, r[n[i]].Email));
            }
            sw.Close();
            fs.Close();

            Console.WriteLine("Changes saved.");

        }

        public static void show(Dictionary<String, Contact> r, IList<string> n)
        {
            Console.WriteLine("Contact List" + "\n" + "++++++++++++++++++++++++++++++++++++++++");
            for (int i = 0; i < n.Count; i++)
            {
                Console.WriteLine(i + 1 + ":" + " Name: " + n[i] + " Tel-Number: " + r[n[i]].Number + " Email: " + r[n[i]].Email);
            }
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++");
        }

        public static void begin(Dictionary<String, Contact> r, IList<string> n)
        {
            Console.WriteLine("What do you want to do?" + "\n" + "1: Add" + "\n" + "2: Remove" + "\n" + "3: Update" + "\n" + "4: Search" + "\n" + "5: List" + "\n" + "6: Save" + "\n" + "7: Quit");
            string op = Console.ReadLine();
            switch (op)
            {
                case "1":
                case "Add":
                case "add":
                    add(r, n);
                    break;
                case "2":
                case "Remove":
                case "remove":
                    remove(r, n);
                    break;
                case "3":
                case "Update":
                case "update":
                    update(r, n);
                    break;
                case "4":
                case "Search":
                case "search":
                    search(r, n);
                    break;
                case "5":
                case "List":
                case "list":
                    show(r, n);
                    break;
                case "6":
                case "Save":
                case "save":
                    save(r, n);
                    break;
                case "7":
                case "Quit":
                case "quit":
                    quit(r, n);
                    break;
            }
            begin(r, n);
        }
    }

    class Contact
    {
        internal string number;
        internal string email;

        public string Number { get => number; set => number = value; }
        public string Email { get => email; set => email = value; }

    }
}
