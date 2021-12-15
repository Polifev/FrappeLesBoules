using UnityEngine;

public class Target : MonoBehaviour
{
	[SerializeField]
	private Transform _minPosition;

	[SerializeField]
	private Transform _maxPosition;

	void OnCollisionEnter(Collision collision) {
		//Destroy ball
		Destroy(collision.gameObject);
		//10 points when touch a target
		GameManager.Instance.AddPoint(10);

		//Random target position within a range
		Vector3 newPosition = new Vector3(
			Random.Range(_minPosition.position.x, _maxPosition.position.x),
			Random.Range(_minPosition.position.y, _maxPosition.position.y),
			Random.Range(_minPosition.position.z, _maxPosition.position.z)
		);
		//Move target
		transform.position = newPosition;
	}
}
