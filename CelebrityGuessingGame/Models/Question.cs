using System.Collections.Generic;

namespace CelebrityGuessingGame.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public ICollection<Option> Options { get; set; }
        public Answer Answer { get; set; }  
    }
}