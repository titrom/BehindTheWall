using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameTimer : MonoBehaviour
{
    [SerializeField] private Text _timerText;

    [SerializeField] private float _time;
    private float _countdown;
    private bool _isGameStart = false;
    private void Start()
    {
        _countdown = _time;
        _isGameStart = true;
    }

    private void Update()
    {
        if (_isGameStart)
        {
            if (_countdown > 0)
            {
                _countdown -= Time.deltaTime;
                _timerText.text = $"{(int)_countdown}";
            }
            else
            {
                _isGameStart = false;
                _timerText.gameObject.SetActive(false);
                GetComponent<Game>().GameStart();
            }
        }
    }
}
