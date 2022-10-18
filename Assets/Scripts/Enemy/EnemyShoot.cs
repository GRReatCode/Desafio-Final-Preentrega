using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
	[SerializeField]
	protected EnemyData enemyData;

	[SerializeField] AudioSource shootAudio;
	//public Transform Pivot;
	public Transform Player;
	public Transform SpawnBullet;
	public GameObject Enemy;
	//public GameObject Explode;
	public Rigidbody Shell;
	//public float ShootLoop;
	//public float shootDistance;	
	//public float SpeedRotate;
	//public float speed = 100;

	RaycastHit objectHit;
	float ShootTime = 0.5f;
	void Start()
	{
		Player = GameObject.Find("TankE(Clone)").transform;
	}

	void Update()

	{
		{
			if (Vector3.Distance(transform.position, Player.transform.position) < enemyData.shootDistance)
			{
				Vector3 lTargetDir = Player.position - transform.position;
				lTargetDir.y = 0.0f;
				transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(lTargetDir), Time.time * enemyData.SpeedRotate);
				ShootTime -= Time.deltaTime;
				if (ShootTime <= 0)
				{
					Vector3 fwd = SpawnBullet.transform.TransformDirection(Vector3.forward);
					Debug.DrawRay(SpawnBullet.transform.position, fwd * enemyData.speed, Color.red);
					if (Physics.Raycast(SpawnBullet.transform.position, fwd, out objectHit, 50))
					{

						if (objectHit.collider.tag == "Player" || objectHit.collider.tag == "Shield")
						{
							shootAudio.Play();
							Rigidbody rbShell = Instantiate(Shell, SpawnBullet.position, SpawnBullet.rotation);
							rbShell.velocity = enemyData.speed * SpawnBullet.forward;
							ShootTime = enemyData.ShootLoop;
						}
					}

				}
			}
			//transform.position = Pivot.transform.position;
		}
	}
}
