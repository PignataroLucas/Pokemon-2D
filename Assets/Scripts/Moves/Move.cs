using ScriptableObjectsScripts;
using UnityEngine;


public class Move
{
    public MoveAttributes MoveAttributes { get; set; }
       
    public int Pp { get; set; }

    public Move(MoveAttributes moveAttributes)
    {
        MoveAttributes = moveAttributes;
        Pp = moveAttributes.Pp;
    }
       
}
    

