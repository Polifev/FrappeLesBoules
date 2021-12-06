using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCannon : MonoBehaviour
{
	[SerializeField]
	private GameObject _ballPrefab;
	[SerializeField]
	private Transform _ballOrigin;
	[SerializeField]
	private float _initialForce = 10.0f;
	[SerializeField]
	private float _shootInterval = 2.0f;
	private float _currentTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
		if(_ballPrefab == null){
			Debug.LogError("Ball prefab is null");
		}
		if(_ballPrefab.GetComponent<Rigidbody>() == null){
			Debug.LogError("Ball prefab has no rigidbody");
		}
    }

    // Update is called once per frame
    void Update()
    {
		if(_shootInterval <= 0)
			return;
		
        _currentTimer += Time.deltaTime;
		while(_currentTimer >= _shootInterval){
			Shoot();
			_currentTimer -= _shootInterval;
		}
    }

	void Shoot()
	{
		if(_ballPrefab == null)
			return;
		
		GameObject ball = Instantiate(_ballPrefab, _ballOrigin);
		ball.GetComponent<Rigidbody>().AddForce(_ballOrigin.up * _initialForce, ForceMode.Impulse);
		ball.transform.parent = null;
	}
}
