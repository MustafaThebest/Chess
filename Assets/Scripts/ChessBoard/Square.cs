using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public Vector2 position;

    public bool isAccessible;
    public bool isAttackable;
    public Piece currentPiece;

    public Material squareMaterial;

    public void OnMouseDown()
    {
        if(isAccessible)
        {
            SetPiece(ChessBoard.Instance.selectedPiece);
        }
    }

    public void SetPiece(Piece piece)
    {
        piece.Move(this);
        piece.OnMove += RemovePiece;
        
        currentPiece = piece;
    }

    public void RemovePiece(Piece piece)
    {
        piece.OnMove -= RemovePiece;
        currentPiece = null;
    }
}
