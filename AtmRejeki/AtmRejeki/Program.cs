using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmRejeki
{
    public class Program
    {
        static void Main(string[] args)
        { 
            int saldo = 5000000;
            List<string> jumlahTabung = new List<string>();
            List<string> jumlahTarik = new List<string>();
            string user = "jona";
            string pass = "123";
            
            
            bool lanjut = true;
            Console.WriteLine("=============================================");
            Console.WriteLine("\tSELAMAT DATANG DI ATM REJEKI");
            Console.WriteLine("=============================================");

            Login(user, pass, lanjut);
            Console.WriteLine(lanjut);
            string kosongan = Console.ReadLine();
            Console.Clear();

            while (lanjut)
            {
                int inputUser;
                Console.WriteLine("============= ATM REJEKI =============");
                Console.WriteLine("1. Tabung Uang");
                Console.WriteLine("2. Tarik Uang");
                Console.WriteLine("3. Informasi");
                Console.WriteLine("4. Exit");
                Console.Write("Masukan pilihan : ");
                inputUser = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (inputUser)
                {
                    case 1:
                        Console.WriteLine("=========== TABUNG UANG ==============");
                        Console.Write("Masukan Jumlah uang : ");
                        int tabung = Convert.ToInt32(Console.ReadLine());
                        saldo = TabungUang(saldo, tabung);
                        Console.WriteLine($"Saldo : {saldo}");
                        jumlahTabung.Add("*");
                        kosongan = Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("============ TARIK UANG ===============");
                        Console.Write("Masukan Jumlah uang : ");
                        int tarik = Convert.ToInt32(Console.ReadLine());
                        saldo = TarikUang(saldo, tarik);
                        Console.WriteLine($"Saldo : {saldo}");
                        jumlahTarik.Add("*");
                        kosongan = Console.ReadLine();
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("============== INFORMASI ================");
                        informasi(user, pass, saldo, jumlahTabung, jumlahTarik);
                        kosongan = Console.ReadLine();
                        Console.Clear();
                        break;
                    case 4:
                        lanjut = false;
                        break;
                }
            }

        }

        static void Login(string user, string pass, bool lanjut)
        {
            // maksimal kesalahan input 2x
            for (int x = 0; x < 2; x++)
            {
                Console.Write("Masukan Username : ");
                string userName = Console.ReadLine();
                Console.Write("Masukan Password : ");
                string password = Console.ReadLine();

                if (userName == user && password == pass)
                {
                    Console.WriteLine();
                    Console.WriteLine($"SELAMAT DATANG {user}");
                    
                    break;
                }
                else if (userName == user && password != pass)
                {
                    Console.WriteLine("Password anda salah");
                }
                else if (userName != user && password == pass)
                {
                    Console.WriteLine("Username anda salah");
                }
                else
                {
                    Console.WriteLine("Username dan Password anda salah");
                }
                lanjut = !lanjut;
            }
        }

        static int TabungUang(int saldo, int tabung)
        {
            saldo = saldo + tabung;
            return saldo;
        }
        
        static int TarikUang(int saldo, int tarik)
        {
            saldo = saldo - tarik;
            return saldo;
        }
        static void informasi(string user, string pass, int saldo, List<string> n, List<string> m)
        {
            Console.WriteLine($"Username : {user}");
            Console.WriteLine($"Password : {pass}");
            Console.WriteLine($"Saldo : {saldo}");
            Console.WriteLine($"Jumlah berapa kali anda melakukan tabung uang : {n.Count}");
            Console.WriteLine($"Jumlah berapa kali anda melakukan tarik uang  : {m.Count}");
        }

    }
}
