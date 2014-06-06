using UnityEngine;


public class WeaponScript : MonoBehaviour 
{
	///<summary>
	/// Rocket's prefab for firing.
	/// </summary>
	public Transform firePrefab;

	///<summary>
	/// Cooldown period between two shots
	/// </summary>
	public float firingRate = 0.25f;

	public float fireCooldown;



	void Start()
	{
		fireCooldown = 0f;
	}

	void Update()
	{

		if (fireCooldown > 0) 
		{
			fireCooldown -= Time.deltaTime;
		}

		// 5 - Shooting
		bool shoot = Input.GetButtonDown("Fire1");
		shoot |= Input.GetButtonDown("Fire2");
		// Careful: For Mac users, ctrl + arrow is a bad idea
		
		if (shoot)
		{
			WeaponScript weapon = GetComponent<WeaponScript>();
			if (weapon != null)
			{
				// false because the player is not an enemy
				weapon.attack(false);
			}
		}





	}

	public void attack(bool isEnemy)
	{

		if (CanAttack ()) 
		{
			fireCooldown = firingRate;

			//create a new rocket.
			var fireTransform = Instantiate (firePrefab) as Transform;

			//assign a postion
			fireTransform.position = transform.position;

			ShootingControl fire = fireTransform.gameObject.GetComponent<ShootingControl>();

			if(fire != null)
			{
				fire.isEnemyShot = isEnemy;
			}

			// Make the weapon shot always towards it
			//MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();

		}

	}



	public bool CanAttack()
	{
		return (fireCooldown <= 0f);
	}



}
