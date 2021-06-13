using System;

namespace CO453_GameUI
{
    /// <summary>
    /// The three available choices Rock paper or scissors during the game.
    /// </summary>
    public enum GameChoice
    {
        Rock, 
        Paper,
        Scissors
    }
    
    /// <summary>
    /// The players of the game
    /// </summary>
    public enum GamePlayer
    {
        None,
        Computer,
        Human
    }

    /// <summary>
    /// In this class i have a model of the Rock-Paper-Scissors game, 
    /// Containing all information about the state and
    /// methods of implementing it.
   ///  <summary>
  
    /// <author>
    /// Andrew Wood version 1.0
    /// </author>
    
    public class Game
    {
        // Players Properties
        public string PlayerName { get; }

        // Public only for Unit testing
        public int PlayerScore { get; set; }

        // Public only for Unit Testing
        public GameChoice PlayerChoice { get; set; }

        // Computer Properties
        public int ComputersScore { get; set; }
        
        // Public only for Unit Testing
        public GameChoice ComputersChoice { get; set; }

        // Game Properties
        public int LastRound { get; set; }

        public int Round { get; set; }

        public GamePlayer CurrentPlayer { get; set; }

        public String WinnerName { get; set; }

        // Use seed to get same sequence of random numbers
        private readonly Random generator = new Random(55);

        public Game(string name)
        {
            PlayerName = name;
            LastRound = 5;
            Start();
        }
        /// <summary>
        /// This is a method to start the program in cluding player score and computer score
        /// </summary>
        public void Start()
        {
            PlayerScore = 0;
            ComputersScore = 0;

            CurrentPlayer = GamePlayer.Human;
            Round = 1;
        }

        /// <summary>
        /// This is a method to get the computers choice
        /// </summary>
        public void GetComputerChoice()
        {
            int choice = generator.Next(1, 4);
            
            switch (choice)
            {
                case 1: ComputersChoice = GameChoice.Rock; break;
                case 2: ComputersChoice = GameChoice.Paper; break;
                case 3: ComputersChoice = GameChoice.Scissors; break;
            }
        }
        /// <summary>
        /// Method to with a if or else statemant to determin the outcome of the round 
        /// </summary>
        public void ScoreRound()
        {
            if ((PlayerChoice == GameChoice.Rock && 
                ComputersChoice == GameChoice.Paper) ||
               (PlayerChoice == GameChoice.Paper &&
                ComputersChoice == GameChoice.Scissors) ||
               (PlayerChoice == GameChoice.Scissors &&
                 ComputersChoice == GameChoice.Rock))
            {
                ComputersScore += 2;
                WinnerName = GamePlayer.Computer.ToString();
            }
            else if ((PlayerChoice == GameChoice.Rock &&
                    ComputersChoice == GameChoice.Scissors) ||
                    (PlayerChoice == GameChoice.Paper) && 
                    (ComputersChoice == GameChoice.Rock) ||
                    (PlayerChoice == GameChoice.Scissors &&
                    ComputersChoice == GameChoice.Paper))
            {
                PlayerScore += 2;
                WinnerName = PlayerName;
            }
            else 
            {
                ComputersScore += 1;
                PlayerScore += 1;
                WinnerName = GamePlayer.None.ToString();
            }


            if (Round < LastRound) Round++;
            else End();
        }
        /// <summary>
        /// A method to End the Game and display the score
        /// </summary>
        public void End()
        {
            if (ComputersScore > PlayerScore)
            {
                WinnerName = GamePlayer.Computer.ToString();
            }
            else if (PlayerScore > ComputersScore)
            {
                WinnerName = PlayerName;
            }
            else WinnerName = "No Player";
        }
    }
}
