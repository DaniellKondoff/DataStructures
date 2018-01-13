using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            const char openBracket = '(';
            const char closedtBracket = ')';

            string input = "1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5";
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];

                if (current == openBracket)
                {
                    stack.Push(i);
                }
                else if(current == closedtBracket)
                {
                    int startIndex = stack.Pop();
                    int length = i - startIndex + 1;
                    string contents = input.Substring(startIndex, length);
                    Console.WriteLine(contents);
                }
            }

        }
    }
}
