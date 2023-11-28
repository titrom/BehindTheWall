using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brick : MonoBehaviour
{
    [SerializeField] private Image _imageBrick;
    [SerializeField] private Image _imageButtom;


    [SerializeField] private AudioClip _ok;
    [SerializeField] private AudioClip _lose;

    public Action OnPress;

    private AudioSource _audio;


    private bool _isStarting = false;
    private KeyCode _key;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void StartQTE(QTEButton qTEButton)
    {
        _isStarting = true;
        _key = qTEButton.keyCode;
        _imageButtom.sprite = qTEButton.buttonTexture;

        _imageButtom.gameObject.SetActive(true);
    }

    public void Activate()
    {
        _imageBrick.gameObject.SetActive(true);
        gameObject.GetComponent<Image>().enabled = true;
    }

    public void UpdateBrickImage(Sprite sprite)
    {
        _imageBrick.sprite = sprite;
    }

    private void StopQTE()
    {
        _isStarting = false;
        _imageBrick.gameObject.SetActive(false);
        gameObject.GetComponent<Image>().enabled = false;
        _imageButtom.gameObject.SetActive(false);

    }

    private void Update()
    {
        if (_isStarting)
        {
            if (Input.GetKeyDown(_key))
            {
                _audio.clip = _ok;
                _audio.Play();
                OnPress.Invoke();
                StopQTE();
            }
            else if(Input.anyKeyDown)
            {
                _audio.clip = _lose;
                _audio.Play();

                GameObject.Find("Game").GetComponent<Game>().GamePenalty();
            }


        }
    }


}
