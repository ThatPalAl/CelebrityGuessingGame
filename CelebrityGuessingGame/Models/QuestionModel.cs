namespace CelebrityGuessingGame.Models
{
    public class QuestionModel
    {
        public string QuestionText { get; set; } // The text of the question
        public List<Option> Options { get; set; } // The list of answer options
        public string QuestionType { get; set; } // The type of question (e.g., multiple-choice)
    }
}