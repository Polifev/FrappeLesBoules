using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCannon : MonoBehaviour
{
	[SerializeField]
	private float _bombProbability = 0.1f;

	[SerializeField]
	private Transform _ballOrigin;
	[SerializeField]
	private float _initialForce = 10.0f;
	[SerializeField]
	private float _shootInterval = 2.0f;
	private float _currentTimer = 0.0f;

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
		float p = Random.value;

		GameObject projectile;
		if(p < _bombProbability){
			projectile = BallPool.Instance.GetBomb(_ballOrigin);
		} else {
			projectile = BallPool.Instance.GetBall(_ballOrigin);
		}
		
		projectile.GetComponent<Rigidbody>().AddForce(_ballOrigin.up * _initialForce, ForceMode.Impulse);
		projectile.transform.parent = null;
	}
}
