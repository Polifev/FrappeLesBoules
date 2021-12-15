using UnityEngine;

public class Paddle : MonoBehaviour
{
	[SerializeField]
	private float _amplifiedForce = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag == "Bomb"){
			GameManager.Instance.Lose();
		} else {
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
