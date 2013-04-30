using UnityEngine;
using System.Collections;

/// <summary>
/// Gives an object a Life span after which it is deleted.
/// </summary>
public class LifeSpan : MonoBehaviour {
	
	/// <summary>
	/// The lifespan of the object.
	/// </summary>
	public float Lifespan = 10f;
	private float activeTime = 0f;
	
	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, Lifespan);
	}
}
