using UnityEngine;

public class Paddle : MonoBehaviour
{
	[SerializeField]
	private float _amplifiedForce = 0.0f;

	[SerializeField]
	private AudioClip _bomb;
	[SerializeField]
	private AudioClip _ball;

	[SerializeField]
	private GameObject _explosion;

	private AudioSource _audio;

    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag == "Bomb"){
			_audio.PlayOneShot(_bomb);
			OVRInput.SetControllerVibration(.5f, .5f, OVRInput.Controller.All);
			Instantiate(_explosion, transform);
			GameManager.Instance.Lose();
		} else {
			_audio.PlayOneShot(_ball);
			//Rebond de la raquette
			Vector3 relativePosition = collision.transform.position - transform.position;
			Vector3 direction = - Vector3.Project(relativePosition, transform.forward).normalized;

			collision.collider.attachedRigidbody.AddForce(
				direction * _amplifiedForce,
				ForceMode.Impulse
			);
		}
	}
}
