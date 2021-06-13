using CO453_Rockpaperscissors.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CO453_GameUI
{/// <summary>
/// This is a Class to display the UI and display properties of the game 
/// </summary>
   
    public partial class GameForm : Form
    {
        /// <summary>
        /// This is a method to show the images Rock Paper Scissors
        /// </summary>
        private Bitmap rockBitmap = new Bitmap(Resources.Rock);
        private Bitmap paperBitmap = new Bitmap(Resources.Paper);
        private Bitmap scissorsBitmap = new Bitmap(Resources.Scissors);

        private Game game = new Game("Player");
        
        public GameForm()
        {
            InitComponent();

            paperRadioButton.Checked = true;
            game.Start();
        }
        /// <summary>
        /// This is a method to display the image.
        /// </summary>
       
        private void DisplayImage(PictureBox pictureBox, Bitmap bitmap)
        {
            pictureBox.Image = bitmap;
        }

        /// <summary>
        /// This is a Method to Display the image paper
        /// </summary>
        private void DisplayPaper(object sender, EventArgs e)
        {
            DisplayImage(userPictureBox, paperBitmap);
            game.PlayerChoice = GameChoice.Paper;

        }
        /// <summary>
        /// This is a Method to Display the image scissors
        /// </summary>

        private void DisplayScissors(object sender, EventArgs e)
        {
            DisplayImage(userPictureBox, scissorsBitmap);
            game.PlayerChoice = GameChoice.Scissors;
        }
        /// <summary>
        /// This is a Method to Display the image Rock
        /// </summary>

        private void DisplayRock(object sender, EventArgs e)
        {
            DisplayImage(userPictureBox, rockBitmap);
            game.PlayerChoice = GameChoice.Rock;
        }
        /// <summary>
        /// This is a Method to get the computers choice as a if or else statment.
        /// </summary>

        private void GetComputerChoice(object sender, EventArgs e)
        {
            game.GetComputerChoice();

            if (game.ComputersChoice == GameChoice.Rock)
            {
                DisplayImage(computerPictureBox, rockBitmap);
            }
            else if (game.ComputersChoice == GameChoice.Paper)
            {
                DisplayImage(computerPictureBox, paperBitmap);
            }
            else if (game.ComputersChoice == GameChoice.Scissors)
            {
                DisplayImage(computerPictureBox, scissorsBitmap);
            }

            DisplayWinner();
        }
        /// <summary>
        /// This is a Method to Display the Winner of the match
        /// </summary>

        private void DisplayWinner()
        {
            game.ScoreRound();

            string message = "\n You have chosen \n " + game.PlayerChoice;
            message = message + "\nComputer Choses \n " + game.ComputersChoice;

            message = message + "\n\n And the Winner is:\n  " + game.WinnerName;
            message = message + "\n";
            message = message + "\n To play again:";
            message = message + "\n Choose R, P or S then Click play \n";
            message = message + "\n   \n";

            scoreRichTextBox.AppendText(message);
        }

        private void QuitForm(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
