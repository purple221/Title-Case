using System;

namespace TitleCase
{
    class Program
    {
        static void Main(string[] args)
        {
            //assigning variables and arrays
            string title, notwant;
            string[] arrayt, arraynotwant;

            Method1(out title, out arrayt, out notwant, out arraynotwant); //method to ask user for input and converts them into strings
            string output = "";
            try
            {
                if (title != "") //if title isn't empty
                {
                    if (notwant == "")
                    {
                        output = Method2(arrayt, output); //method for processing input if the user wants to caplitalize all words
                    }
                    else
                    {
                        output = Method3(arrayt, arraynotwant, output); //method if the user wants certain words to not be capitalized
                    }
                    output.Trim(); //trim the end of the output so that the output doesn't have a space at the end, doesn't really matter but whatever
                    Console.WriteLine(output);
                }
                else //if title is empty
                {
                    Console.WriteLine("You didn't input anything");
                }
            }
            catch
            {
                Console.WriteLine("Please follow the instructions");
            }
        }

        private static void Method1(out string title, out string[] arrayt, out string notwant, out string[] arraynotwant)
        {
            Console.WriteLine("Hey bro, I need a title. Do not put space at the end of the title."); //asking for title
            title = Console.ReadLine();
            arrayt = title.ToLower().Split(" ");
            Console.WriteLine("Hey buddy, I need some words that you don't want to capitalitze in the title. Seperate them with a space. Press enter if you don't have any. (First word will always be captalized in a sentence!"); //asking for word to not cap
            notwant = Console.ReadLine();
            arraynotwant = notwant.ToLower().Split(" ");
        }

        private static string Method2(string[] arrayt, string output)
        {
            foreach (string c in arrayt)
            {
                string a = char.ToUpper(c[0]).ToString() + c.Substring(1, c.Length - 1); //converting to first letter uppercased
                output += a + " ";
            }
            return output;
        }

        private static string Method3(string[] arrayt, string[] arraynotwant, string output)
        {
            output += char.ToUpper(arrayt[0][0]).ToString() + arrayt[0].Substring(1, arrayt[0].Length - 1) + " "; //making the first letter always capitalized
            for (int i = 1; i < arrayt.Length; i++)
            {
                if (CheckArray(arraynotwant, arrayt[i])) //method to check if the string appears in the array
                {
                    output += arrayt[i] + " "; //if the word was indicated by the user to not be capitalized
                }
                else
                {
                    string a = char.ToUpper(arrayt[i][0]).ToString() + arrayt[i].Substring(1, arrayt[i].Length - 1); //converting to first letter uppercased
                    output += a + " ";
                }
            }
            return output;
        }

        public static bool CheckArray(string[] ar, string s1)
        {
            foreach (string s in ar)
            {
                if (s == s1)
                {
                    return true;  //string found in array
                }
            }
            return false;
        }
    }
}
