using Operation;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Test
{
    public class ValidationTests
    {
        MatchOperation matchOperation = new MatchOperation();

        [Test]
        public void Case_The_Input_Is_Null()//ok
        {
            string textFile = "Validations\\Case_The_Input_Is_Null.txt";
            matchOperation.EvaluateGame(textFile, out string validationResult);
            Assert.That(validationResult, Is.EqualTo(String.Empty),validationResult);
        }

        [Test]
        public void Case_Team_Count_Wrong_With_One_Team()//ok
        {
            string textFile = "Validations\\Case_Team_Count_Wrong_With_One_Team.txt";
            matchOperation.EvaluateGame(textFile, out string validationResult);
            Assert.That(validationResult, Is.EqualTo(String.Empty), validationResult);
        }

        [Test]
        public void Case_Team_Count_Wrong_With_Three_Team() //ok
        {
            string textFile = "Validations\\Case_Team_Count_Wrong_With_Three_Team.txt";
            matchOperation.EvaluateGame(textFile, out string validationResult);
            Assert.That(validationResult, Is.EqualTo(String.Empty), validationResult);
        }

        [Test]
        public void Case_Same_Player_Twice() //ok
        {
            string textFile = "Validations\\Case_Same_Player_Twice.txt";
            matchOperation.EvaluateGame(textFile, out string validationResult);
            Assert.That(validationResult, Is.EqualTo(String.Empty), validationResult);
        }

        [Test]
        public void Case_Wrong_File_Type() //ok
        {
            string textFile = "Validations\\Case_Wrong_File_Type.txt";
            matchOperation.EvaluateGame(textFile, out string validationResult);
            Assert.That(validationResult, Is.EqualTo(String.Empty), validationResult);
        }

        [Test]
        public void Case_Wrong_Game_Type() //ok
        {
            string textFile = "Validations\\Case_Wrong_Game_Type.txt";
            matchOperation.EvaluateGame(textFile, out string validationResult);
            Assert.That(validationResult, Is.EqualTo(String.Empty), validationResult);
        }

        [Test]
        public void Case_Game_Stat_Detail_Wrong_Type() //ok
        {
            string textFile = "Validations\\Case_Game_Stat_Detail_Wrong_Type.txt";
            matchOperation.EvaluateGame(textFile, out string validationResult);
            Assert.That(validationResult, Is.EqualTo(String.Empty), validationResult);
        }

        [Test]
        public void Case_Missing_Stat_Detail() //ok
        {
            string textFile = "Validations\\Case_Missing_Stat_Detail.txt";
            matchOperation.EvaluateGame(textFile, out string validationResult);
            Assert.That(validationResult, Is.EqualTo(String.Empty), validationResult);
        }

        [Test]
        public void Case_Player_Count_Of_Teams_Are_Different() //ok
        {
            string textFile = "Validations\\Case_Player_Count_Of_Teams_Are_Different.txt";
            matchOperation.EvaluateGame(textFile, out string validationResult);
            Assert.That(validationResult, Is.EqualTo(String.Empty), validationResult);
        }
    }
}