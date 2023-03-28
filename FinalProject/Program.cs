using System;

namespace Connect4
{

    //have four classes: Board, Player, Move, check win

    //Board class
    public class Board
    {
        private char[,] board = new char[6, 7];
        public Board()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }
        public void PrintBoard()
        {
            Console.WriteLine(" 1 2 3 4 5 6 7");
            for (int i = 0; i < 6; i++)
            {
                Console.Write("|");
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(board[i, j] + "|");
                }
                Console.WriteLine();
            }
        }
    }
    //Player class
    public class Player
    {
        private string name;
        private char symbol;
        public Player(string name, char symbol)
        {
            this.name = name;
            this.symbol = symbol;
        }
        public string GetName()
        {
            return name;
        }
        public char GetSymbol()
        {
            return symbol;
        }
    }
    //Move class
    public class Move
    { 
        
    }

    //check win class
    public class CheckWin
    { 
    
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            //make board object
            Board board = new Board();
            board.PrintBoard();

            //ask player for name
            Console.WriteLine("Player 1, what is your name?");
            string name1 = Console.ReadLine();
            Console.WriteLine("Player 2, what is your name?");
            string name2 = Console.ReadLine();

            //ask player for symbol (X or O)
            Console.WriteLine("Player 1, what symbol do you want to use? (X or O)");
            char symbol1 = Console.ReadLine()[0];
            Console.WriteLine("Player 2, what symbol do you want to use? (X or O)");
            char symbol2 = Console.ReadLine()[0];

            //create player objects
            Player player1 = new Player(name1, symbol1);
            Player player2 = new Player(name2, symbol2);
            //create move objects
            //create check win object
            //loop until win

        }
    }
}
