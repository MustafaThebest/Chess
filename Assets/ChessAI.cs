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
            //Random
            SetPiece();
            //Minimax
            //MiniMax(1, isBlackTeam);
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
                    Move move = new Move
                    {
                        piece = item,
                        square = square
                    };
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

    public int GetTeamScore(bool isBlackTeam)
    {
        int teamScore = 0;

        foreach (var item in FindObjectsOfType<Piece>())
        {
            if (item.isBlack)
            {
                teamScore += item.pieceValue;
            }
        }

        return teamScore;
    }

    public int Evaluate(bool isBlackTeam)
    {
        return GetTeamScore(isBlackTeam) - GetTeamScore(!isBlackTeam);
    }

    public int MiniMax(int depth, bool isBlackTeam)
    {
        if (depth == 0)
        {
            return Evaluate(isBlackTeam);
        }

        Move bestMove = moves[UnityEngine.Random.Range(0, moves.Count)];

        if (isBlackTeam)
        {
            int max_eval = int.MinValue;
            foreach (var move in moves)
            {
                Vector2 lastSquare = move.piece.position;
                move.square.SetPiece(move.piece);

                int current_evaluation = MiniMax(depth - 1, !isBlackTeam);
                ChessBoard.Instance.squares[(int)lastSquare.x, (int)lastSquare.y].SetPiece(move.piece);

                if (current_evaluation > max_eval)
                {
                    max_eval = current_evaluation;
                    bestMove = move;
                }
            }
            return max_eval;
        }
        else
        {
            int min_eval = int.MaxValue;
            foreach (var move in moves)
            {
                Vector2 lastSquare = move.piece.position;
                move.square.SetPiece(move.piece);

                int current_evaluation = MiniMax(depth - 1, isBlackTeam);
                ChessBoard.Instance.squares[(int)lastSquare.x, (int)lastSquare.y].SetPiece(move.piece);

                if (current_evaluation < min_eval)
                {
                    min_eval = current_evaluation;
                    bestMove = move;
                }
            }
            return min_eval;
        }
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
