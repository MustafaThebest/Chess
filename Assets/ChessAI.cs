using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessAI : MonoBehaviour
{
    public bool isBlackTeam;

    public List<Move> moves;

    public void Start()
    {
        GameManager.OnTeamChange += MakeMove;
    }

    public void MakeMove(bool isBlack)
    {
        if(isBlackTeam == isBlack)
        {
            GetMoves(isBlack);
            SetPiece();
        }
    }

    public void GetMoves(bool isBalck)
    {
        moves.Clear();

        foreach (var item in FindObjectsOfType<Piece>())
        {
            if (item.isBlack == isBalck)
            {
                List<Square> squares = item.ShowPath(ChessBoard.Instance.squares);
                foreach (var square in squares)
                {
                    Move move = new Move();
                    move.piece = item;
                    move.square = square;
                    moves.Add(move);
                }
            }
        }
    }

    public void SetPiece()
    {
        Move move = moves[Random.Range(0, moves.Count)];

        Piece piece = move.piece;
        Square square = move.square;

        square.SetPiece(piece);
    }
}
