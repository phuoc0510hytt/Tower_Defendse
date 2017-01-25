using UnityEngine;
using System.Collections;

public class TurretController : MonoBehaviour {

	[Header("Attributes")]
	public float range = 15f;
	public float firerate = 1f;
	private float firecountdown = 2f;
	[Header("Unity Setup")]
	public Transform target;
	private string enemytag = "Enemy";
	public float turnSpeed = 10f;
	public Transform partToRotation;

	public GameObject bulletPrefab;
	public Transform firePoint;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
	}
	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemytag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies) {
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if(distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}
		if (nearestEnemy != null && shortestDistance <= range) {
			target = nearestEnemy.transform;
		} else {
			target = null;
		}
	}
	// Update is called once per frame
	void Update () {
		if (target == null)
			return;
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (dir);
		Vector3 rotation = Quaternion.Lerp(partToRotation.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotation.rotation = Quaternion.Euler (0f, rotation.y , 0f);

		if (firecountdown <= 0f) {
			Shoot();
			firecountdown = 1f / firerate;
		}
		firecountdown -= Time.deltaTime;
	}
	void Shoot()
	{
		GameObject BulletGO = (GameObject)Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = BulletGO.GetComponent<Bullet> ();
		if (bullet != null)
			bullet.seek (target);
	}
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (transform.position, range);
	}
}
