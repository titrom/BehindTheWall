using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private StartParam _param;

    public void StartGame()
    {
        var time = GameObject.Find("DifficultyTimeDrop").GetComponent<Dropdown>().value;
        _param.DifficultyTime = time == 1 ? DifficultyTime.Normal : time == 2 ? DifficultyTime.Hard : DifficultyTime.Easy;
        var qte = GameObject.Find("DifficultyKeyDrop").GetComponent<Dropdown>().value;
        _param.DifficultyKey = (DifficultyKey)qte;
        SceneManager.LoadScene(1);
    }
}
