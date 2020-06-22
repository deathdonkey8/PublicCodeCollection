using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
    class TextCipher
    {
        public static void Main()
        {
            List<char> alphabet = new List<char> {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
            List<char> alShift = new List<char> {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
            List<char> rearranged;
            char saved;
            string output;
            string inputText;
            Console.WriteLine("Please input cipher:");
            inputText = Console.ReadLine();
            Console.WriteLine("Processing input");
            Program p = new Program();
            output = inputText;
            for(int i = 0; i < 26; i++)
            {
                rearranged = new List<char> {};
                saved = alShift[0];
                alShift.RemoveAt(0);
                alShift.Add(saved);
                //Console.WriteLine(alShift[0]);
                for(int x = 0; x < inputText.Length; x++)
                {
                    char locChar = inputText[x];
                    int location = alShift.IndexOf(locChar);
                    rearranged.Add(alphabet[location]);
                }
                output = new string(rearranged.ToArray());
                Console.WriteLine(output);
            }
            Console.ReadLine();
        }
    }
}
