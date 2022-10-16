using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
	[SerializeField]
	protected EnemyData enemyData;

	[SerializeField] AudioSource shootAudio;
	public Transform Pivot;
	public Transform Player;
	public Transform SpawnBullet;
	public GameObject Enemy;
	public GameObject Explode;
	public Rigidbody Shell;
	RaycastHit objectHit;
	float ShootTime = 0.5f;
	void Start()
	{
		Player = GameObject.FindWithTag("Player").transform;
	}

	void Update()

	{
		ShootPlayer();
	}

    private void ShootPlayer()
    {
		{
			if (Vector3.Distance(transform.position, Player.transform.position) < enemyData.turretshootDistance)
			{
				Vector3 lTargetDir = Player.position - transform.position;
				lTargetDir.y = 0.0f;
				transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lTargetDir), Time.time * enemyData.turretSpeedRotate);
				ShootTime -= Time.deltaTime;
				if (ShootTime <= 0)
				{
					Vector3 fwd = SpawnBullet.transform.TransformDirection(Vector3.forward);
					Debug.DrawRay(SpawnBullet.transform.position, fwd * enemyData.turretspeed, Color.red);
					if (Physics.Raycast(SpawnBullet.transform.position, fwd, out objectHit, 50))
					{

						if (objectHit.collider.tag == "Player" || objectHit.collider.tag == "Shield")
						{
							shootAudio.Play();
							Rigidbody rbShell = Instantiate(Shell, SpawnBullet.position, SpawnBullet.rotation);
							rbShell.velocity = enemyData.turretspeed * SpawnBullet.forward;
							ShootTime = enemyData.turretShootLoop;
						}
					}

				}
			}
			transform.position = Pivot.transform.position;
		}
	}

	private void OnCollisionEnter(Collision col)
	{
		
		if (col.gameObject.CompareTag("PlayerBullet"))
		{
			Vector3 lTargetDir = Player.position;
			lTargetDir.y = 0.0f;
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lTargetDir), Time.time * enemyData.turretSpeedRotate);
			ShootTime -= Time.deltaTime;
			Rigidbody rbShell = Instantiate(Shell, SpawnBullet.position, SpawnBullet.rotation);
			rbShell.velocity = enemyData.turretspeed * SpawnBullet.forward;
			ShootTime = enemyData.turretShootLoop;
		}
	}
}
