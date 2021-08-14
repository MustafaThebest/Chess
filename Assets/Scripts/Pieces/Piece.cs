using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{ 
    public bool isSelected;

    public int xPos;
    public int yPos;

    public static Action<Piece> OnSelect;

    public void OnMouseDown()
    {
        isSelected = !isSelected;

        if(isSelected)
        {
            OnSelect?.Invoke(this);
        } else
        {
            OnSelect?.Invoke(null);
        }
    }

    public abstract void Move(Vector3 position);
}
