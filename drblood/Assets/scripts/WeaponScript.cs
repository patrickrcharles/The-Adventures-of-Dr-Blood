using UnityEngine;

/// <summary>
/// Launch projectile
/// </summary>
public class WeaponScript : MonoBehaviour
{

	//--------------------------------
	// 1 - Designer variables
	//--------------------------------
	
	/// <summary>
	/// Projectile prefab for shooting
	/// </summary>
	public Transform shotPrefab;
	
	/// <summary>
	/// Cooldown in seconds between two shots
	/// </summary>
	public float shootingRate = 0.25f;

	public PlatformerCharacter2D character;

	//--------------------------------
	// 2 - Cooldown
	//--------------------------------
	
	private float shootCooldown;
	
	void Start()
	{
		character = GetComponentInParent<PlatformerCharacter2D> ();
		shootCooldown = 0f;
	}
	
	void Update()
	{
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}


	}
	
	//--------------------------------
	// 3 - Shooting from another script
	//--------------------------------
	
	/// <summary>
	/// Create a new projectile if possible
	/// </summary>
	public void Attack(bool isEnemy)
	{
		if (CanAttack)
		{
			shootCooldown = shootingRate;

			Transform clone  = (Transform) Instantiate (shotPrefab);

			clone.position = transform.position;

			Destroy (clone.gameObject, 2.0f);
			
			// The is enemy property
			ShotScript shot = clone.gameObject.GetComponent<ShotScript>();

			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
			}
			
			// Make the weapon shot always towards it
			moveScript move = shot.gameObject.GetComponent<moveScript>();

			if (move != null && character.facingRight == true)
			{
				move.direction = this.transform.right; // towards in 2D space is the right of the sprite
			}
			if (move != null && character.facingRight == false){

				move.direction = this.transform.right * -1;
			}

		}
	}
	
	/// <summary>
	/// Is the weapon ready to create a new projectile?
	/// </summary>
	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
}