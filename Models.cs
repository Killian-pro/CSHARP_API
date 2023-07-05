using System.ComponentModel.DataAnnotations;

namespace APIApp
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
    }


    public class Game
    {
        [Key]
        public int Id { get; set; }
        public int Player1id { get; set; }
        public int Player2id { get; set; }
        public required string BoardState { get; set; }
        public int IdPlayerWin { get; set; }
    }

    public class Score
    {
        [Key]
        public int Id { get; set; }
        public int Player { get; set; }
        public required string PlayerName { get; set; }
        public int ScoreNumber { get; set; }

    }

}
