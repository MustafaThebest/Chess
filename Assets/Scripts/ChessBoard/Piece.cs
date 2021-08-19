using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    public bool isSelected;

    public Vector2 position;

    public bool isBlack;

    public static Action<Piece> OnSelect;
    public Action OnMove;
    public static Action OnTurn;
    public static Action<bool> OnKingDeath;

    private void Update()
    {
        ChangeAccessState();
    }

    public void OnMouseDown()
    {
        if (GameManager.Instance.isBlackTurn == isBlack)
        {
            ChessBoard.Instance.DiselectPieces();

            Select(!isSelected);
        }
    }

    public void Move(Square square)
    {
        position = square.position;

        if (square.currentPiece != null)
        {
            if(square.currentPiece.GetComponent<King>())
            {
                OnKingDeath?.Invoke(isBlack);
                return;
            }
            Destroy(square.currentPiece.gameObject);
        }

        transform.position = new Vector3(square.transform.position.x, 1, square.transform.position.z);

        //To detect piece move
        OnMove?.Invoke();
        OnTurn?.Invoke();

        Select(false);
    }

    public abstract List<Square> ShowPath(Square[,] squares);

    public Square SetAccessToSquare(int x, int y, Square[,] squares)
    {
        Square square = squares[(int)position.x + x, (int)position.y + y];
        //print(((int)position.x + x) + " " + ((int)position.y + y));
        if (square.currentPiece == null)
        {
            square.isAccessible = true;
            return square;
        }
        else
        {
            if (square.currentPiece.isBlack != isBlack)
            {
                square.isAccessible = true;
                return square;
            }
            else
            {
                square.isAccessible = false;
                return null;
            }
        }
    }

    public void Select(bool isSelected)
    {
        this.isSelected = isSelected;

        if (isSelected)
        {
            OnSelect?.Invoke(this);
        }
        else
        {
            OnSelect?.Invoke(null);
        }
    }

    public void ChangeAccessState()
    {
        if(GameManager.Instance.isBlackTurn == isBlack)
        {
            GetComponent<BoxCollider>().enabled = true;
        } else
        {
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}

