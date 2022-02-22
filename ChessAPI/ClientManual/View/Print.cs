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

        public static void Header()
        {
            string header = "             CONSOLE CHESS BY GROUP 2               \n";
            Console.WriteLine(header);
        }
        public static void Menu()
        {
            Console.WriteLine("(N)EW GAME         (L)OAD Game         (E)XIT");
        }
        public static void ChessBoard(int counter, GameState game)
        {
            Console.WriteLine($"\n\n     0    1    2    3    4    5    6    7              Round: {counter}");

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

                    var name = game.Board[row, column]?.Name ?? "null";
                    Console.OutputEncoding = System.Text.Encoding.UTF8;

                    if (game.Board[row, column].Color == Color.Dark)
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
                    
                    if (game.Board[row, column].LegalNextMove)
                    {
                        Console.Write("  XX  ");
                    }
                    Console.ResetColor();

                    if (row == 0 && column == BOARD_WIDTH - 1)
                    {
                        Console.WriteLine($"|    Player 2(BLACK): {game.Player2.Id}");
                    }
                    else if (row == BOARD_WIDTH - 1 && column == BOARD_WIDTH - 1)
                        Console.Write($"|    Player 1(WHITE): {game.Player1.Id}");
                }
                if (row > 0)
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

        public static void Stats(GameState game)
        {
            Console.WriteLine("GameId: " + game.GameId);
            Console.WriteLine("Player1 Id: " + game.Player1.Id);
            Console.WriteLine("Player2 Id: " + game.Player2.Id);
            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();
        }

        public static void Turn(Player player)
        {
            if (player.Color == Color.Light)
            {
                Console.Write($"Player {player.Id}'s (WHITE) turn: ");
            }
            else
            {
                Console.Write($"Player {player.Id}'s (BLACK) turn: ");
            }
        }


    }
}
