using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : ScriptableObject
{
    public Piece piece { get; set; }
    public Square square { get; set; }
}
