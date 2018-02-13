using UnityEngine;
using System.Collections;

public class cheat : MonoBehaviour {

	void Update()
	{
		if(Input.GetKeyUp("f12"))
		{
			Application.LoadLevel("scene1_past1");
		}
	}
}
