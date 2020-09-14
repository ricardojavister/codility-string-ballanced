using System.Collections.Generic;
using System.Runtime.Serialization;
using System;
using System.Linq;

namespace string_ballanced_upper_and_lowercase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Solution solution = new Solution();
            //int res = solution.DoSolution("azABaabza");
            //int res = solution.DoSolution("TacoCat");
            int res = solution.DoSolution("AcZCbaBz");
            Console.ReadKey();
        }
    }

    public class Solution
    {
        public int DoSolution(string S)
        {
            string stringShortest = string.Empty;
            List<string> listPatterns = new List<string>();
            for (int i = 0; i < S.Length; i++)
            {
                char letter = char.Parse(S.Substring(i, 1));
                char response = this.isBallanced(letter, i, S, char.IsUpper(letter));
                if (response != '\0')
                {
                    stringShortest = stringShortest + response;
                }
                else
                {
                    if (stringShortest!=string.Empty && stringShortest.Length>1 ){
                        listPatterns.Add(stringShortest);
                    }
                    stringShortest = string.Empty;
                }

            }
            if (stringShortest!=string.Empty && stringShortest.Length>1 && listPatterns.Count==0){
                listPatterns.Add(stringShortest);
            }
            if (listPatterns.Count>0){
                stringShortest =  listPatterns.OrderByDescending(x=>x.ToString()).FirstOrDefault();
            }
            return listPatterns.Count>=1 ? stringShortest.Length : -1;
        }

        public char isBallanced(char letter, int index, string S, bool isUpper)
        {
            char response = new char();
            for (int i = 0; i < S.Length; i++)
            {
                if (index != i)
                {
                    if (isUpper)
                    {
                        if (char.ToLower(letter) == char.Parse(S.Substring(i, 1)))
                        {
                            response = letter;
                        }
                    }
                    else
                    {
                        if (char.ToUpper(letter) == char.Parse(S.Substring(i, 1)))
                        {
                            response = letter;
                        }
                    }

                }
            }
            return response;
        }
    }
}
