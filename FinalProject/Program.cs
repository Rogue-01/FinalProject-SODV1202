using System;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;

namespace Connect4
{

    //To define the code and read it easier
    public class Game
    {
        private readonly int _rows;
        private readonly int _columns;
        private readonly int _CheckWin;

        public Game(int rows = 6, int columns = 7, int CheckWin = 4)
        {
            _rows = rows;
            _columns = columns;
            _CheckWin = CheckWin;
        }
    }
    //have four classes: Board, Player, Move, check win

    //Board class
    public class Board
    {
        private char[,] board = new char[6, 7];
        public Board()
        {
            for (int rows = 0; rows < 6; rows++)
            {
                for (int columns = 0; columns < 7; columns++)
                {
                    board[rows, columns] = ' ';
                }
            }
        }
        public void PrintBoard()
        {
            Console.WriteLine(" 1 2 3 4 5 6 7");
            for (int row = 0; row < 6; row++)
            {
                Console.Write("|");
                for (int columns = 0; columns < 7; columns++)
                {
                    Console.Write(board[row, columns] + "|");
                }
                Console.WriteLine();
            }
        }

        public char GetCell(int row, int column)
        {
            return board[row, column];
        }

        public void SetCell(int row, int column, char symbol)
        {
            board[row, column] = symbol;
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
        private int column;
        public Move(int column)
        {
            this.column = column;
        }
        public int Column
        {
            get { return column; }
        }
    }
    //check win class
    public class CheckWin
    {
        private Board board;
        private Player player;
        private int rows;
        private int columns;
        private int Checkwin;

        public CheckWin(Board board, Player player, int rows, int columns, int checkwin)
        {
            this.board = board;
            this.player = player;
            this.rows = rows;
            this.columns = columns;
            Checkwin = checkwin;
        }
        public bool IsWinningMove(Move move)
        {
            int row = GetNextAvailableRow(move.Column);
            if (row == -1)
            {
                return false;
            }

            board.SetCell(row, move.Column, player.GetSymbol());
            Console.WriteLine("{0} has played {1}", player.GetName(), move.Column + 1);
            board.PrintBoard();

            if (CheckHorizonatal(row) || CheckVertical(move.Column) || CheckDiagonal1(row, move.Column) || CheckDiagonal2(row, move.Column))
            {
                return true;
            }

            return false;
        }

        private int GetNextAvailableRow(int column)
        {
            for (int row = rows - 1; row >= 0; row--)
            {
                if (board.GetCell(row, column) == player.GetSymbol())
                {
                    return row;
                }
            }

            return -1;
        }

        private bool CheckHorizonatal(int row)
        {
            int count = 0;
            for (int column = 0; column < columns; column++)
            {
                if (board.GetCell(row, column) == player.GetSymbol())
                {
                    count++;
                    if (count == Checkwin)
                    {
                        return true;
                    }
                }
                else
                {
                    count = 0;
                }
            }
            return false;
        }

        private bool CheckVertical(int column)
        {
            int count = 0;
            for (int row = rows - 1; row >= 0; row--)
            {
                if (board.GetCell(row, column) == player.GetSymbol())
                {
                    count++;
                    if (count == Checkwin)
                    {
                        return true;
                    }
                }
                else
                {
                    count = 0;
                }
            }
            return false;
        }
        private bool CheckDiagonal1(int row, int column)
        {
            int count = 0;
            for (int i = 0; i <= Checkwin; i++)
            {
                if (row - i < 0 || column - i < 0)
                {
                    break;
                }
                if (board.GetCell(row - 1, column - i) == player.GetSymbol())
                {
                    count++;
                    if (count == Checkwin)
                    {
                        return true;
                    }
                }
                else
                {
                    break;
                }
            }

            for (int i = 1; i < Checkwin; i++)
            {
                if (row + i <= rows || column + i >= columns)
                {
                    break;
                }

                if (board.GetCell(row + i, column + i) == player.GetSymbol())
                {
                    count++;
                    if (count == Checkwin)
                    {
                        return true;
                    }
                }
                else
                {
                    break;
                }
            }
            return false;
        }

        private bool CheckDiagonal2(int row, int column)
        {
            int count = 0;
            for (int i = 0; i <= Checkwin; i++)
            {
                if (row - i < 0 || column + i >= columns)
                {
                    break;
                }
                if (board.GetCell(row - i, column + i) == player.GetSymbol())
                {
                    count++;
                    if (count >= Checkwin)
                    {
                        return true;
                    }
                }
                else
                {
                    break;
                }
            }
            for (int i = 1; i <= Checkwin; i++)
            {
                if (row + i >= rows || column - i < 0)
                {
                    break;
                }

                if (board.GetCell(row + i, column - i) == player.GetSymbol())
                {
                    count++;
                    if (count == Checkwin)
                    {
                        return true;
                    }
                }
                else
                {
                    break;
                }
            }
            return false;
        }
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
            //ask player where they want to move
            Move move;
            //create check win object
            CheckWin checkwin = new CheckWin(board, player1, 6, 7, 4);
            //loop until win
            bool isPlayer1Turn = true;
            while (true)
            {
                if (isPlayer1Turn)
                {
                    Console.WriteLine("Player 1, where do you want to move?");
                    move = new Move(int.Parse(Console.ReadLine()));
                    if (checkwin.IsWinningMove(move))
                    {
                        Console.WriteLine("Player 1 wins!");
                        break;
                    }
                    isPlayer1Turn = false;
                }
                else
                {
                    Console.WriteLine("Player 2, where do you want to move?");
                    move = new Move(int.Parse(Console.ReadLine()));
                    if (checkwin.IsWinningMove(move))
                    {
                        Console.WriteLine("Player 2 wins!");
                        break;
                    }
                    isPlayer1Turn = true;

                }
            }
            Console.ReadLine();
        }
    }
}
