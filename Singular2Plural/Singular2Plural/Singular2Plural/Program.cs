using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singular2Plural
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get user input noun and validate
            string singularNoun;
            bool isValid;
            do
            {
                isValid = true;
                
                Console.WriteLine("Enter a noun: ");
                singularNoun = Console.ReadLine();
                if (singularNoun.Length < 2)
                {
                    isValid = false;
                    Console.WriteLine("Invalid Input");
                }
            } while (isValid == false);
           

            //Pluralize the noun
            Pluralize pluralize = new Pluralize(singularNoun);
            string pluralNoun = pluralize.Plural;

            //Print plural version of the noun to console
            Console.WriteLine("The plural of {0} is {1}", singularNoun, pluralNoun);

            //Have user press a key when they're ready to exit the program
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
