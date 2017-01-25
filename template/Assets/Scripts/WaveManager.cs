using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WaveManager : MonoBehaviour {

	public int NumberOfWave = 0;
	public GameObject enemyPrefab;
	public Transform pointSpaw;
	private float countdown = 2;
	public float timebetweenwave = 5f;
	public Text wavenexttime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (countdown <= 0f) {
			countdown = timebetweenwave;
			StartCoroutine(Spaw());
		}
		countdown -= Time.deltaTime;
		wavenexttime.text = Mathf.Round(countdown).ToString();
	}
	IEnumerator Spaw()
	{
		for (int i =0; i < NumberOfWave; i++) {
			Instantiate( enemyPrefab, pointSpaw.position, pointSpaw.rotation);
			yield return new WaitForSeconds(0.5f);
		}
		NumberOfWave++;
	}
}
