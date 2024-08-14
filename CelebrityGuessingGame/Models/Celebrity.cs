using System.Collections.Generic;

namespace CelebrityGuessingGame.Models
{
    public class Celebrity
    {
        public int Id { get; set; } 

        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public List<string> Occupation { get; set; }
        public decimal NetWorth { get; set; }
        public double Height { get; set; }
        public string Birthday { get; set; }
        public bool IsAlive { get; set; }
    }
}