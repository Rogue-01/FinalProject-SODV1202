using connectFour;
using System;
using System.ComponentModel;
using System.Dynamic;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography;

//Board - This class will represent the game board and hold the current state of the game. It should have methods to check for wins and add pieces to the board.
//Player - This class will be an abstract base class for the two types of players in the game, human and computer players.It should have methods for getting and setting the player's name, and making moves on the board.
//HumanPlayer - This class will implement the Player class and represent a human player. It should have a method for getting input from the user to make a move on the board.
//GameController - This class will handle the game flow, including creating the board, creating the players, and running the game loop. It should have methods for starting and ending the game, as well as handling player turns and displaying the board.
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
                    Console.Write(board[i, j] + " ");
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
        public bool CheckWin(int player)
        {
            //check horizontal
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns - winLength + 1; j++)
                {
                    bool hasWon = true;
                    for (int k = 0; k < winLength; k++)
                    {
                        if (board[i, j + k] != player)
                        {
                            hasWon = false;
                            break;
                        }
                    }
                    if (hasWon)
                    {
                        return true;
                    }
                }
            }

            //check vertical
            for (int i = 0; i < rows - winLength + 1; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    bool hasWon = true;
                    for (int k = 0; k < winLength; k++)
                    {
                        if (board[i + k, j] != player)
                        {
                            hasWon = false;
                            break;
                        }
                    }
                    if (hasWon)
                    {
                        return true;
                    }
                }
            }

            //check diagonal
            for (int i = 0; i < rows - winLength + 1; i++)
            {
                for (int j = 0; j < columns - winLength + 1; j++)
                {
                    bool hasWon = true;
                    for (int k = 0; k < winLength; k++)
                    {
                        if (board[i + k, j + k] != player)
                        {
                            hasWon = false;
                            break;
                        }
                    }
                    if (hasWon)
                    {
                        return true;
                    }
                }
            }

            //check other diagonal
            for (int i = 0; i < rows - winLength + 1; i++)
            {
                for (int j = winLength - 1; j < columns; j++)
                {
                    bool hasWon = true;
                    for (int k = 0; k < winLength; k++)
                    {
                        if (board[i + k, j - k] != player)
                        {
                            hasWon = false;
                            break;
                        }
                    }
                    if (hasWon)
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
            //tell player to make a move
            Console.WriteLine($"{PlayerName}, it is your turn. Please choose a column:");

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
        private Board board;
        private Player player1;
        private Player player2;

        internal Controller(Board board, Player player1, Player player2)
        {
            //create board with default values
            this.board = board;
            this.player1 = player1;
            this.player2 = player2;
        }

        public void Start()
        {
            Console.WriteLine("Welcome to Connect Four!");

            //create board and players
            board = new Board(6, 7, 4);
            player1 = new HumanPlayer();
            player2 = new HumanPlayer();
            
            Run();
        }
        // Run the game
        public void Run()
        {
            int currentPlayer = 1;
            Player activePlayer = player1;
            while (true)
            {
                Console.Clear();
                board.PrintBoard();
                int move = activePlayer.getMove(board);
                if (board.AddPiece(move, currentPlayer))
                {
                    if (board.CheckWin(currentPlayer))
                    {
                        Console.Clear();
                        board.PrintBoard();
                        Console.WriteLine($"{activePlayer.PlayerName} wins!");
                        EndGame();
                        return;
                    }
                    if (boardIsFull())
                    {
                        Console.Clear();
                        board.PrintBoard();
                        Console.WriteLine("It's a tie!");
                        EndGame();
                        return;
                    }
                    SwitchPlayers(ref currentPlayer, ref activePlayer);
                }
            }
        }

        //cheack if board is full
        private bool boardIsFull()
        {
            for (int i = 0; i < board.columns; i++)
            {
                if (board.board[0, i] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        // End the game
        public void EndGame()
        {
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        // Switch players
        private void SwitchPlayers(ref int currentPlayer, ref Player activePlayer)
        {
            currentPlayer = currentPlayer == 1 ? 2 : 1;
            activePlayer = currentPlayer == 1 ? player1 : player2;
        }
    }

    class Program
        {
        static void Main(string[] args)
        {
            //start game
            Board board = new Board(6, 7, 4);
            Player player1 = new HumanPlayer() { PlayerName = "Player 1", Peice = 'X' };
            Player player2 = new HumanPlayer() { PlayerName = "Player 2", Peice = 'O' };

            Controller controller = new Controller(board, player1, player2);
            controller.Start();
            
            
        }
    }
}
