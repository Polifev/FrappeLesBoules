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
	private int _score = 0;
	private bool _finished = false;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
		_text.text = $"Score : {_score}";
    }

	public void AddPoint(int points){
		if(! _finished){
			_score += points;
			_text.text = $"Score : {_score}";
		}
		
	}

	public void Lose(){
		_finished = true;
		_text.text = $"PERDU ! Score final: {_score}";
	}
}
