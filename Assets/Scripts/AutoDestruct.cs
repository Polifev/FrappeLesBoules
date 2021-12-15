using UnityEngine;

public class AutoDestruct : MonoBehaviour
{
	[SerializeField]
	private float _lifetime;

	private float _currentLife;

	void OnEnable(){
		_currentLife = _lifetime;
	}

    // Update is called once per frame
    void Update()
    {
        _currentLife -= Time.deltaTime;
		if(_currentLife < 0){
			gameObject.SetActive(false);
		}
    }
}
