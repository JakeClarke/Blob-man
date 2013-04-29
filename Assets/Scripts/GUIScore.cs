using UnityEngine;
using System.Collections;

public class GUIScore : MonoBehaviour {

	void OnGUI () {
		GUI.Box(new Rect(20,20, 140,30), "Score: "+Donut.score);
	}
}