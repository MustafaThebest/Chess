using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public int xCor;
    public int yCor;

    public bool isAccessible;

    public Piece currentPiece;

    public void OnMouseDown()
    {
        if(isAccessible)
        {
            SetPiecePosition(ChessBoard.Instance.selectedPiece);
        }
    }

    public void SetPiecePosition(Piece piece)
    {
        piece.Move(transform.position);
    }
}
