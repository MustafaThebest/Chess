using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessAI : MonoBehaviour
{
    public bool isBlackTeam;

    public List<Move> moves;
    public List<Move> attackMoves;

    public static ChessAI Instance;

    private void Awake()
    {
        CreateInstance();
    }

    public void Start()
    {
        //CreateInstance();

        GameManager.OnTeamChange += MakeMove;
    }

    public void CreateInstance()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void MakeMove(bool isBlack)
    {
        if (isBlackTeam == isBlack)
        {
            moves.Clear();
            attackMoves.Clear();

            GetMoves(isBlack);
            GetAttackMoves();
            SetPiece();
            //Search(1, int.MinValue, int.MaxValue);
        }
    }

    public void GetMoves(bool isBalck)
    {
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

    public void GetAttackMoves()
    {
        foreach (var item in moves)
        {
            if (item.square.currentPiece != null)
            {
                attackMoves.Add(item);
            }
        }
    }

    public int CountEvaluation()
    {
        int blackEval = 0;
        int whiteEval = 0;

        foreach (var item in FindObjectsOfType<Piece>())
        {
            if(item.isBlack)
            {
                blackEval += item.pieceValue;
            } else
            {
                whiteEval += item.pieceValue;
            }
        }

        int evaluation = whiteEval - blackEval;

        return evaluation;
    }

    public int Search(int depth, int alpha, int beta)
    {
        if(depth == 0)
        {
            CountEvaluation();
        }

        if(moves.Count == 0)
        {
            return 0;
        }

        foreach (var move in moves)
        {
            Vector2 lastSquare = move.piece.position;
            move.square.SetPiece(move.piece);
            int evaluation = -Search(depth - 1, -alpha, -beta);
            ChessBoard.Instance.squares[(int)lastSquare.x, (int)lastSquare.y].SetPiece(move.piece);
            if(evaluation >= beta)
            {
                return beta;
            }

            alpha = Math.Max(alpha, evaluation);

        }

        return alpha;
    }

    public void SetPiece()
    {
        Move move;
        if (attackMoves.Count > 0)
        {
            move = attackMoves[UnityEngine.Random.Range(0, attackMoves.Count)];
        }
        else
        {
            move = moves[UnityEngine.Random.Range(0, moves.Count)];
        }

        Piece piece = move.piece;
        Square square = move.square;

        square.SetPiece(piece);
    }
}
