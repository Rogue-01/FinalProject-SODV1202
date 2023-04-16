using connectFour;
using System;
using System.Dynamic;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography;

//Board - This class will represent the game board and hold the current state of the game. It should have methods to check for wins and add pieces to the board.
//Player - This class will be an abstract base class for the two types of players in the game, human and computer players.It should have methods for getting and setting the player's name, and making moves on the board.
//HumanPlayer - This class will implement the Player class and represent a human player. It should have a method for getting input from the user to make a move on the board.
//ComputerPlayer - This class will implement the Player class and represent a computer player. It should have a method for generating a move on the board.
//GameController - This class will handle the game flow, including creating the board, creating the players, and running the game loop. It should have methods for starting and ending the game, as well as handling player turns and displaying the board.
//ConsoleView - This class will handle input and output from the console. It should have methods for displaying the game board and getting input from the user.
namespace connectFour
{
    //Board class
    public class Board
    {
        //Board array
        private char[,] board = new char[6, 7];
        public Board()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    board[i, j] = '#';
                }
            }
        }
        public void PrintBoard()
        {
            
            for (int i = 0; i < 6; i++)
            {
                Console.Write("|");
                for(int column  = 0; column < 7; column++)
                {
                    Console.Write(board[i, column] + "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("|1|2|3|4|5|6|7|");
        }

    }

    //Player class
    public abstract class Player
    {
        public string PlayerName { get; set; }
        public char Peice { get; set; }

        public abstract int getMove(Board board);
        public Player(string playerName, char peice)
        {
            PlayerName = playerName;
            Peice = peice;
        }
    }
    //HumanPlayer
    public class HumanPlayer : Player
    {
        public HumanPlayer(string playerName, char peice) : base (playerName, peice) { }

        public override int getMove(Board board)
        {
            int column = -1;
            while (column > -1)
            {
                
            }
        }
    }
    //GameController class
    public class Controller
    {

    }
    //Display
    public class Display
    {

    }
    class Program
        {
            static void Main(string[] args)
            {
                Board board = new Board();    
                board.PrintBoard();
            }
        }
}
