using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    [Header("ChessBoard Settings")]
    public Square[,] squares = new Square[8, 8];
    public GameObject squarePrefab;
    public Material[] squareMaterials = new Material[2];

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

        //Check if null
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

                if ((i % 2 != 0 && j % 2 != 0) || (i % 2 == 0 && j % 2 == 0))
                {
                    square.GetComponent<Renderer>().material = squareMaterials[0];
                }
                else
                {
                    square.GetComponent<Renderer>().material = squareMaterials[1];
                }

                square.xCor = j;
                square.yCor = i;

                squares[i, j] = square;
            }
        }
    }
}
