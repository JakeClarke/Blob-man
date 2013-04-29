using UnityEngine;
using System.Collections;

public class EnemyOnHit : MonoBehaviour {
	public Transform prefab;
	
	public void onHit() {
		Instantiate(prefab, this.gameObject.transform.position, new Quaternion());
		Donut.score += 50;
		Destroy(gameObject);
	}
}
