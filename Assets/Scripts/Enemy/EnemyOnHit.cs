using UnityEngine;
using System.Collections;

public class EnemyOnHit : MonoBehaviour {
	public Transform prefab;
	public Transform donutPrefab;
	
	public Vector3 donutPosOffset = new Vector3(0f, 2f, 0f);
	
	public void onHit() {
		Instantiate(prefab, this.gameObject.transform.position, new Quaternion());
		Instantiate(donutPrefab, this.gameObject.transform.position + donutPosOffset, donutPrefab.rotation);
		Destroy(gameObject);
	}
}
