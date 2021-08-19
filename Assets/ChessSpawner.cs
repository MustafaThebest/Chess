using System;
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

    public static ChessSpawner Instance;

    public static Action<bool> OnPiecesLoad;

    public void Awake()
    {
        CreateInstance();
    }

    public void Start()
    {
        SpawnPieces();

        Piece.OnKingDeath += ReloadGame;
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

    public void ReloadGame(bool isBlack)
    {
        OnPiecesLoad?.Invoke(false);

        if (isBlack)
        {
            print("Black won!");
        }
        else
        {
            print("White won!");
        }

        ClearPieces();
        SpawnPieces();

        Piece.OnKingDeath += ReloadGame;
    }

    public void SpawnPieces()
    {
        SpawnTeam(true);
        SpawnTeam(false);

        OnPiecesLoad?.Invoke(true);
    }

    public void ClearPieces()
    {
        Piece.OnKingDeath -= ReloadGame;

        foreach (var item in FindObjectsOfType<Square>())
        {
            item.currentPiece = null;
        }

        foreach (var item in FindObjectsOfType<Piece>())
        {
            Destroy(item.gameObject);
        }
    }

    public void SpawnTeam(bool isBlack)
    {
        SpawnBishops(isBlack);
        SpawnRooks(isBlack);
        SpawnKnights(isBlack);
        SpawnRoyal(isBlack);
        SpawnPawns(isBlack);
    }

    public void SpawnPawns(bool isBlack)
    {
        if (isBlack)
        {
            for (int i = 0; i < 8; i++)
            {
                Pawn pawn = Instantiate(pawnPrefab, transform.position, new Quaternion(0, 180, 0, 0));
                pawn.GetComponent<Renderer>().material.color = Color.black;
                pawn.isBlack = true;
                ChessBoard.Instance.squares[i, 6].SetPiece(pawn);
            }
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                Pawn pawn = Instantiate(pawnPrefab);
                ChessBoard.Instance.squares[i, 1].SetPiece(pawn);
            }
        }
    }

    public void SpawnRooks(bool isBlack)
    {
        if (isBlack)
        {

            Rook rook1 = Instantiate(rookPrefab, transform.position, new Quaternion(0, 180, 0, 0));
            Rook rook2 = Instantiate(rookPrefab, transform.position, new Quaternion(0, 180, 0, 0));
            ChessBoard.Instance.squares[0, 7].SetPiece(rook1);
            ChessBoard.Instance.squares[7, 7].SetPiece(rook2);

            MakeBlack(rook1, rook2);
        }
        else
        {
            Rook rook1 = Instantiate(rookPrefab, transform.position, new Quaternion(0, 0, 0, 0));
            Rook rook2 = Instantiate(rookPrefab, transform.position, new Quaternion(0, 0, 0, 0));
            ChessBoard.Instance.squares[0, 0].SetPiece(rook1);
            ChessBoard.Instance.squares[7, 0].SetPiece(rook2);
        }
    }

    public void SpawnKnights(bool isBlack)
    {
        if (isBlack)
        {
            Knight knight1 = Instantiate(knightPrefab, transform.position, new Quaternion(0, 180, 0, 0));
            Knight knight2 = Instantiate(knightPrefab, transform.position, new Quaternion(0, 180, 0, 0));
            ChessBoard.Instance.squares[1, 7].SetPiece(knight1);
            ChessBoard.Instance.squares[6, 7].SetPiece(knight2);

            MakeBlack(knight1, knight2);
        }
        else
        {
            Knight knight1 = Instantiate(knightPrefab, transform.position, new Quaternion(0, 0, 0, 0));
            Knight knight2 = Instantiate(knightPrefab, transform.position, new Quaternion(0, 0, 0, 0));
            ChessBoard.Instance.squares[1, 0].SetPiece(knight1);
            ChessBoard.Instance.squares[6, 0].SetPiece(knight2);
        }
    }

    public void SpawnBishops(bool isBlack)
    {
        if (isBlack)
        {
            Bishop bishop1 = Instantiate(bishopPrefab, transform.position, new Quaternion(0, 180, 0, 0));
            Bishop bishop2 = Instantiate(bishopPrefab, transform.position, new Quaternion(0, 180, 0, 0));
            ChessBoard.Instance.squares[2, 7].SetPiece(bishop1);
            ChessBoard.Instance.squares[5, 7].SetPiece(bishop2);

            MakeBlack(bishop1, bishop2);
        }
        else
        {
            Bishop bishop1 = Instantiate(bishopPrefab, transform.position, new Quaternion(0, 0, 0, 0));
            Bishop bishop2 = Instantiate(bishopPrefab, transform.position, new Quaternion(0, 0, 0, 0));
            ChessBoard.Instance.squares[2, 0].SetPiece(bishop1);
            ChessBoard.Instance.squares[5, 0].SetPiece(bishop2);
        }
    }

    public void SpawnRoyal(bool isBlack)
    {
        if (isBlack)
        {
            King king = Instantiate(kingPrefab, transform.position, new Quaternion(0, 180, 0, 0));
            Queen queen = Instantiate(queenPrefab, transform.position, new Quaternion(0, 180, 0, 0));
            ChessBoard.Instance.squares[4, 7].SetPiece(king);
            ChessBoard.Instance.squares[3, 7].SetPiece(queen);

            MakeBlack(king, queen);
        }
        else
        {
            King king = Instantiate(kingPrefab, transform.position, new Quaternion(0, 0, 0, 0));
            Queen queen = Instantiate(queenPrefab, transform.position, new Quaternion(0, 0, 0, 0));
            ChessBoard.Instance.squares[4, 0].SetPiece(king);
            ChessBoard.Instance.squares[3, 0].SetPiece(queen);
        }
    }

    public void MakeBlack(Piece piece1, Piece piece2)
    {
        piece1.GetComponent<Renderer>().material.color = Color.black;
        piece2.GetComponent<Renderer>().material.color = Color.black;

        piece1.isBlack = true;
        piece2.isBlack = true;
    }
}
