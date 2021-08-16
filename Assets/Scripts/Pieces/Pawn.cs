using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    public override List<Square> ShowPath(Square[,] squares)
    {
        List<Square> squaresToAccess = new List<Square>();

        for (int i = 1; i < 3; i++)
        {
            if(position.y + i <= 7 && position.x <= 7)
            {
                Square square = SetAccessToSquare(0, i, squares);
                if (square != null)
                {
                    squaresToAccess.Add(square);
                }
                else
                {
                    break;
                }
            }
        }

        return squaresToAccess;
    }
}
