using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public string Title;
	public string start;
	public string quit;

	void OnGUI()
	{
		GUI.Label(new Rect(Screen.width/2-40.0f,Screen.height/3,80.0f,40.0f),Title);

		if(GUI.Button (new Rect(Screen.width/4-40.0f,Screen.height*0.75f,80.0f,30.0f),start))
		{
			Application.LoadLevel("TestLevel");
		}

		if(GUI.Button (new Rect(Screen.width*0.75f-40.0f,Screen.height*0.75f,80.0f,30.0f),quit))
		{
			Application.Quit ();
		}
	}
}
