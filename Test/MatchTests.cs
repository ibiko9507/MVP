using Operation;
using Service;
using System.IO;

namespace Test
{
    public class MatchTests
    {
        [Test]
        public void Happy_Path_Basketball()
        {
            MatchService matchService = new MatchService();
            string textFile = "Matches\\HappyPathBasketball.txt";

            matchService.EvaluateGame(textFile, out string validationResult);

            Assert.That(validationResult, Is.EqualTo(String.Empty), validationResult);
        }

        [Test]
        public void Happy_Path_Handball()
        {
            MatchService matchService = new MatchService();
            string textFile = "Matches\\HappyPathHandball.txt";

            matchService.EvaluateGame(textFile, out string validationResult);

            Assert.That(validationResult, Is.EqualTo(String.Empty), validationResult);
        }
    }
}