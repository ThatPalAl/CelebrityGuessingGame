using System.Collections.Generic;

namespace CelebrityGuessingGame.Models
{
    public class GameViewModel
    {
        public List<QuestionModel> Questions { get; set; }
        public List<string> Answers { get; set; } = new List<string>(); 
    }
}

