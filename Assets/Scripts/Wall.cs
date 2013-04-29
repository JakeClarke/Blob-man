using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {
	
	public Transform prefab;
	
	public void onHit() {
		Instantiate(prefab, this.gameObject.transform.position, new Quaternion());
		Destroy(gameObject);
	}
}
