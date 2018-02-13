using UnityEngine;
using System.Collections;

public class loadScene61 : MonoBehaviour {

	private GameObject player;
	private PlatformerCharacter2D character;
	
	void Start(){
		
		player = GameObject.Find ("Player 1");
		
		character = player.GetComponent<PlatformerCharacter2D> ();
		
	}

	void Update()
	{
		if(Input.GetKeyUp("w") && character.isAlive)
		{
			Application.LoadLevel("scene61");
		}
	}
}