using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PrintShape
{
    internal class Shape
    {
        private int numRows;
        private int numCols;
        private int numDotsPerSideCols;
        private int numRowsMax = 20;
        private int numRowsMin = 1;

        private StringBuilder sb;
        private StringBuilder fb;

        private const string ACTION_MESSAGE =
            "Decide what you want to do: " +
            "\n(1) Enlarge\n(2) Reduce";
        private const string NUMBER_MESSAGE =
            "Decide how many rows (both up and down): " +
            "\n(1) One\n(2) Two";
        private const string INPUT_MESSAGE =
            "Insert your choice (1 or 2): ";
        private const string ERROR_MESSAGE =
            "Make your answer just 1 or 2: ";

        public Shape()
        {
            numRows = 2;
            numCols = (numRows * 2) + 1;
            sb = new StringBuilder("*");
            RefreshDotsPerSideCols();
        }

        public void DisplayShape()
        {   
            fb = new StringBuilder(
                String.Concat(Enumerable.Repeat(".", numDotsPerSideCols)));
            int numColsTemp = numCols;
            WriteLine();
            for(int i = 0; i < numRows; i++)
            {
                WriteLine(fb.ToString() + sb.ToString() + fb.ToString());
                sb.Append("**");
                
                fb.Remove(numDotsPerSideCols - 1, 1);
                numDotsPerSideCols--;
            }
            WriteLine(sb.ToString());
            for(int i = 0; i < numRows; i++)
            {
                sb.Remove(numColsTemp-2, 2);
                numColsTemp -= 2;
                fb.Append(".");
                WriteLine(fb.ToString() + sb.ToString() + fb.ToString());
            }
            WriteLine();
        }

        public bool DecideActionAndNumber()
        {
            int numAction, numRowsChange;
            WriteLine(ACTION_MESSAGE);
            numAction = GetNumber();
            WriteLine(NUMBER_MESSAGE);
            numRowsChange = GetNumber();
            if(numAction == 1)
            {
                return Enlarge(numRowsChange);
            } else
            {
                return Reduce(numRowsChange);
            }
        }

        private void RefreshDotsPerSideCols()
        {
            numDotsPerSideCols = (numCols - 1 )/ 2;
        }

        private int GetNumber()
        {   
            string input;
            int answer;
            Write(INPUT_MESSAGE);
            input = Console.ReadLine();
            while((!int.TryParse(input, out answer)) | 
                (answer != 1 & answer != 2))
            {
                Write(ERROR_MESSAGE);
                input = Console.ReadLine();
            }
            return answer;
        }
        
        private bool Enlarge(int numNewRows)
        {
            if ((numRows + numNewRows) > numRowsMax)
            {
                WriteLine("You cannot enlarge beyond " + numRowsMax + " rows per side." +
                    "\n////ACTION CANCELLED////, try with reducing");
                return false;
            }
            else
            {   
                WriteLine("Enlargement Done Succesfully");
                numRows += numNewRows;
                numCols += (numNewRows *2);
                RefreshDotsPerSideCols();
                return true;
            }
        }

        private bool Reduce(int numOldRows)
        {
            if ((numRows - numOldRows) < numRowsMin)
            {
                WriteLine("You cannot reduce below " + numRowsMin + " rows per side."+
                    "\n////ACTION CANCELLED////, try with enlarging");
                return false;
            } else
            {
                WriteLine("Reduction Done Successfully");
                numRows -= numOldRows;
                numCols -= (numOldRows * 2);
                RefreshDotsPerSideCols();
                return true;
            }
        }

        public int Rows
        {
            get { return numRows; }
            set { numRows = value; }
        }
    }
}
