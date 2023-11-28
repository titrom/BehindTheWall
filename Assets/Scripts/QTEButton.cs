using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "QTEButton", menuName = "ScriptableObjects/QTEButton", order = 1)]
public class QTEButton : ScriptableObject
{
    public Sprite buttonTexture;
    public KeyCode keyCode;
}
