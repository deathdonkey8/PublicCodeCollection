using System;
using System.Collections.Generic;

namespace Enigma
{
    class Program
    {
        static public string input;
        static public string selection;
        static public char[] _inputAr;
        static public List<char> _shuffleInput;
        static public List<char> _decodeInput;
        //The Two alphabets for refrencing
        static public List<char> _codedAlph = new List<char>{'^','&','(','}','£','~','$','/','.',',','#','|','\'','\"',')',']','[','>','<','!','-','=','@','%',':',';','+'};
        static public List<char> _standardAlph = new List<char>{'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',' '};
        static void Main(string[] args)
        {
            //just outputs the coded alphabet
            for(int i = 0; i < 27; i++)
            {
                Console.WriteLine(_codedAlph[i]);
            }
            //user prompts and getting an input
            Console.WriteLine("encode or decode:");
            //encode or decode is used to select the mode
            selection = Console.ReadLine();
            Console.WriteLine("Please input text:");
            input = Console.ReadLine().ToLower(); //lowercase to alter easier
            _inputAr = input.ToCharArray();
            //calls the function selecter and passes through the input as a char array and the return is output
            if(selection == "encode")
            {
                Console.WriteLine(encode(_inputAr));
            }
            else if(selection == "decode")
            {
                Console.WriteLine(decode(_inputAr));
            }
            else
            {
                Console.WriteLine("There was an error!");
            }
            Console.ReadLine();
        }

        static string encode(char[] input)
        {
            string output;
            //converts the input into the coded alphabet
            for(int i = 0; i < input.Length; i++)
            {
                input[i] = _codedAlph[_standardAlph.IndexOf(input[i])];
            }
            //makes the array into a list
            _shuffleInput = new List<char>(input);
            //for every other char it moves it to the end and switiches it to an 'x'
            for(int i = 1; i < input.Length + 1; i++)
            {
                if(i % 2 == 0 )
                {
                    _shuffleInput.Add(_shuffleInput[i - 1]);
                    _shuffleInput[i - 1] = 'x';
                }
            }
            //removes all the Xs in the list to get the final encoded output
            for(int i = 0; i < input.Length; i++)
            {
            _shuffleInput.Remove('x');
            }
            output = new string(_shuffleInput.ToArray());
            return output;
        }

        static string decode(char[] input)
        {
            int half;
            _decodeInput = new List<char>();
            //gets the half way point if the total length for either a odd or even length
            if(input.Length % 2 != 0)
            {
                half = ((input.Length) / 2) + 1;
            }
            else
            {
                half = ((input.Length) / 2);
            }
            string output;
            //converts from the encoded alphabet back to the standard alphabet
            for(int i = 0; i < input.Length; i++)
            {
                input[i] = _standardAlph[_codedAlph.IndexOf(input[i])];
            }
            //gets the difference between the halfway and the total length inorder to split the input
            int dif = input.Length - half;
            _shuffleInput = new List<char>(input);
            //puts the second half into a separate list
            for(int i = 0; i < dif; i++)
            {
                _decodeInput.Add(_shuffleInput[half]);
                _shuffleInput.RemoveAt(half);
            }
            //every other index the char is brought from the secondary list into the main input to put it all back together in the correct order
            for(int i = 1; i < input.Length + 1; i++)
            {
                if(i % 2 == 0)
                {
                    _shuffleInput.Insert(i - 1, _decodeInput[0]);
                    _decodeInput.RemoveAt(0);
                }
            }
            output = new string(_shuffleInput.ToArray());
            return output;
        }
    }
}
