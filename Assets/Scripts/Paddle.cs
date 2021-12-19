using UnityEngine;

public class Paddle : MonoBehaviour
{
	[SerializeField]
	private float _amplifiedForce = 0.0f;

	[SerializeField]
	private AudioClip _bomb;
	[SerializeField]
	private AudioClip _ball;

	private AudioSource _audio;

    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag == "Bomb"){
			_audio.PlayOneShot(_bomb);
			// TODO vibrer
			// TODO explosion
			GameManager.Instance.Lose();
		} else {
			_audio.PlayOneShot(_ball);
			//Rebond de la raquette
			Vector3 relativePosition = collision.transform.position - transform.position;
			Vector3 direction = - Vector3.Project(relativePosition, transform.forward).normalized;
			Debug.Log(direction);

			collision.collider.attachedRigidbody.AddForce(
				direction * _amplifiedForce,
				ForceMode.Impulse
			);
		}

		
	}
}
