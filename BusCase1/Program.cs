using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stringlocation;

namespace BusCase1
{
    class Program
    {
        static void Main(string[] args)
        {

            


            Console.Write("Enter a number less than 10000 : ");
            double num =Convert.ToDouble( Console.ReadLine());
            string word = num.ToString();

            string point = ".";

            int position = stringposition.InString(word, point);
            int lenofnum = word.Length;

            
            string cent = "";
            string dollar = "";
            int c=0;

            
            Console.WriteLine(position);
            if (position != -1)
            {
                cent = word.Substring(position + 1, lenofnum - (position + 1));
                if (cent.Length == 1)
                {
                    cent = cent + "0";
                }
                c = Convert.ToInt32(cent);
                dollar = word.Substring(0, position);
            }
            else
            {
                dollar = word;
            }


            int d = Convert.ToInt32(dollar);

            int e = (d % 1000) % 100;

            Console.WriteLine(d);


            Console.WriteLine(c);

            ConvertToWord w = new ConvertToWord();
            string NumToWord = w.NumToDollarWord(d);
            string NumToWordbase10 = w.numtowordbase10(e);
            string NumToCent = w.numtowordbase10(c);

            if (NumToWord != "" && NumToCent != "" && NumToWordbase10 != "")
            {
                Console.WriteLine("Dollar {0} and {1} and Cent {2} only", NumToWord, NumToWordbase10, NumToCent);
            }
            else if (NumToWord != "" && NumToCent != "")
            {
                Console.WriteLine("Dollar {0} and Cent {1} only ", NumToWord, NumToCent);
            }
            else if (NumToWord != "")
            {
                Console.WriteLine("Dollar {0} and {1} only ", NumToWord, NumToWordbase10);
            }
            else if (NumToWordbase10 != "" && NumToCent != "")
            {
                Console.WriteLine("Dollar {0} and Cent {1} only", NumToWordbase10, NumToCent);
            }
            else if (NumToCent != "")
            {
                Console.WriteLine("Cent {0} only", NumToCent);
            }
            else
            {
                Console.WriteLine("Dollar {0} only", NumToWordbase10);
            }












        }

        class ConvertToWord
        {
            
            string[] a = new string[9] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] b = new string[9] { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] c = new string[9] { "ten", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninty" };

            public string NumToDollarWord(int num)
            {
                string res1 = "";
                int mod1 = num % 1000;
                
                for (int i = 0; i < 10; i++)
                {
                    
                    if (num / 1000 == i+1)
                    {
                        res1 = a[i] + " thousand ";
                        
                        break;
                    }

                    
                }
                for (int i = 0; i < 10; i++)
                {
                    if (mod1 / 100 == i + 1)
                    {
                        res1 += a[i] + " hundred ";
                        break;
                    }
                }

                
              

                return res1;
              
            }

            public string numtowordbase10(int num)
            {


                string res2 = "";

                int c1 = 0;
                int c3 = 0;
                for (int i = 11; i < 20; i++)
                {

                    if (num == i)
                    {

                        res2 += b[c1];

                        break;
                    }
                    else if (num / 10 == c1 + 1 && num % 10 == 0)
                    {
                        res2 += c[c1];
                        break;
                    }
                    else if (num / 10 == c1 + 2 && num%10!=0)
                    {
                        int c2 = 0;
                        res2 += c[c1 + 1];
                        for (int j = 0; j < 10; j++)
                        {
                            if (num % 10 == c2 + 1)
                            {
                                res2 +=" " +a[c2];
                                break;
                            }
                            c2++;
                        }
                    }
                    else if (num % 10 == c3 + 1 && num/10==0)
                    {
                        res2 +=a[c3];
                        break;
                    }
                    
                    c1++;
                    c3++;
                    
                    
                    
                }

                return res2;
            }

           
            

            

        }
    }
}
