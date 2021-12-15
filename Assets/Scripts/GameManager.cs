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
	private Text _text;
	private int _score = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
		_currentState = GameState.Menu;
		//_text.text = $"Score : {_score}";
    }

	public void StartGame()
    {
		_score = 0;
		_mainMenu.SetActive(false);
		//Start cannon
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
			//_text.text = $"Score : {_score}";
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