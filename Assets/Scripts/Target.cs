using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	[SerializeField]
	private Transform _minPosition;

	[SerializeField]
	private Transform _maxPosition;

	void OnCollisionEnter(Collision collision) {
		Destroy(collision.gameObject);
		GameManager.Instance.AddPoint(10);

		Vector3 newPosition = new Vector3(
			Random.Range(_minPosition.position.x, _maxPosition.position.x),
			Random.Range(_minPosition.position.y, _maxPosition.position.y),
			Random.Range(_minPosition.position.z, _maxPosition.position.z)
		);
		
		this.transform.position = newPosition;
	}
}
