using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
		this.CurrentLevel = Application.loadedLevelName;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	/// <summary>
	/// Gets the current level.
	/// </summary>
	/// <value>
	/// The current level.
	/// </value>
	public string CurrentLevel {
		get;
		protected set;
	}
	
	/// <summary>
	/// Gets or sets the score.
	/// </summary>
	/// <value>
	/// The score.
	/// </value>
	public int Score {
		get;
		set;
	}
	
	public string GameOverReason {
		get;
		set;
	}
}
