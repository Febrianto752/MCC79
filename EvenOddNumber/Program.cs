namespace EvenOddNumber
{
    public class Program
    {
        static void PrintMenu()
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("          MENU GANJIL GENAP            ");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("1. Cek Ganjil Genap");
            Console.WriteLine("2. Print Ganjil/Genap (dengan limit)");
            Console.WriteLine("3. Exit");
            Console.WriteLine("---------------------------------------\n");
        }

        static void PrintInvalidMessage()
        {
            Console.WriteLine("Invalid Input!!!");
        }

        static bool IsIntegerNumber(string bilangan)
        {
            bool isNumber;
            isNumber = int.TryParse(bilangan, out int _);

            return isNumber;
        }

        static bool IsPositiveNumber(string bilangan)
        {
            if (int.Parse(bilangan) < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static string EvenOddNumberCheck(string strBilangan)
        {
            int intBilangan = int.Parse(strBilangan);

            if (intBilangan % 2 == 0)
            {
                return "Genap";
            }
            else
            {
                return "Ganjil";
            }
        }

        static int[] GenerateEvenNumber(int limit)
        {
            int totalNumber = limit / 2;
            int[] evenNumbers = new int[totalNumber];

            int number = 2;
            for (int i = 0; i < totalNumber; i++)
            {
                evenNumbers[i] = number;
                number += 2;
            }

            return evenNumbers;
        }

        static void PrintEvenNumberToLimit(int limit)
        {
            Console.WriteLine($"Print bilangan 1 - {limit} : ");
            var evenNumbers = GenerateEvenNumber(limit);
            Console.WriteLine(String.Join(",", evenNumbers));
        }

        static int[] GenerateOddNumber(int limit)
        {
            int totalNumber = (limit / 2) + 1;
            int[] oddNumbers = new int[totalNumber];

            int number = 1;
            for (int i = 0; i < totalNumber; i++)
            {
                oddNumbers[i] = number;
                number += 2;
            }

            return oddNumbers;
        }

        static void PrintOddNumberToLimit(int limit)
        {
            Console.WriteLine($"Print bilangan 1 - {limit} : ");
            var oddNumbers = GenerateOddNumber(limit);
            Console.WriteLine(String.Join(",", oddNumbers));
        }

        static void Main(string[] args)
        {
            bool exit = false;
            string pilihan, bilangan;

            while (exit == false)
            {
                PrintMenu();
                Console.Write("Pilihan : ");
                pilihan = Console.ReadLine();

                switch (pilihan)
                {
                    case "1":
                        Console.Write("Masukan Bilangan yang ingin di cek : ");
                        bilangan = Console.ReadLine();

                        if (IsIntegerNumber(bilangan) && IsPositiveNumber(bilangan))
                        {
                            string result = EvenOddNumberCheck(bilangan);
                            Console.WriteLine(result);
                        }
                        else
                        {
                            PrintInvalidMessage();
                        }

                        break;
                    case "2":
                        string evenOrOdd;
                        string limit;
                        Console.Write("Pilih (Ganjil / Genap) : ");
                        evenOrOdd = Console.ReadLine();



                        if (evenOrOdd.ToLower() == "genap")
                        {
                            Console.Write("Masukan Limit : ");
                            limit = Console.ReadLine();



                            if (IsIntegerNumber(limit) && IsPositiveNumber(limit))
                            {
                                if (int.Parse(limit) % 2 == 0)
                                {
                                    PrintEvenNumberToLimit(int.Parse(limit));
                                }
                                else
                                {
                                    PrintInvalidMessage();
                                    break;
                                }
                            }
                            else
                            {
                                PrintInvalidMessage();
                                break;
                            }
                        }
                        else if (evenOrOdd.ToLower() == "ganjil")
                        {
                            Console.Write("Masukan Limit : ");
                            limit = Console.ReadLine();

                            if (IsIntegerNumber(limit) && IsPositiveNumber(limit))
                            {
                                if (int.Parse(limit) % 2 != 0)
                                {
                                    PrintOddNumberToLimit(int.Parse(limit));
                                }
                                else
                                {
                                    PrintInvalidMessage();
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Input limit tidak valid!!!");
                                break;
                            }
                        }
                        else
                        {
                            Console.Write("Masukan Limit : ");
                            limit = Console.ReadLine();
                            Console.WriteLine("Input pilihan tidak valid!!!");

                            break;
                        }

                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        PrintInvalidMessage();
                        break;
                }

                if (exit == false)
                {
                    Console.WriteLine("=======================================");
                    Console.Write("Tekan tombol enter untuk kembali ke menu utama! ");
                    Console.ReadLine();
                    Console.Clear();
                }

            }
        }
    }
}