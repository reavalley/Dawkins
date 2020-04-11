using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Dawkins.Weasel.Tests
{
    public class WeaselTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly WeaselMachine _weaselMachine;

        public WeaselTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _weaselMachine = new WeaselMachine("METHINKS IT IS LIKE A WEASEL");
        }


        [Fact]
        public void CanGenerate28CharacterString()
        {
            var firstString = _weaselMachine.GenerateRandomString(28);
            
            _testOutputHelper.WriteLine(firstString);
            Assert.True(firstString.Length == 28);
        }
        
        [Fact]
        public void CanCreateGeneration()
        {
            var firstString = _weaselMachine.GenerateRandomString(28);

            var generation = _weaselMachine.CreateGeneration(firstString);

            foreach (var sibling in generation)
            {
                _testOutputHelper.WriteLine(sibling);    
            }
            
            Assert.True(generation.Count == 100);
        }
        
        [Fact]
        public void GetScoreReturnsCorrectly()
        {
            var progenyScore = _weaselMachine.GetScore("MEMPVCADYHHFEYRHAV SLTYKLCOI");
            
            _testOutputHelper.WriteLine(progenyScore.ToString());
            Assert.True(progenyScore == 2);
        }
        
        [Fact]
        public void ForAGivenGenerationReturnsHigestScore()
        {
            var generation = new List<string>
            {
                "MEMPVCADYHHFEYRHAV SLTYKLCOI",
                "MEMPVCADYHHFEYRHAV SLTYKLCEL"
            };
            
            var generationScore = _weaselMachine.GetGenerationTopScore(generation);
            
            _testOutputHelper.WriteLine(generationScore.ToString());
            Assert.True(generationScore.Value == 4);
            Assert.True(generationScore.Key == "MEMPVCADYHHFEYRHAV SLTYKLCEL");
        }
    }
}