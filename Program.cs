using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region TC No Validation
            {
                Console.Write("Enter your TC number: ");
                string tcno = Console.ReadLine();
                bool checkIfValid = Validate(tcno);
                if (checkIfValid)
                {
                    Console.WriteLine("TC number is valid.");
                }
                else
                {
                    Console.WriteLine("TC number is invalid.");
                }
            }
            #endregion
        }
        public static bool Validate(string tckno)
        {
        //Detailed explanation of this algorithm:
            //https://seyler.eksisozluk.com/tc-kimlik-numaralarindaki-inanilmaz-algoritma (you better use translate)
            bool valid = true;
            long ATCNO, BTCNO, TcNo;
            long Q1, Q2;
      
            long[] C = new long[9];
            Int64.TryParse(tckno, out TcNo);
            if (string.IsNullOrWhiteSpace(tckno))
            {
                valid = false;
                //("TC/Passport No have to be given.");
            }
            else if (tckno.Length != 11)
            {
                valid = false;
                //("TC No have to be 11 characters long.");
            }
            else if (tckno.Length == 11)
            {
                ATCNO = TcNo / 100;
                BTCNO = TcNo / 100;
                long oddNumbers = 0, evenNumbers = 0;
                for (int i = 0; i < C.Length; i++)
                {
                    C[i] = ATCNO % 10;
                    ATCNO /= 10;
                    if (i % 2 == 0)
                    {
                        oddNumbers += C[i];
                    }
                    else
                    {
                        evenNumbers += C[i];
                    }
                }
                Q1 = (10 - (((oddNumbers * 3) + evenNumbers) % 10)) % 10;
                Q2 = (10 - ((((evenNumbers + Q1) * 3) + oddNumbers) % 10)) % 10;

                valid = (BTCNO * 100) + (Q1 * 10) + Q2 == TcNo;
            }
            return valid;
        }
    }
}
