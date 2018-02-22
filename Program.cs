using System;
using System.Linq;

namespace passgen
{
    class Program
    {
        public static string getStringOfValidPasswordCharacters() {
            string stringLowerCaseAlphabet = new string(Enumerable.Range('a', 'z' - 'a' + 1).Select(number => (char)number).ToArray());
            string stringUpperCaseAlphabet = new string(Enumerable.Range('A', 'Z' - 'A' + 1).Select(number => (char)number).ToArray());
            string stringDigitCharacters = new string(Enumerable.Range('0', '9' - '0' + 1).Select(number => (char)number).ToArray());
            string passwordValidCharacters = stringLowerCaseAlphabet + stringUpperCaseAlphabet + stringDigitCharacters;
            return passwordValidCharacters;
        }


        public static int[] getArrayIntsInRange(int length, int minValue, int maxValue) {
            if (length <= 0) {
                throw new ArgumentOutOfRangeException(String.Format("getArrayIntsIntRange: Length cannot be negative, but is {0}.", length));
            }
            int[] arrayInts = new int[length];
            Random randomGenerator = new Random();
            for (var arrayIntIndex = 0; arrayIntIndex < arrayInts.Length; arrayIntIndex++) {
                arrayInts[arrayIntIndex] = randomGenerator.Next(minValue, maxValue);
            }
            return arrayInts;
        }

        public static string LookupCharactersFromArrayOfIndexes(string lookupCharacters, int[] arrayInts) {
            return new string(arrayInts.Select(number => lookupCharacters[number]).ToArray());
        }

        static void Main(string[] args) {
            int length = 12;
            if (args.Length > 0) {
                string argToLower = args[0].ToLower();
                if (argToLower == "help") {
                    System.Console.WriteLine("passGen [option] [argument]");
                    System.Console.WriteLine("option help: Display help information");
                    System.Console.WriteLine("option -l [length]: Specify length of password");
                    return;
                } else if (argToLower == "-l") {
                    if (args.Length == 2) {
                        length = Convert.ToInt32(args[1]);
                    } else {
                        System.Console.WriteLine("Must specify one length value");
                        return;
                    }
                } else {
                    System.Console.WriteLine(String.Format("Unknown command: {0}", args.ToString()));
                    return;
                }
            }

            string passwordValidCharacters = getStringOfValidPasswordCharacters();

            int[] randomIndexValuesArray = getArrayIntsInRange(length, 0, passwordValidCharacters.Length);
            string password = LookupCharactersFromArrayOfIndexes(passwordValidCharacters, randomIndexValuesArray);
            System.Console.WriteLine(String.Format("Password: {0}", password));
        }
    }
}
