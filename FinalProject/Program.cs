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
        public int[,] board;
        public int rows;
        public int columns;
        public int winLength;

        public Board(int rows, int columns, int winLength)
        {
            this.rows = rows;
            this.columns = columns;
            this.winLength = winLength;
            board = new int[rows, columns];
        }
        //print board
        public void PrintBoard()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(board[i, j] + "#");
                }
                Console.WriteLine();
            }
        }
        //adding piece to board
        public bool AddPiece(int column, int player)
        {
            for (int i = rows - 1; i >= 0; i--)
            {
                if (board[i, column] == 0)
                {
                    board[i, column] = player;
                    return true;
                }
            }
            return false;
        }
        public bool CheckWIn(int player) 
        {
            //check horizontal
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns - winLength; j++)
                {
                    if (board[i, j] == player && board[i, j + 1] == player && board[i, j + 2] == player && board[i, j + 3] == player)
                    {
                        return true;
                    }
                }
            }
            //check vertical
            for (int i = 0; i < rows - winLength; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (board[i, j] == player && board[i + 1, j] == player && board[i + 2, j] == player && board[i + 3, j] == player)
                    {
                        return true;
                    }
                }
            }
            //check diagonal
            for (int i = 0; i < rows - winLength; i++)
            {
                for (int j = 0; j < columns - winLength; j++)
                {
                    if (board[i, j] == player && board[i + 1, j + 1] == player && board[i + 2, j + 2] == player && board[i + 3, j + 3] == player)
                    {
                        return true;
                    }
                }
            }
            //check other diagonal
            for (int i = 0; i < rows - winLength; i++)
            {
                for (int j = winLength - 1; j < columns; j++)
                {
                    if (board[i, j] == player && board[i + 1, j - 1] == player && board[i + 2, j - 2] == player && board[i + 3, j - 3] == player)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }

    //Player class
    abstract class Player
    {
        public string PlayerName { get; set; }
        public char Peice { get; set; }
        public abstract int getMove(Board board);
    }
    //HumanPlayer
    class HumanPlayer : Player
    {
        public override int getMove(Board board)
        {
            Console.WriteLine($"{PlayerName}, make a move (1-6)");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > board.columns || !board.AddPiece(choice - 1, Peice))
            {
                Console.WriteLine("Invalid choice. Please choose a valid column:");
            }
            return choice - 1;
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
            Console.WriteLine("Connect Four!");
            // Make board and players
            Board board = new Board(6, 7, 4);
            HumanPlayer player1 = new HumanPlayer();
            HumanPlayer player2 = new HumanPlayer();

            // Make game controller and play game
        }
    }
}
