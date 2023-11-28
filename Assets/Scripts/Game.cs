using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private List<QTEButton> _QTEbuttons;
    [SerializeField] private List<Brick> _bricks;
    [SerializeField] private List<Sprite> _sprites;

    [SerializeField] private RawImage _finalImage;
    [SerializeField] private GameObject _finalText;

    [SerializeField] private StartParam _startParam;

    [SerializeField] private float _timeFine;

    private GameTimer _timer;

    private Brick _currentBrick;

    private QTEButton _qTEButton;

    private List<Brick> _brickWarehouse;

    private bool _isGameStart = false;

    public void GameStart()
    {
        _isGameStart = true;
        _timer.StartTimer();
    }

    private void Awake()
    {
        _timer = GetComponent<GameTimer>();
        _brickWarehouse = new List<Brick>();

        switch (_startParam.DifficultyTime)
        {
            case DifficultyTime.Easy: _timeFine *= 1; break;
            case DifficultyTime.Normal: _timeFine *= 2; break;
            case DifficultyTime.Hard: _timeFine *= 3; break;
        }
    }

    private void Start()
    {
        for (int i = 0; i < _bricks.Count; i++)
        {
            _bricks[i].UpdateBrickImage(_sprites[i]);
        }
        _QTEbuttons = _startParam.QTEButtons;


    }

    private void Update()
    {
        if (_isGameStart)
        {
            if (_bricks.Count > 0)
            {
                if (_currentBrick == null) UpdateCurrentButton();
            }
            else
            {
                GetComponent<AudioSource>().Stop();
                _finalText.SetActive(true);
                GameObject.Find("Time").GetComponent<Text>().text = $"your\ntime: {_timer.StopTimer()}";
            }
        }
    }


    private void UpdateCurrentButton()
    {
        _currentBrick = _bricks[Random.Range(0, _bricks.Count)];

        _qTEButton = NextQTEButton();
        _currentBrick.StartQTE(_qTEButton);

        _currentBrick.OnPress += NextBrick;
    }

    private QTEButton NextQTEButton()
    {
        if (_qTEButton == null)
            return _QTEbuttons[Random.Range(0, _QTEbuttons.Count())];
        var buttons = _QTEbuttons.Where(x => x.keyCode != _qTEButton.keyCode).ToList();
        return buttons[Random.Range(0, buttons.Count())];
    }

    private void NextBrick()
    {
        _bricks.Remove(_currentBrick);
        _brickWarehouse.Add(_currentBrick);
        _currentBrick.OnPress -= NextBrick;
        _currentBrick = null;
        FinalImage();

    }


    public void StopGame()
    {
        SceneManager.LoadScene(2);
        GameResult.Point = _bricks.Count;
    }

    private void FinalImage()
    {
        var myColor = Color.white;
        myColor.a = 1f / _bricks.Count;
        _finalImage.color = myColor;
    }

    private void ResetBrick()
    {
        if (_brickWarehouse.Count == 0)
        {
            TimeFine();
            return;
        }
        var index = Random.Range(0, _brickWarehouse.Count);
        var rBrick = _brickWarehouse[index];

        _brickWarehouse.RemoveAt(index);
        _bricks.Add(rBrick);
        rBrick.Activate();
    }

    private void TimeFine()
    {
        _timer.Fine(_timeFine);
    }
    public void GamePenalty()
    {
        if(Random.Range(0,2) == 0)
        {
            //time
            TimeFine();
        }
        else
        {
            //new brick
            ResetBrick();
        }
    }
}
