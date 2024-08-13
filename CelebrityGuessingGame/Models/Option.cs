namespace CelebrityGuessingGame.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string OptionText { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}