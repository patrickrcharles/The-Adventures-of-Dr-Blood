using UnityEngine;
using System.Collections;

public class loadScene41right : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			Application.LoadLevel("scene41right");
		}
	}
}