using System;
using System.Collections.Generic;

namespace Dawkins.Weasel
{
    class Program
    {
        static void Main(string[] args)
        {
            var target = "METHINKS IT IS LIKE A WEASEL";
            var  weaselMachine = new WeaselMachine(target);
            
            var firstString = weaselMachine.GenerateRandomString(target.Length);

            var result = 0;
            var generationCounter = 1;
            var startString = firstString;
            
            Console.WriteLine($"G   WINNER                         SCORE");

            while (result < target.Length)
            {
                var generation = weaselMachine.CreateGeneration(startString);

                var generationWinner = weaselMachine.GetGenerationTopScore(generation);

                startString = generationWinner.Key;
                result = generationWinner.Value;
                
                Console.WriteLine($"{generationCounter} - {startString} : {result}");
                generationCounter++;
            }
        }
    }
}