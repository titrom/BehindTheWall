using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private StartParam _startParam;

    [SerializeField] private Scrollbar _scrollbar;
    [SerializeField] private float _time;

    private float _countdown;
    private bool _isStartTimer = false;

    private void Start()
    {
        _time = (int)_startParam.DifficultyTime;
        //_isStartTimer = true;
        _countdown = _time;
    }

    private void Update()
    {
        if (_isStartTimer) TimerTick();
    }

    private void TimerTick()
    {
        if (_countdown > 0)
        {
            _countdown -= Time.deltaTime;
            _scrollbar.size = _countdown / _time;
        }
        else
        {
            gameObject.GetComponent<Game>().StopGame();
            StopTimer();
        }
    }

    public void Fine(float fine)
    {
        if (_countdown > 0)
            _countdown -= fine;
    }

    public void StartTimer()
    {
        _isStartTimer = true;
    }

    public string StopTimer()
    {
        _isStartTimer = false;
        
        return $"{(int)(_time - _countdown)}/{_time}";
    }
}
