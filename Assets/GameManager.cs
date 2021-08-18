using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isBlackTurn;

    public static GameManager Instance;


    //public static Action<bool> OnTeamChange;

    public void Awake()
    {
        CreateInstance();
    }

    public void Start()
    {
        isBlackTurn = false;
        Piece.OnTurn += ChangeTeam;
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

    public void ChangeTeam()
    {
        isBlackTurn = !isBlackTurn;
        //OnTeamChange?.Invoke(isBlackTurn);
    }

}
