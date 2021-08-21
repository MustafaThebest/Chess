using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    public int turnsCount = 3;

    public void Start()
    {
        turnsCount = 3;
    }

    public override List<Square> ShowPath(Square[,] squares)
    {
        List<Square> squaresToAccess = new List<Square>();

        if (!isBlack)
        {
            for (int i = 1; i < turnsCount; i++)
            {
                if (position.y + i <= 7 && position.x <= 7)
                {
                    Square square = GetSquareInfo(0, i, squares);
                    if (square != null)
                    {
                        if (square.currentPiece != null)
                        {
                            break;
                        }
                        else
                        {
                            square.isAccessible = true;
                            squaresToAccess.Add(square);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (position.x + 1 <= 7 && position.y + 1 <= 7)
            {
                Square square = GetSquareInfo(1, 1, squares);
                if (square != null)
                {
                    if(square.currentPiece != null)
                    {
                        square.isAccessible = true;
                        squaresToAccess.Add(square);
                    }
                }
            }

            if (position.x - 1 >= 0 && position.y + 1 <= 7)
            {
                Square square = GetSquareInfo(-1, 1, squares);
                if (square != null)
                {
                    if (square.currentPiece != null)
                    {
                        square.isAccessible = true;
                        squaresToAccess.Add(square);
                    }
                }
            }

        }
        else
        {
            for (int i = 1; i < turnsCount; i++)
            {
                if (position.y - i >= 0 && position.x <= 7)
                {
                    Square square = GetSquareInfo(0, -i, squares);
                    if (square != null)
                    {
                        if (square.currentPiece != null)
                        {
                            break;
                        }
                        else
                        {
                            square.isAccessible = true;
                            squaresToAccess.Add(square);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (position.x - 1 >= 0 && position.y - 1 >= 0)
            {
                Square square = GetSquareInfo(-1, -1, squares);
                if (square != null)
                {
                    if (square.currentPiece != null)
                    {
                        square.isAccessible = true;
                        squaresToAccess.Add(square);
                    }
                }
            }

            if (position.x + 1 <= 7 && position.y - 1 >= 0)
            {
                Square square = GetSquareInfo(1, -1, squares);
                if (square != null)
                {
                    if (square.currentPiece != null)
                    {
                        square.isAccessible = true;
                        squaresToAccess.Add(square);
                    }
                }
            }
        }

        return squaresToAccess;
    }

    public Square GetSquareInfo(int x, int y, Square[,] squares)
    {
        Square square = squares[(int)position.x + x, (int)position.y + y];
        //print(((int)position.x + x) + " " + ((int)position.y + y));
        if (square.currentPiece == null)
        {
            return square;
        }
        else
        {
            if (square.currentPiece.isBlack != isBlack)
            {
                return square;
            }
            else
            {
                return null;
            }
        }
    }
}
