using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public Vector2 position;

    public bool isAccessible;
    public Piece currentPiece;

    public Material squareMaterial;

    public void OnMouseDown()
    {
        if(isAccessible)
        {
            SetPiecePosition(ChessBoard.Instance.selectedPiece);
        }
    }

    public void SetPiecePosition(Piece piece)
    {
        //change to float
        piece.Move(this);
        currentPiece = piece;
    }
}
