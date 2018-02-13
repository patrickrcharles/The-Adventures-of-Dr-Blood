using UnityEngine;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class GunShoot : MonoBehaviour {


	private PlatformerCharacter2D character;
	

	// Update is called once per frame
	void Update () {

		character = GetComponentInParent<PlatformerCharacter2D> ();

		bool shoot = Input.GetButtonDown ("Fire1");
		shoot = Input.GetButtonDown ("Fire1");
		
		if (shoot && character.equipped == 5 && character.grounded && character.speed == 0)
		{
			WeaponScript weapon = GetComponent<WeaponScript>();

			if (weapon != null)
			{
				if(character.isAlive)
				weapon.Attack(false);
			}
		}
	
	}
}
