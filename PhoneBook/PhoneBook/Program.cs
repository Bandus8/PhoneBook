using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace PhoneBook
{


class Program
{
    struct Személy
    {
        public string Név;
        public string Cím;
        public string Apja;
        public string Anyja;
        public long Telefon;
        public string Nem;
        public string Email;
        public string Azon;
    }

    static void Main()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Clear();
        Start();
    }

    static void Start()
    {
        Menu();
    }

    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("\t\t**********WELCOME TO PHONEBOOK*************");
        Console.WriteLine("\n\n\t\t\t MENU\t\t\n\n");
        Console.WriteLine("\t1. Add New \t2. List \t3. Exit \n\t4. Modify \t5. Search\t6. Delete");

        switch (Console.ReadKey().KeyChar)
        {
            case '1':
                AddRecord();
                break;
            case '2':
                ListRecord();
                break;
            case '3':
                Environment.Exit(0);
                break;
            case '4':
                ModifyRecord();
                break;
            case '5':
                SearchRecord();
                break;
            case '6':
                DeleteRecord();
                break;
            default:
                Console.Clear();
                Console.WriteLine("\nEnter 1 to 6 only");
                Console.WriteLine("\n Enter any key");
                Console.ReadKey();
                Menu();
                break;
        }
    }

    static void AddRecord()
    {
        Console.Clear();
        Személy p;

        Console.WriteLine("\n Enter name: ");
        p.Név = Console.ReadLine();
        Console.WriteLine("\nEnter the address: ");
        p.Cím = Console.ReadLine();
        Console.WriteLine("\nEnter father name: ");
        p.Apja = Console.ReadLine();
        Console.WriteLine("\nEnter mother name: ");
        p.Anyja = Console.ReadLine();
        Console.WriteLine("\nEnter phone no.: ");
        p.Telefon = long.Parse(Console.ReadLine());
        Console.WriteLine("Enter sex: ");
        p.Nem = Console.ReadLine();
        Console.WriteLine("\nEnter e-mail: ");
        p.Email = Console.ReadLine();
        Console.WriteLine("\nEnter citizen no: ");
        p.Azon = Console.ReadLine();

        using (FileStream fs = new FileStream("project.dat", FileMode.Append))
        using (BinaryWriter writer = new BinaryWriter(fs))
        {
            writer.Write(p.Név);
            writer.Write(p.Cím);
            writer.Write(p.Apja);
            writer.Write(p.Anyja);
            writer.Write(p.Telefon);
            writer.Write(p.Nem);
            writer.Write(p.Email);
            writer.Write(p.Azon);
        }

        Console.WriteLine("\nRecord saved");
        Console.WriteLine("\n\nEnter any key");
        Console.ReadKey();
        Console.Clear();
        Menu();
    }

    static void ListRecord()
    {
        Console.Clear();
        if (!File.Exists("project.dat"))
        {
            Console.WriteLine("\nFile opening error in listing:");
            Environment.Exit(1);
        }

        using (FileStream fs = new FileStream("project.dat", FileMode.Open))
        using (BinaryReader reader = new BinaryReader(fs))
        {
            while (fs.Position < fs.Length)
            {
                Személy p;
                p.Név = reader.ReadString();
                p.Cím = reader.ReadString();
                p.Apja = reader.ReadString();
                p.Anyja = reader.ReadString();
                p.Telefon = reader.ReadInt64();
                p.Nem = reader.ReadString();
                p.Email = reader.ReadString();
                p.Azon = reader.ReadString();

                Console.WriteLine("\n\n\n YOUR RECORD IS\n\n ");
                Console.WriteLine($"Name: {p.Név}\nAddress: {p.Cím}\nFather name: {p.Apja}\nMother name: {p.Anyja}\nMobile no: {p.Telefon}\nSex: {p.Nem}\nE-mail: {p.Email}\nCitizen no: {p.Azon}");
                Console.ReadKey();
                Console.Clear();
            }
        }

        Console.WriteLine("\n Enter any key");
        Console.ReadKey();
        Console.Clear();
        Menu();
    }

    static void SearchRecord()
    {
        Console.Clear();
        if (!File.Exists("project.dat"))
        {
            Console.WriteLine("\nError in opening");
            Environment.Exit(1);
        }

        Console.WriteLine("\nEnter name of person to search: ");
        string name = Console.ReadLine();

        bool found = false;

        using (FileStream fs = new FileStream("project.dat", FileMode.Open))
        using (BinaryReader reader = new BinaryReader(fs))
        {
            while (fs.Position < fs.Length)
            {
                Személy p;
                p.Név = reader.ReadString();
                p.Cím = reader.ReadString();
                p.Apja = reader.ReadString();
                p.Anyja = reader.ReadString();
                p.Telefon = reader.ReadInt64();
                p.Nem = reader.ReadString();
                p.Email = reader.ReadString();
                p.Azon = reader.ReadString();

                if (p.Név.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"\n\tDetail Information About {name}");
                    Console.WriteLine($"Name: {p.Név}\nAddress: {p.Cím}\nFather name: {p.Apja}\nMother name: {p.Anyja}\nMobile no: {p.Telefon}\nSex: {p.Nem}\nEmail: {p.Email}\nCitizen no: {p.Azon}");
                    found = true;
                    break;
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("Record not found");
        }

        Console.WriteLine("\n Enter any key");
        Console.ReadKey();
        Console.Clear();
        Menu();
    }

    static void DeleteRecord()
    {
        Console.Clear();
        if (!File.Exists("project.dat"))
        {
            Console.WriteLine("CONTACT'S DATA NOT ADDED YET.");
            Console.ReadKey();
            Console.Clear();
            Menu();
            return;
        }

        Console.WriteLine("Enter CONTACT'S NAME: ");
        string name = Console.ReadLine();

        bool flag = false;

        using (FileStream fs = new FileStream("project.dat", FileMode.Open))
        using (FileStream ft = new FileStream("temp.dat", FileMode.Create))
        using (BinaryReader reader = new BinaryReader(fs))
        using (BinaryWriter writer = new BinaryWriter(ft))
        {
            while (fs.Position < fs.Length)
            {
                Személy p;
                p.Név = reader.ReadString();
                p.Cím = reader.ReadString();
                p.Apja = reader.ReadString();
                p.Anyja = reader.ReadString();
                p.Telefon = reader.ReadInt64();
                p.Nem = reader.ReadString();
                p.Email = reader.ReadString();
                p.Azon = reader.ReadString();

                if (!p.Név.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    writer.Write(p.Név);
                    writer.Write(p.Cím);
                    writer.Write(p.Apja);
                    writer.Write(p.Anyja);
                    writer.Write(p.Telefon);
                    writer.Write(p.Nem);
                    writer.Write(p.Email);
                    writer.Write(p.Azon);
                }
                else
                {
                    flag = true;
                }
            }
        }

        if (!flag)
        {
            Console.WriteLine("NO CONTACT'S RECORD TO DELETE.");
            File.Delete("temp.dat");
        }
        else
        {
            File.Delete("project.dat");
            File.Move("temp.dat", "project.dat");
            Console.WriteLine("RECORD DELETED SUCCESSFULLY.");
        }

        Console.WriteLine("\n Enter any key");
        Console.ReadKey();
        Console.Clear();
        Menu();
    }

    static void ModifyRecord()
    {
        Console.Clear();
        if (!File.Exists("project.dat"))
        {
            Console.WriteLine("CONTACT'S DATA NOT ADDED YET.");
            Console.ReadKey();
            Console.Clear();
            Menu();
            return;
        }

        Console.WriteLine("\nEnter CONTACT'S NAME TO MODIFY:\n");
        string name = Console.ReadLine();

        bool flag = false;

        using (FileStream fs = new FileStream("project.dat", FileMode.Open, FileAccess.ReadWrite))
        using (BinaryReader reader = new BinaryReader(fs))
        using (BinaryWriter writer = new BinaryWriter(fs))
        {
            while (fs.Position < fs.Length)
            {
                long position = fs.Position;

                Személy p;
                p.Név = reader.ReadString();
                p.Cím = reader.ReadString();
                p.Apja = reader.ReadString();
                p.Anyja = reader.ReadString();
                p.Telefon = reader.ReadInt64();
                p.Nem = reader.ReadString();
                p.Email = reader.ReadString();
                p.Azon = reader.ReadString();

                if (p.Név.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\n Enter new name: ");
                    p.Név = Console.ReadLine();
                    Console.WriteLine("\nEnter the address: ");
                    p.Cím = Console.ReadLine();
                    Console.WriteLine("\nEnter father name: ");
                    p.Apja = Console.ReadLine();
                    Console.WriteLine("\nEnter mother name: ");
                    p.Anyja = Console.ReadLine();
                    Console.WriteLine("\nEnter phone no: ");
                    p.Telefon = long.Parse(Console.ReadLine());
                    Console.WriteLine("\nEnter sex: ");
                    p.Nem = Console.ReadLine();
                    Console.WriteLine("\nEnter e-mail: ");
                    p.Email = Console.ReadLine();
                    Console.WriteLine("\nEnter citizen no: ");
                    p.Azon = Console.ReadLine();

                    fs.Seek(position, SeekOrigin.Begin);
                    writer.Write(p.Név);
                    writer.Write(p.Cím);
                    writer.Write(p.Apja);
                    writer.Write(p.Anyja);
                    writer.Write(p.Telefon);
                    writer.Write(p.Nem);
                    writer.Write(p.Email);
                    writer.Write(p.Azon);

                    flag = true;
                    Console.WriteLine("\nYour data is modified");
                    break;
                }
            }
        }

        if (!flag)
        {
            Console.WriteLine("\nData not found");
        }

        Console.WriteLine("\n Enter any key");
        Console.ReadKey();
        Console.Clear();
        Menu();
    }
}

}
