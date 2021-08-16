using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    public bool isSelected;

    public Vector2 position;

    public static Action<Piece> OnSelect;
    public Action OnMove;

    public void OnMouseDown()
    {
        ChessBoard.Instance.DiselectPieces();

        Select(!isSelected);
    }

    public void Move(Square square)
    {
        position = square.position;
        transform.position = new Vector3(square.transform.position.x, 1, square.transform.position.z);

        //To detect piece move
        OnMove?.Invoke();

        Select(false);
    }

    public abstract List<Square> ShowPath(Square[,] squares);

    public Square SetAccessToSquare(int x, int y, Square[,] squares)
    {
        Square square = squares[(int)position.x + x, (int)position.y + y];
        if(square.currentPiece == null)
        {
            square.isAccessible = true;
            return square;
        }
        return null;
    }

    public void Select(bool isSelected)
    {
        this.isSelected = isSelected;

        print("select");

        if (isSelected)
        {
            OnSelect?.Invoke(this);
        }
        else
        {
            OnSelect?.Invoke(null);
        }
    }
}
