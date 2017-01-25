using System.Collections;
using UnityEngine;

public class Node : MonoBehaviour {

	public Color hoverColor;
	public GameObject turret;
	private Renderer rend;
	private Color startColor;
	public Vector3 positionOffset;

	void Start()
	{
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;
	}

	void OnMouseDown()
	{
		if (turret != null) {
			Debug.Log ("DON'T HAVE ANY TURRET!");
			return;
		}
		//Build Turret
		GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
		turret = (GameObject)Instantiate (turretToBuild, transform.position+ positionOffset, transform.rotation);
			
	}

	void OnMouseEnter()
	{
		rend.material.color = hoverColor;
	}

	void OnMouseExit()
	{
		rend.material.color = startColor;
	}
}
