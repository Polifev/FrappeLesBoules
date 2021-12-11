using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance {
		get;
		private set;
	}

	[SerializeField]
	private Text _text;
	private int _score;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
		_text.text = $"Score : {_score}";
    }

	public void AddPoint(int points){
		_score += points;
		_text.text = $"Score : {_score}";
	}
}
