using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour
{
	public static BallPool Instance {
		get;
		private set;
	}

	[SerializeField]
	private GameObject _ballPrefab;

	[SerializeField]
	private GameObject _bombPrefab;

	[SerializeField]
	private int _poolSize = 10;
	


	private List<GameObject> _bombPool;
	private List<GameObject> _ballPool;

    void Start()
    {
		Instance = this;

		_ballPool = new List<GameObject>();
		_bombPool = new List<GameObject>();
        
		for(int i = 0; i < _poolSize; i++){
			var ball = Instantiate(_ballPrefab);
			ball.SetActive(false);
			_ballPool.Add(ball);
			var bomb = Instantiate(_bombPrefab);
			bomb.SetActive(false);
			_bombPool.Add(bomb);
		}
    }

	public GameObject GetBall(Transform parent)
	{
		foreach(GameObject ball in _ballPool){
			if(!ball.activeSelf){
				ball.transform.parent = parent;
				ball.transform.localPosition = new Vector3();
				ball.GetComponent<Rigidbody>().velocity = new Vector3();
				ball.SetActive(true);
				return ball;
			}
		}

		throw new Exception("No ball left in pool");
	}

	public GameObject GetBomb(Transform parent){
		foreach(GameObject bomb in _bombPool){
			if(!bomb.activeSelf){
				bomb.transform.parent = parent;
				bomb.transform.localPosition = new Vector3();
				bomb.GetComponent<Rigidbody>().velocity = new Vector3();
				bomb.SetActive(true);
				return bomb;
			}
		}

		throw new Exception("No bomb left in pool");
	}
}
