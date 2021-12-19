using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

	public static GameManager Instance {
		get;
		private set;
	}

	public GameState CurrentState
    {
		get => _currentState;
    }

	private GameState _currentState;

	[SerializeField]
	private GameObject _mainMenu;
	[SerializeField]
	private GameObject _gameOver;
	[SerializeField]
	private BallCannon _cannon;

	[SerializeField]
	private Text _text;
	private int _score = 0;
	private float _timer = 0.0f;
	private float _timerLastStep = 0.0f;
	[SerializeField]
	private float _timerStep = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
		_currentState = GameState.Menu;
		//_text.text = $"Score : {_score}";
    }

	void Update()
	{
		if(_currentState == GameState.InGame){
			_timer += Time.deltaTime;
			if(_timer > _timerLastStep + _timerStep){
				_timerLastStep += _timerStep;
				_cannon.IncreaseSpeed();
			}
		}
	}

	public void StartGame()
    {
		_score = 0;
		_timer = 0;
		_timerLastStep = 0;
		_mainMenu.SetActive(false);
		_currentState = GameState.InGame;
    }

	public void GoToMenu()
    {
		_gameOver.SetActive(false);
		_mainMenu.SetActive(true);
		_currentState = GameState.Menu;
    }

	public void AddPoint(int points){
		if(_currentState == GameState.InGame){
			_score += points;
		}
		
	}

	public void Lose(){
		_currentState = GameState.GameOver;
		_gameOver.SetActive(true);
		_text.text = $"PERDU ! Score final: {_score}";
	}
}

public enum GameState
{
	Menu,
	InGame,
	GameOver
}