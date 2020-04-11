using System;
using System.Collections.Generic;

namespace Dawkins.Weasel
{
    class Program
    {
        static void Main(string[] args)
        {
            var target = "STRUDEL IS THE BEST DOG EVER";
            var  weaselMachine = new WeaselMachine(target);
            
            var firstString = weaselMachine.GenerateRandomString(target.Length);

            var result = 0;
            var startString = firstString;

            while (result < target.Length)
            {
                var generation = weaselMachine.CreateGeneration(startString);

                var generationWinner = weaselMachine.GetGenerationTopScore(generation);

                startString = generationWinner.Key;
                result = generationWinner.Value;
                
                Console.WriteLine($"{startString} : {result}");
            }
        }
    }
}