using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    internal class PrintText
    {
        public static string DefaultSwitch() {
            return "Unknown policy type";
        }
        public static void FirstText() 
        {
            Console.WriteLine("Starting rate.");
            Console.WriteLine("Loading policy");
        }
        public static void SecondText(string policyName)
        {
            Console.WriteLine($"Rating {policyName} policy...\nValidating policy");
        }
        public static string LastText() {
            return "Rating completed.";
        }
        public static string Auto_Alert() {

            return "Auto policy must specify Make";
            
        }
        public static string Land_Alert(int valor)
        {
            if (valor == 1)
            {
                return "Land policy must specify Bond Amount and Valuation.";
            }
            else { return "Insufficient bond amount."; }

        }
        public static string Life_Alert(int valor)
        {
            if (valor == 1)
            {
                return "Life policy must include Date of Birth.";
            }
            if (valor == 2) {
                return "Centenarians are not eligible for coverage.";
            }
            else { return "Life policy must include an Amount."; }



        }
    }
}
