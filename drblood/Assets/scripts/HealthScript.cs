using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour 
{

	public int hp = 2;
	public bool isEnemy = true;
	public bool isShot = false;
	Animator anim;

	public PlatformerCharacter2D character;

	void Start(){
		anim = GetComponent<Animator> ();
	}

	void Update(){
		if(isShot)
			StartCoroutine(WaitXTime());
	}

	private IEnumerator WaitXTime() {
		anim.SetBool("isShot", isShot);
		yield return new WaitForSeconds (1.0f);
		character.isAlive = false;
		yield return new WaitForSeconds (3.0f);
		Application.LoadLevel ("scene1");
	}

	public void Damage(int damageCount)
	{
		hp -= damageCount;

		if (hp <= 0) {
			//dead
			Destroy(gameObject);
		}
	}


	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		//is it a shot
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
		if(shot != null)
		{
			// avoid friendly fire
			if (shot.isEnemyShot != isEnemy)
			{
				Damage(shot.damage);
				//destroy shot
				Destroy(shot.gameObject);
				isShot = true;
			}
		}
	}
}
