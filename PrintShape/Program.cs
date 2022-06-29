using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PrintShape
{
    internal class Program
    {
        const string START_MESSAGE = "---------------------------\nINSERT 1 TO START THE GAME, OR SOMETHING ELSE TO EXIT: ";
        const string CONTINUE_MESSAGE = "---------------------------\nINSERT 1 TO CONTINUE THE GAME, OR SOMETHING ELSE TO EXIT: ";
        const string END_MESSAGE = "---------------------------\n/////////GAME FINISHED/////////\nNUMBER OF MOVES: ";

        static bool KeepPlaying(string message)
        {
            string input;
            int value;
            Write(message);
            input = ReadLine();
            if ((int.TryParse(input,out value)) & value == 1)
            {
                return true;
            } else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            int moves = 0;
            bool keepPlaying;
            Shape shape = new Shape();
            while(true)
            {
                if(moves == 0)
                {
                    keepPlaying = KeepPlaying(START_MESSAGE);
                    if(keepPlaying) shape.DisplayShape();
                } else
                {
                    keepPlaying = KeepPlaying(CONTINUE_MESSAGE);
                }

                if(!keepPlaying) break;
                moves++;

                if (shape.DecideActionAndNumber())
                {
                    shape.DisplayShape();
                }
                
            }
            
            WriteLine(END_MESSAGE + moves);

            ReadKey();
        }
    }
}
