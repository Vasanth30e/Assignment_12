using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Opeartion you want to perform");

            int choice = int.Parse(Console.ReadLine());

            switch(choice)
            {
                case 1:
                    //Mobile Number Extraction
                    Console.WriteLine("Enter the Mobile Number:");
                    string inputNumber = Console.ReadLine();
                    List<string> mobileNumbers = ExtractMobileNumbers(inputNumber);

                    if (mobileNumbers.Count == 0)
                    {
                        Console.WriteLine("No valid mobile numbers found in the input text.");
                    }
                    else
                    {
                        Console.WriteLine("Valid mobile numbers found in the input text:");
                        foreach (string number in mobileNumbers)
                        {
                            Console.WriteLine(number);
                        }
                    }
                    break;

                case 2:
                    //Word Count
                    Console.WriteLine("Enter the sequence of text");
                    string inputText = Console.ReadLine();

                    int wordCount = WordCount(inputText);
                    Console.WriteLine("Word Count: " + wordCount);
                    break; 

                case 3:
                    //Email Validation
                    char checkEmail;

                    do
                    {
                        Console.WriteLine("Enter the Email");
                        string email = Console.ReadLine();


                        bool validEmail = ValidEmail(email);

                        if (validEmail)
                        {
                            Console.WriteLine($"The Email You Entered {email} is valid");
                        }
                        else
                        {
                            Console.WriteLine($"The Email You Entered {email} is not valid");
                        }
                        Console.WriteLine("Continue press y");
                        checkEmail = char.Parse(Console.ReadLine());

                    } while (checkEmail == 'y');
                    
                    break;
                case 4:
                    Console.WriteLine("Enter the mobile number: ");
                    string customNumber = Console.ReadLine();

                    Console.WriteLine("Enter a custom Regex Expression");
                    string customRegexText = Console.ReadLine();

                    CustomRegex(customNumber, customRegexText);
                    break;

                default:
                    Console.WriteLine("Wrong Choice");
                    break;
            }
                                
            Console.ReadKey();
        }

        static List<string> ExtractMobileNumbers(string number)
        {
            List<string> mobileNumbers = new List<string>();
            string pattern = @"\b\d{10}\b"; // Regular expression to match 10 consecutive digits (mobile numbers).

            MatchCollection matches = Regex.Matches(number, pattern);

            foreach (Match match in matches)
            {
                mobileNumbers.Add(match.Value);
            }

            return mobileNumbers;
        }

        static int WordCount(string text)
        {
            string pattern = @"\b\w+\b";

            MatchCollection match = Regex.Matches(text, pattern);

            return match.Count;
        }

        static bool ValidEmail(string email)
        {
            string pattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";
            return Regex.IsMatch(email, pattern);

        }

        static void CustomRegex(string number, string regexPattern)
        {
            MatchCollection matches = Regex.Matches(number, regexPattern);

            if(matches.Count > 0)
            {
                Console.WriteLine("The Found Matches are");
                foreach(Match match in matches)
                {
                    Console.WriteLine(match.Value);
                }
            }
            else
            {
                Console.WriteLine("Match not found.");
            }
        }




    }


}
