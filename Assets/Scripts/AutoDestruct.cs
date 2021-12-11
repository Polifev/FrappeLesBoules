using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruct : MonoBehaviour
{
	[SerializeField]
	private float _lifetime;

    // Update is called once per frame
    void Update()
    {
        _lifetime -= Time.deltaTime;
		if(_lifetime < 0){
			Destroy(gameObject);
		}
    }
}
