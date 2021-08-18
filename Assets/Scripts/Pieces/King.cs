using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece
{
    public override List<Square> ShowPath(Square[,] squares)
    {
        List<Square> squaresToAccess = new List<Square>();

        for (int i = 1; i < 2; i++)
        {
            if (position.y + i <= 7 && position.x + i <= 7)
            {
                Square square = SetAccessToSquare(i, i, squares);
                if (square != null)
                {
                    squaresToAccess.Add(square);
                    if (square.currentPiece != null)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }
        for (int i = 1; i < 2; i++)
        {

            if (position.y - i >= 0 && position.x - i >= 0)
            {
                Square square = SetAccessToSquare(-i, -i, squares);
                if (square != null)
                {
                    squaresToAccess.Add(square);
                    if (square.currentPiece != null)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }
        for (int i = 1; i < 2; i++)
        {

            if (position.x + i <= 7 && position.y - i >= 0)
            {
                Square square = SetAccessToSquare(i, -i, squares);
                if (square != null)
                {
                    squaresToAccess.Add(square);
                    if (square.currentPiece != null)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }
        for (int i = 1; i < 2; i++)
        {
            if (position.x - i >= 0 && position.y + i <= 7)
            {
                Square square = SetAccessToSquare(-i, i, squares);
                if (square != null)
                {
                    squaresToAccess.Add(square);
                    if (square.currentPiece != null)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }
        for (int i = 1; i < 2; i++)
        {
            if (position.y + i <= 7)
            {
                Square square = SetAccessToSquare(0, i, squares);
                if (square != null)
                {
                    squaresToAccess.Add(square); 
                    if (square.currentPiece != null)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }
        for (int i = 1; i < 2; i++)
        {
            if (position.x + i <= 7)
            {
                Square square = SetAccessToSquare(i, 0, squares);
                if (square != null)
                {
                    squaresToAccess.Add(square); 
                    if (square.currentPiece != null)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        for (int i = 1; i < 2; i++)
        {
            if (position.y - i >= 0)
            {
                Square square = SetAccessToSquare(0, -i, squares);
                if (square != null)
                {
                    squaresToAccess.Add(square); 
                    if (square.currentPiece != null)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        for (int i = 1; i < 2; i++)
        {
            if (position.x - i >= 0)
            {
                Square square = SetAccessToSquare(-i, 0, squares);
                if (square != null)
                {
                    squaresToAccess.Add(square); 
                    if (square.currentPiece != null)
                    {
                        break;
                    }
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
