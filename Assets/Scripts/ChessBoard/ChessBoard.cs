using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    [Header("ChessBoard Settings")]
    public Square[,] squares = new Square[8, 8];
    public GameObject squarePrefab;
    public Material[] squareMaterials = new Material[2];
    public Material accessSquareMaterial;

    [Header("ChessBoard Variables")]
    public Piece selectedPiece;

    public static ChessBoard Instance;

    public void Awake()
    {
        CreateInstance();

        SetSquares();

        Piece.OnSelect += SetPieceAccess;
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

    public void SetPieceAccess(Piece piece)
    {
        selectedPiece = piece;

        if (piece != null)
        {
            EnableAccesability(piece);
        }
        else
        {
            DisableAccesability();
        }
    }

    public void EnableAccesability(Piece piece)
    {
        for (int i = 0; i < 3; i++)
        {
            //XREN
            Square square = squares[(int)piece.position.x, (int)piece.position.y + i];
            square.isAccessible = true;

            SetSquareAccessMaterial(square);
        }
    }

    public void DisableAccesability()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Square square = squares[i, j];
                square.isAccessible = false;

                SetSquareBirthMaterial(square);
            }
        }
    }

    public void SetSquares()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                float iPos = i - (transform.localScale.x / 2 - 0.5f);
                float jPos = j - (transform.localScale.z / 2 - 0.5f);

                Square square = Instantiate(squarePrefab, new Vector3(jPos, 0.55f, iPos), transform.rotation, transform).GetComponent<Square>();

                InitSquareMaterial(square, i, j);

                square.position = new Vector2(j, i);

                squares[j, i] = square;
            }
        }
    }

    /// <summary>
    /// Initializes birth material to squares.
    /// </summary>
    private void InitSquareMaterial(Square square, int i, int j)
    {
        if ((i % 2 != 0 && j % 2 != 0) || (i % 2 == 0 && j % 2 == 0))
        {
            Material material = squareMaterials[0];

            square.GetComponent<Renderer>().material = material;
            square.squareMaterial = material;
        }
        else
        {
            Material material = squareMaterials[1];

            square.GetComponent<Renderer>().material = material;
            square.squareMaterial = material;
        }
    }

    private void SetSquareAccessMaterial(Square square)
    {
        square.GetComponent<Renderer>().material = accessSquareMaterial;
    }

    private void SetSquareBirthMaterial(Square square)
    {
        square.GetComponent<Renderer>().material = square.squareMaterial;
    }
}
