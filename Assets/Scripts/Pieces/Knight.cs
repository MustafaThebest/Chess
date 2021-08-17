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

        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                if(SetAccessToSquare(j, i, squares) != null)
                {
                    Square square = SetAccessToSquare(j, i, squares);
                
                    squaresToAccess.Add(square);
                }

            }
        }

        return squaresToAccess;
    }
}
