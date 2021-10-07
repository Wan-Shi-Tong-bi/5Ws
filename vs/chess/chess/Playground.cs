using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Playground
    {
        

        private static void DrawBorder()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;

            char[] arrAlph = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            for (int i = 0; i < arrAlph.Length; i++)
            {
                Console.Write("     " + arrAlph[i]);
            }
            Console.Write(" ");
            Console.WriteLine($"  \n  {String.Concat(Enumerable.Repeat("0", 49))}");

        }

        private static void DrawWhiteBlack(Dictionary<string, PlayFigure> dicFigures)
        {
            bool white = false;
            for (int y = 8; y > 0; y--)
            {
                white = !white;
                Console.BackgroundColor = ConsoleColor.DarkGray;

                for (int t = 0; t < 3; t++)
                {
                    if (t == 1)
                    {
                        Console.Write($"{y} 0");
                    }
                    else
                    {
                        Console.Write("  0");
                    }
                    for (int x = 0; x < 8; x++)
                    {
                        SetBack(white);
                        
                        if (t == 1)
                        {
                            try
                            {
                                int xt = x + 1;
                                PlayFigure figure = dicFigures[new Position { PosY = y, PosX = xt }.ToString()];
                                Console.Write(" ");
                                SetBack(figure.IsWhite);
                                char bw = figure.IsWhite ? 'w' : 'b';
                                Console.Write($"{bw} {figure.Fig}");

                                SetBack(white);
                                Console.Write(" ");
                            }
                            catch (KeyNotFoundException)
                            {
                                Console.Write(String.Concat(Enumerable.Repeat(" ", 5)));
                            }
                        }
                        else
                        {
                            Console.Write(String.Concat(Enumerable.Repeat(" ", 5)));
                        }
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Write("0");
                        white = !white;
                    }
                    if (t != 2)
                    {
                        Console.Write("\n");
                    }
                }
                Console.WriteLine($"\n  {String.Concat(Enumerable.Repeat("0", 49))}");
            }

        }

        public static void SetBack(bool white)
        {
            if (white)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void DrawBoard(Dictionary<string,PlayFigure> dicFigures)
        {
            DrawBorder();
            DrawWhiteBlack(dicFigures);
        }

    }

   


}
