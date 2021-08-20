using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isBlackTurn;

    public static GameManager Instance;

    public static Action<bool> OnTeamChange;

    public bool isChangeble;

    public void Awake()
    {
        CreateInstance();
    }

    public void Start()
    {
        isBlackTurn = false;
        
        Piece.OnTurn += ChangeTeam;
        ChessSpawner.OnPiecesLoad += GetChangeAccess;
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

    public void GetChangeAccess(bool isChangeble)
    {
        isBlackTurn = !ChessAI.Instance.isBlackTeam;
        this.isChangeble = isChangeble;
    }

    public void ChangeTeam()
    {
        if(isChangeble)
        {
            isBlackTurn = !isBlackTurn;
            OnTeamChange?.Invoke(isBlackTurn);
        }
    }

}
