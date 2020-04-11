using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dawkins.Weasel
{
    public class WeaselMachine
    {
        private readonly string _targetString;

        public WeaselMachine(string targetString)
        {
            _targetString = targetString;
        }
        
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ";
        
        public int GetScore(string progeny)
        {
            var score = 0;
            for(var i=0;i<_targetString.Length;i++)
            {
                var targetChar = _targetString[i];
                var progenyChar = progeny[i];

                if (targetChar.Equals(progenyChar))
                    score++;
            }

            return score;
        }
        
        public string GenerateRandomString(int size)
        {
            var random = new Random();
            return new string(Enumerable.Repeat(Chars, size)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public List<string> CreateGeneration(string parent)
        {
            var generation = new List<string>();

            for (var i = 0; i < 100; i++)
            {
                generation.Add(ReproduceString(parent));
            }

            return generation;
        }

        private string ReproduceString(string parent)
        {
            var child = new StringBuilder();

            foreach (var c in parent)
            {
                if (IsMutation())
                    child.Append(GenerateRandomString(1));
                else
                {
                    child.Append(c);
                }
            }
            
            return child.ToString();
        }

        private static bool IsMutation()
        {
            var gen = new Random();
            var prob = gen.Next(100);
            return prob <= 5;
        }

        public KeyValuePair<string,int> GetGenerationTopScore(IEnumerable<string> generation)
        {
            return generation.Select(x => new KeyValuePair<string, int>(x, GetScore(x))).OrderByDescending(x => x.Value).First();
        }
    }
}