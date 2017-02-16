using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusCase1

{
    class BusinessCase1
    {
        static string[] unitMap = new string[]{
            "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"
        };

        static string[] tyMap = new string[]{
            "Onety", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
        };

        static string[] teenMap = new string[]
        {
            "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
        };

        public static void Main()
        {
            Console.Write("Enter a number: ");
            string number = Console.ReadLine();

            Console.WriteLine(NumeralToWords(number));
        }

        static string NumeralToWords(string number)
        {
            if (number.Split('.').Length == 1) number += ".00";     //345 will become 345.00
            string[] dollarsAndCents = number.Split('.');
            string dollar = dollarsAndCents[0];

            dollar = dollar.PadLeft(4, '0');                        // 12 will become 0012 after padding
            char[] digits = dollar.ToCharArray();

            string numeralWord = "";

            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i] != '0')
                    switch (i)
                    {
                        case 0:             //Thousand Position
                            numeralWord += GetUnit(Convert.ToInt32(digits[i].ToString())) + " Thousand ";
                            break;
                        case 1:             //Hundred Position
                            numeralWord += GetUnit(Convert.ToInt32(digits[i].ToString())) + " Hundred ";
                            break;
                        case 2:             //Ten Position
                            numeralWord += "and ";
                            if (digits[i] == '1')           //because 10 to 19 is unique e.g. eleven, seventeen, twelve, ten
                            {
                                numeralWord += GetTeen(Convert.ToInt32(digits[i + 1].ToString())) + " ";
                                i++;            //skipping the next loop
                            }
                            else
                            {
                                numeralWord += GetTy(Convert.ToInt32(digits[i].ToString())) + " ";
                            }
                            break;
                        case 3:
                            if (numeralWord != "" && digits[i - 1] == '0') numeralWord += "and ";       //if the ten number is zero, putting the "And"
                            numeralWord += GetUnit(Convert.ToInt32(digits[i].ToString())) + " ";
                            break;
                    }
            }

            if (numeralWord != "")                  //adding Dollar to words if it is not empty
            {
                string temp = numeralWord;
                numeralWord = "Dollar " + temp;
            }

            string cent = dollarsAndCents[1];
            digits = cent.ToCharArray();

            if (numeralWord != "" && Convert.ToInt32(cent) != 0)
            {
                numeralWord += "and ";
            }

            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i] != '0')
                    switch (i)
                    {
                        case 0:
                            numeralWord += "Cents ";
                            if (digits[i] == '1')
                            {
                                numeralWord += GetTeen(Convert.ToInt32(digits[i + 1].ToString())) + " ";
                                i++;            //skipping the next loop
                            }
                            else
                            {
                                numeralWord += GetTy(Convert.ToInt32(digits[i].ToString())) + " ";
                            }
                            break;
                        case 1:
                            if (digits[i - 1] == '0') numeralWord += "Cents ";       //if ten number is zero
                            numeralWord += GetUnit(Convert.ToInt32(digits[i].ToString())) + " ";
                            break;
                    }
            }
            numeralWord += "only";
            return numeralWord;
        }

        static string GetUnit(int number)
        {
            string word = "";
            for (int i = 1; i <= unitMap.Length; i++)
            {
                if (number == i)
                {
                    word = unitMap[i - 1];
                    break;
                }
            }
            return word;
        }

        static string GetTy(int number)
        {
            string word = "";
            for (int i = 1; i <= tyMap.Length; i++)
            {
                if (number == i)
                {
                    word = tyMap[i - 1];
                    break;
                }
            }
            return word;
        }

        static string GetTeen(int number)
        {
            string word = "";
            for (int i = 0; i < teenMap.Length; i++)
            {
                if (number == i)
                {
                    word = teenMap[i];
                    break;
                }
            }
            return word;
        }
    }
}