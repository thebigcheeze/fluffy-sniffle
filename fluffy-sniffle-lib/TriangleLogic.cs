using System;

namespace fluffy_sniffle_lib
{
    public static class TriangleLogic
    {
        public static Vertex[] FindVerticiesOfTriangle(char row, int column)
        {
            Vertex[] response = new Vertex[3];
            
            if (row < 'A' || row > 'F')
            {
                throw new ArgumentException("Row must be between 'A' and 'F'");
            }

            // We should multiply actual row by 10 due to the fact that each row is 10 pixels high.
            int actualRow = (row - 'A') * 10;

            // We should multiply column by 10 due to the fact that each column is 10 pixels wide.
            int actualColumn = column * 10;

            bool isEvenColumn = column % 2 == 0;

            int normalizedColumn = column / 2;

            // The two verticies that make up the hypotenuse are the same regardless of if the column is even or odd.
            response[0] = new Vertex { X = actualColumn, Y = actualRow };
            response[2] = new Vertex { X = actualColumn + 10, Y = actualRow + 10 };

            // The vertex oposite the hypotenuse is different if the column was even or odd
            response[1] = isEvenColumn ? 
                new Vertex { X = actualColumn + 10, Y = actualRow } : 
                new Vertex { X = actualColumn, Y = actualRow + 10 };
            
            return response;
        }

    }
}
