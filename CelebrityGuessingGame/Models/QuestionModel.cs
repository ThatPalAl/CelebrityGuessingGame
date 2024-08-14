namespace CelebrityGuessingGame.Models
{
    public class QuestionModel
    {
        public string QuestionText { get; set; }
        public List<Option> Options { get; set; }
        public string QuestionType { get; set; } 
    }
}