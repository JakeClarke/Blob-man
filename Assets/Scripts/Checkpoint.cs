using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	
	public Color activeCheckPointColor = Color.green;
	private Color _defaultColor;
	private GameObject _spawnManager;

	// Use this for initialization
	void Start () {
		_defaultColor = this.particleSystem.startColor;
		
		_spawnManager = GameObject.FindGameObjectWithTag("Score");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			_spawnManager.SendMessage ("SetActiveSpawn", this.gameObject);
		}	
	}
	
	public void SetActive(bool isActive) {
		if(isActive) {
			this.gameObject.particleSystem.startColor = activeCheckPointColor;
		}
		else {
			this.gameObject.particleSystem.startColor = _defaultColor;
		}
	}
}
