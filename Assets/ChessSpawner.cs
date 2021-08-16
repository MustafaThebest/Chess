using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessSpawner : MonoBehaviour
{
    [SerializeField] private Pawn pawnPrefab;
    [SerializeField] private Rook rookPrefab;
    [SerializeField] private Knight knightPrefab;
    [SerializeField] private Bishop bishopPrefab;
    [SerializeField] private Queen queenPrefab;
    [SerializeField] private King kingPrefab;

    public void Start()
    {
        SpawnPieces();
    }

    public void SpawnPieces()
    {
        SpawnPawns(1);
        SpawnRooks(0);
        SpawnKnights(0);
        SpawnBishops(0);
        SpawnRoyal(0);
    }

    public void SpawnPawns(int row)
    {
        for (int i = 0; i < 8; i++)
        {
            Pawn pawn = Instantiate(pawnPrefab);
            ChessBoard.Instance.squares[i, row].SetPiece(pawn);
        }
    }

    public void SpawnRooks(int row)
    {
        Rook rook1 = Instantiate(rookPrefab);
        Rook rook2 = Instantiate(rookPrefab);
        ChessBoard.Instance.squares[0, row].SetPiece(rook1);
        ChessBoard.Instance.squares[7, row].SetPiece(rook2);
    }

    public void SpawnKnights(int row)
    {
        Knight knight1 = Instantiate(knightPrefab);
        Knight knight2 = Instantiate(knightPrefab);
        ChessBoard.Instance.squares[1, row].SetPiece(knight1);
        ChessBoard.Instance.squares[6, row].SetPiece(knight2);
    }

    public void SpawnBishops(int row)
    {
        Bishop bishop1 = Instantiate(bishopPrefab);
        Bishop bishop2 = Instantiate(bishopPrefab);
        ChessBoard.Instance.squares[2, row].SetPiece(bishop1);
        ChessBoard.Instance.squares[5, row].SetPiece(bishop2);
    }

    public void SpawnRoyal(int row)
    {
        King bishop1 = Instantiate(kingPrefab);
        Queen bishop2 = Instantiate(queenPrefab);
        ChessBoard.Instance.squares[3, row].SetPiece(kingPrefab);
        ChessBoard.Instance.squares[4, row].SetPiece(queenPrefab);
    }
}
