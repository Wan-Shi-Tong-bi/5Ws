using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Program
    {

        static void Main(string[] args)
        {
            string input;

            Dictionary<string, PlayFigure> dicFigures = new Dictionary<string, PlayFigure> {
            {new Position{PosX=1, PosY=7}.ToString(), new Farmer{IsWhite=false} },
            {new Position{PosX=2, PosY=7}.ToString(), new Farmer{IsWhite=false} },
            {new Position{PosX=3, PosY=7}.ToString(), new Farmer{IsWhite=false} },
            {new Position{PosX=4, PosY=7}.ToString(), new Farmer{IsWhite=false} },
            {new Position{PosX=5, PosY=7}.ToString(), new Farmer{IsWhite=false} },
            {new Position{PosX=6, PosY=7}.ToString(), new Farmer{IsWhite=false} },
            {new Position{PosX=7, PosY=7}.ToString(), new Farmer{IsWhite=false} },
            {new Position{PosX=8, PosY=7}.ToString(), new Farmer{IsWhite=false} },
            {new Position{PosX=1, PosY=2}.ToString(), new Farmer{IsWhite=true} },
            {new Position{PosX=2, PosY=2}.ToString(), new Farmer{IsWhite=true} },
            {new Position{PosX=3, PosY=2}.ToString(), new Farmer{IsWhite=true} },
            {new Position{PosX=4, PosY=2}.ToString(), new Farmer{IsWhite=true} },
            {new Position{PosX=5, PosY=2}.ToString(), new Farmer{IsWhite=true} },
            {new Position{PosX=6, PosY=2}.ToString(), new Farmer{IsWhite=true} },
            {new Position{PosX=7, PosY=2}.ToString(), new Farmer{IsWhite=true} },
            {new Position{PosX=8, PosY=2}.ToString(), new Farmer{IsWhite=true} },
            {new Position{PosX=1, PosY=8}.ToString(), new Tower{IsWhite=false} },
            {new Position{PosX=8, PosY=8}.ToString(), new Tower{IsWhite=false} },
            {new Position{PosX=1, PosY=1}.ToString(), new Tower{IsWhite=true} },
            {new Position{PosX=8, PosY=1}.ToString(), new Tower{IsWhite=true} },
            {new Position{PosX=2, PosY=8}.ToString(), new Knigth{IsWhite=false} },
            {new Position{PosX=7, PosY=8}.ToString(), new Knigth{IsWhite=false} },
            {new Position{PosX=2, PosY=1}.ToString(), new Knigth{IsWhite=true} },
            {new Position{PosX=7, PosY=1}.ToString(), new Knigth{IsWhite=true} },
            {new Position{PosX=3, PosY=8}.ToString(), new Runner{IsWhite=false} },
            {new Position{PosX=6, PosY=8}.ToString(), new Runner{IsWhite=false} },
            {new Position{PosX=3, PosY=1}.ToString(), new Runner{IsWhite=true} },
            {new Position{PosX=6, PosY=1}.ToString(), new Runner{IsWhite=true} },
            {new Position{PosX=4, PosY=8}.ToString(), new Queen{IsWhite=false} },
            {new Position{PosX=4, PosY=1}.ToString(), new Queen{IsWhite=true} },
            {new Position{PosX=5, PosY=8}.ToString(), new King{IsWhite=false} },
            {new Position{PosX=5, PosY=1}.ToString(), new King{IsWhite=true} },
        };
            bool whiteTurn = true;
            string moveText = "It's your turn";
            do
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Playground.DrawBoard(dicFigures);
                Playground.SetBack(whiteTurn);
                if (whiteTurn)
                {
                    Console.WriteLine($"{moveText} white");
                }
                else
                {
                    Console.WriteLine($"{moveText} black");
                }
                input = Console.ReadLine();
                
                
                try
                {
                    if (input.Length != 5)
                    {
                        throw new FormatException();
                    }
                    string[] arr = input.Split('-');
                    if (arr[0].Equals(arr[1]))
                    {
                        throw new FormatException();
                    }
                    Position from = Position.Parse(arr[0]);
                    Position to = Position.Parse(arr[1]);
                    
                    var isOwner = whiteTurn == dicFigures[from.ToString()].IsWhite;
                    if (!isOwner && (to.PosX < 0 && to.PosX > 9 && to.PosY < 0 && to.PosY > 9))
                    {
                        throw new FormatException();
                    }
                    var error = dicFigures[from.ToString()].CanMove(from,to,ref dicFigures);
                    if (!error)
                    {
                        throw new FormatException();
                    }
                    
                    var listFig = dicFigures.Values.ToList();
                    int kings = 0;
                    foreach (var fig in listFig)
                    {
                        if (fig.Fig == 'K')
                        {
                            kings++;
                        }
                    }
                    if (kings < 2)
                    {
                        Console.Clear();
                        Playground.DrawBoard(dicFigures);
                        Console.BackgroundColor = ConsoleColor.Green;
                        if (whiteTurn)
                        {
                            Console.WriteLine($"white won");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"black won");
                            break;
                        }
                    }

                    whiteTurn = !whiteTurn;
                }
                catch (Exception ex)
                {
                    if (ex is KeyNotFoundException || ex is FormatException)
                    {
                        
                    }
                    else
                    {
                        throw ex;
                    }
                }
                
                
            } while (input.ToLower() != "ende");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.ReadLine();
        }
    }
}
