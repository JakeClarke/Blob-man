using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour {
	
	private GameObject _stateManager;

	// Use this for initialization
	void Start () {
		this._stateManager = GameObject.FindGameObjectWithTag("Score");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider col) {
		if(col.tag == "Player") {
			this._stateManager.SendMessage("LevelComplete");
		}
	}
}
