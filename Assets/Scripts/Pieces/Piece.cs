using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    public bool isSelected;

    public Vector2 position;

    public static Action<Piece> OnSelect;

    public void OnMouseDown()
    {
        Select(!isSelected);
    }

    public void Move(Square square)
    {
        position = square.position;
        transform.position = new Vector3(square.transform.position.x, 1, square.transform.position.z);

        //set new position

        Select(false);
        Debug.Log("transfered!");
    }

    public void Select(bool isSelected)
    {
        this.isSelected = isSelected;
        
        if (isSelected)
        {
            OnSelect?.Invoke(this);
        }
        else
        {
            OnSelect?.Invoke(null);
        }
    }
}
