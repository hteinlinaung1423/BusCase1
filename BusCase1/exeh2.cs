using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusCase1

{
    class exeh2
    {
        static void Main()
        {
            Console.Write("Enter a string : ");

            string s1 = Console.ReadLine();
            s1 = s1.ToUpper();


            Console.Write("Enter a word :");

            string s2 = Console.ReadLine();
            s2 = s2.ToUpper();

            int eql = InString(s1, s2);

            if (eql == -1)
            {
                Console.WriteLine("-1");
            }
            else
            {

                Console.WriteLine(eql);

            }

        }

        public static int InString(string s1, string s2)
        {
            int eql = -1;





            for (int i = 0; i <= s1.Length - s2.Length; i++)
            {
                string a = s1.Substring(i, s2.Length);


                if (a == s2)
                {
                    eql = i;
                    break;
                }
            }


            return eql;

        }
    }
}