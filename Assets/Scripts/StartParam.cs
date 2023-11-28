using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DifficultyTime
{
    Easy = 210,
    Normal = 180,
    Hard = 150,
}

public enum DifficultyKey
{
    Easy = 0,
    Normal = 1,
    Hard = 2,
}


[CreateAssetMenu(fileName = "StartParam", menuName = "ScriptableObjects/StartParam", order = 1)]
public class StartParam : ScriptableObject
{
    public DifficultyTime DifficultyTime;

    public DifficultyKey DifficultyKey;

    [SerializeField] private List<QTEButtons> _listQTEButtons;

    public List<QTEButton> QTEButtons
    {
        get
        {
            return _listQTEButtons[(int)DifficultyKey].Buttons;
        }
    }

}
