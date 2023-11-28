using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lose : MonoBehaviour
{
    [SerializeField] private Text _result;

    [SerializeField] private int _countLoseMusic;

    [SerializeField] private AudioSource _audio;
    private void Start()
    {
        _result.text = $"Your result:\n{GameResult.GetResult()}";
    }

    private void Update()
    {
        if (!_audio.isPlaying && _countLoseMusic != 0)
        {
            _audio.Play();
            _countLoseMusic--;
        }
    }
}
