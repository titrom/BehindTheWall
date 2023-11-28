using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "QTEButtons", menuName = "ScriptableObjects/QTEButtons", order = 1)]
public class QTEButtons : ScriptableObject
{
    public List<QTEButton> Buttons;
}
