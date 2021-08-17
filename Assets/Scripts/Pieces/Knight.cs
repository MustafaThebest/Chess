using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
{
    public override List<Square> ShowPath(Square[,] squares)
    {
        List<Square> squaresToAccess = new List<Square>();

        int x = 1;
        int y = 2;

        //Top-Down
        if (position.x + x <= 7 && position.y + y <= 7)
        {
            Square square = SetAccessToSquare(x, y, squares);
            if (square != null)
            {
                squaresToAccess.Add(square);
            }
        }
        if (position.x - x >= 0 && position.y + y <= 7)
        {
            Square square = SetAccessToSquare(-x, y, squares);
            if (square != null)
            {
                squaresToAccess.Add(square);
            }
        }
        if (position.x + x <= 7 && position.y - y >= 0)
        {
            Square square = SetAccessToSquare(x, -y, squares);
            if (square != null)
            {
                squaresToAccess.Add(square);
            }
        }
        if (position.x - x >= 0 && position.y - y >= 0)
        {
            Square square = SetAccessToSquare(-x, -y, squares);
            if (square != null)
            {
                squaresToAccess.Add(square);
            }
        }

        //Right-Left
        if (position.x + x <= 7 && position.y + y <= 7)
        {
            Square square = SetAccessToSquare(y, x, squares);
            if (square != null)
            {
                squaresToAccess.Add(square);
            }
        }
        if (position.y - y >= 0 && position.x + x <= 7)
        {
            Square square = SetAccessToSquare(-y, x, squares);
            if (square != null)
            {
                squaresToAccess.Add(square);
            }
        }
        if (position.y + y <= 7 && position.x - x >= 0)
        {
            Square square = SetAccessToSquare(y, -x, squares);
            if (square != null)
            {
                squaresToAccess.Add(square);
            }
        }
        if (position.x - x >= 0 && position.y - y >= 0)
        {
            Square square = SetAccessToSquare(-y, -x, squares);
            if (square != null)
            {
                squaresToAccess.Add(square);
            }
        }


        return squaresToAccess;
    }
}
