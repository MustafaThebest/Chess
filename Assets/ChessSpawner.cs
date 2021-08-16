using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessSpawner : MonoBehaviour
{
    [SerializeField] private Pawn pawnPrefab;
    [SerializeField] private Rook rookPrefab;
    [SerializeField] private Knight knightPrefab;
    [SerializeField] private Queen queenPrefab;
    [SerializeField] private King kingPrefab;

    public void Start()
    {
        SpawnPieces();
    }

    public void SpawnPieces()
    {
        SetPawns(1);
    }

    public void SetPawns(int row)
    {
        for (int i = 0; i < 1; i++)
        {
            Pawn pawn = Instantiate(pawnPrefab);
            ChessBoard.Instance.squares[i, row].SetPiece(pawn);
        }
    }
}
