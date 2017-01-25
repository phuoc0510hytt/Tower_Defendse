using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	public float speed;
	private int index = 0;
	private Transform target;
	void Start()
	{
		target = PointWay.waypoints [0];
	}
	void Update () {
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime);
		if(Vector3.Distance(transform.position, target.position) <= 0.2f) 
		{
			getIndex();
		}
	}
	void getIndex()
	{
		index ++;
		if (index < PointWay.waypoints.Length)
			target = PointWay.waypoints [index];
		else
			Destroy (gameObject);
	}
}
