using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using SharedCsharpModels.Models;

namespace SharedCsharpModels.View
{
    public class Print
    {
        const int BOARD_WIDTH = 8;
        const int BOARD_HEIGHT = 8;

        /// <summary>
        /// Prints out a header
        /// </summary>
        public static void Header()
        {
            string header = "                               CHESS BY GROUP 2\n";
            Console.WriteLine(header);
        }

        /// <summary>
        /// Prints out a menu
        /// </summary>
        public static void Menu()
        {
            Header();
            Console.WriteLine("               (N)EW GAME         (J)OIN Game         (E)XIT");
        }

        /// <summary>
        /// Prints out the chessboard according to gamestate.
        /// </summary>
        /// <param name="game">Gamestate.</param>
        public static void ChessBoard(GameState game)
        {
            Console.WriteLine($"\n\n     0    1    2    3    4    5    6    7              ");

            for (int row = 0; row < BOARD_HEIGHT; row++)
            {
                Console.Write("  ");
                for (int i = 0; i < BOARD_HEIGHT; i++)
                {
                    Console.Write("+----");
                }
                Console.Write("+");
                Console.WriteLine();

                for (int column = 0; column < BOARD_WIDTH; column++)
                {
                    if (column == 0)
                    {
                        Console.Write(row + " ");
                    }
                    Console.Write("|");

                    Console.OutputEncoding = System.Text.Encoding.UTF8;

                    if (row % 2 == 0 && column % 2 != 0 || row % 2 != 0 && column % 2 == 0)
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                    else
                        Console.BackgroundColor = ConsoleColor.DarkGray;

                    var name = game.Board[column, row]?.Name ?? "null";

                    Console.OutputEncoding = System.Text.Encoding.UTF8;

                    if (game.Board[column, row].Color == Color.Dark)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        if (name == "\u265F")
                            Console.Write($" {name} ");
                        else
                            Console.Write($" {name}  ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        if (name == "\u265F")
                            Console.Write($" {name} ");
                        else
                            Console.Write($" {name}  ");
                    }

                    Console.ResetColor();

                    PlayerInfo(game, row, column);
                }
                if (row > 0 && row < BOARD_HEIGHT-1)
                    Console.Write("|\n");
            }

            Console.Write("  ");
            for (int j = 0; j < BOARD_WIDTH; j++)
            {
                Console.Write("+----");
            }
            Console.Write("+");
            Console.WriteLine();

            Console.WriteLine("============================================");
        }

        /// <summary>
        /// Prints out player info.
        /// </summary>
        /// <param name="game">Gamestate.</param>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        private static void PlayerInfo(GameState game, int row, int column)
        {
            if (row == 0 && column == BOARD_WIDTH - 1)
            {
                Console.WriteLine($"|    Player 1(WHITE): {game.Player1.Id}");
            }
            if (row == BOARD_WIDTH - 1 && column == BOARD_WIDTH - 1)
            {
                Console.WriteLine($"|    Player 2(BLACK): {game.Player2.Id}");
            }
        }
    }
}
