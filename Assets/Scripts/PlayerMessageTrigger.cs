using UnityEngine;
using System.Collections;

/// <summary>
/// Player message trigger.
/// Can turn off the rendering of the object it is attached too.
/// </summary>
public class PlayerMessageTrigger : MonoBehaviour {
	
	/// <summary>
	/// The message to send to the player.
	/// </summary>
	public string message = "";
	
	/// <summary>
	/// Is the game object hidden.
	/// </summary>
	public bool isHidden = true;
	
	void Awake() {
		if(isHidden)
			this.renderer.enabled = false;	
	}
		
	void OnTriggerEnter(Collider collider) {
		if(collider.tag == "Player") {
			collider.SendMessage(message);
		}
	}
}
