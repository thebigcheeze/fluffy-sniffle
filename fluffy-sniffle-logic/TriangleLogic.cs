using System;
using System.Linq;

namespace fluffy_sniffle_logic
{
    public static class TriangleLogic
    {
        public static Vertex[] FindVerticiesOfTriangle(char row, int column)
        {
            Vertex[] response = new Vertex[3];
            
            // We should multiply actual row by 10 due to the fact that each row is 10 pixels high.
            int actualRow = (row - 'A') * 10;

            bool isEvenColumn = column % 2 == 0;

            // We must subtract column by 1 because numbering begins as 1 based but the math is easier if it is converted to 0 based first.
            int normalizedColumn = (column - 1) / 2;

            // We should multiply column by 10 due to the fact that each column is 10 pixels wide.
            int actualColumn = normalizedColumn * 10;

            // The two verticies that make up the hypotenuse are the same regardless of if the column is even or odd.
            response[0] = new Vertex { X = actualColumn, Y = actualRow };
            response[2] = new Vertex { X = actualColumn + 10, Y = actualRow + 10 };

            // The vertex oposite the hypotenuse is different if the column was even or odd
            response[1] = isEvenColumn ?
                new Vertex { X = actualColumn + 10, Y = actualRow } :
                new Vertex { X = actualColumn, Y = actualRow + 10 };

            return response;
        }

        public static Tuple<char, int> FindTriangleFromVerticies(Vertex[] verticies)
        {
            char row;
            int column;

            var orderedVerticies = verticies.OrderBy(vertex => vertex.X + vertex.Y).ToArray();

            // We just do the inverse of the math found in FindVerticiesOfTriangles
            row = (char)((orderedVerticies[0].Y / 10) + 'A');

            // Divide by 5 because the actual math is divide 10, multiply 2, so divide 5 is a simplification of that.
            // Subtract 5 whenever the X's are different because that means that it was originally an even number and we need to recover the 1 value that was lost during integer division above.
            column = ((orderedVerticies[1].X - (orderedVerticies[1].X > orderedVerticies[0].X ? 5 : 0)) / 5) + 1;

            Tuple<char, int> response = new Tuple<char, int>(row, column);

            return response;
        }

    }
}
