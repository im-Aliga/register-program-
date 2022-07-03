using System;
using System.Collections.Generic;

namespace register_proqram
{
    internal class Program
    {

        private static List<Person> people1 = new List<Person>();



        static void Main(string[] args)
        {
            Console.WriteLine("Register");
            Console.WriteLine("Login");
            Console.WriteLine("show");
            while (true)
            {
                Console.WriteLine();
                Console.Write("entrer command:");
                string command = Console.ReadLine();

                if (command == "Register")
                {
                    Console.WriteLine("please enter name");
                    string name = Console.ReadLine();
                    Console.WriteLine("please enter lastname");
                    string lastname = Console.ReadLine();
                    Console.WriteLine("please enter email");
                    string email = Console.ReadLine();
                    Console.WriteLine("please enter password");
                    string password = Console.ReadLine();
                    Console.WriteLine("please try again");
                    string secondpassword = Console.ReadLine();

                    AddUser(name, lastname, email, password, secondpassword);

                }
                else if (command == "Login")
                {
                    Console.WriteLine("please enter email");
                    string loginemail = Console.ReadLine();

                    Console.WriteLine("please enter password");
                    string password = Console.ReadLine();

                    Loginvalidator login = new Loginvalidator(loginemail, password);

                    if (login.IsPasswordCorrect(password) & login.IsEmailCorrect(loginemail))
                    {
                        Console.Write("Welcome   ");
                        foreach(Person person in people1)
                        {
                            if(person.Email==loginemail)
                            {
                                Console.WriteLine(person.GetInfo());
                            }
                                   
                        }
                        
                    }




                }
               







            }
        }

        static Person AddUser(string name, string lastname, string email, string password, string secondpassword)
        {
            Person person = new Person(name, lastname, email, password, secondpassword);

            people1.Add(person);


            return person;
        }


        class Person : Validator
        {


            public string Name { get; set; } = "ADMIN";
            public string Lastname { get; set; }
            public string Email { get; set; } = "@FOREXAMPLE.COM";
            public string Password { get; set; } = "11111111";
            public string Secondpassword { get; set; }


            public Person(string name, string lastname, string email, string password, string secondpassword)
            {
                if (IsNamecorrect(name) & IsLastnamecorrect(lastname) & IsEmailtext(email) & IsPasswordTrue(password, secondpassword) & IsEmailUnikal(email))
                {
                    Name = name;
                    Lastname = lastname;
                    Email = email;
                    Password = password;
                    Secondpassword = password;
                    Console.WriteLine("sisteme elave olundu");
                }


            }

            public  string  GetInfo()
            {
                return Name + "  " + Lastname ;
            }
        }
        class Validator
        {


            public static bool IstextLength(string text, int start, int end)
            {
                if (text.Length > start && text.Length < end)
                {
                    return true;
                }


                return false;


            }
            public bool IsNamecorrect(string name)
            {
                if (!IstextLength(name, 3, 30))
                {
                    Console.WriteLine("adi duzgun daxil edin");
                    return false;
                }
                return true;
            }
            public bool IsLastnamecorrect(string lastname)
            {
                if (!IstextLength(lastname, 3, 30))
                {
                    Console.WriteLine("soyadi duzgun daxil edin");
                    return false;

                }
                return true;
            }
            public static bool IsEmailtext(string text)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == '@')
                    {
                        return true;
                    }
                }

                Console.WriteLine("emaili duzgun daxil edin");
                return false;
            }
            public static bool IsPasswordTrue(string password, string passwordchecker)
            {
                if (passwordchecker == password)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("parolu duzgun daxil edin");
                    return false;
                }
            }
            public static bool IsEmailUnikal(string email)
            {
                for (int i = 0; i < people1.Count; i++)
                {
                    if (people1[i].Email == email)
                    {
                        Console.WriteLine("email movcuddur");
                        return false;
                    }
                }
                return true;
            }






        }
        class Loginvalidator
        {
            public string LoginEmail { get; set; }
            public string LoginPassword { get; set; }
            public Loginvalidator(string loginemail, string loginpassword)

            {
                if (IsEmailCorrect(loginemail) & IsPasswordCorrect(loginpassword))
                {
                    LoginEmail = loginemail;
                    LoginPassword = loginpassword;


                }
            }

            public bool IsEmailCorrect(string text)
            {
                for (int i = 0; i < people1.Count; i++)
                {
                    if (people1[i].Email == text)
                    {
                        return true;
                    }
                }
                Console.WriteLine("email is inkorrect");
                return false;
            }
            public bool IsPasswordCorrect(string text)
            {
                for (int i = 0; i < people1.Count; i++)
                {
                    if (people1[i].Password == text)
                    {
                        return true;
                    }
                }
                Console.WriteLine("password is incorrect");
                return false;
            }
        }
    }

}






























