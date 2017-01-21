using UnityEngine;
using System.Collections;

public class MusicTrack : MonoBehaviour {

	private MusicClip[] clips; 

	private int currentClip = 0;
	private bool started = false;

	// Use this for initialization
	void Start () {
		started = false;
		clips = GetComponentsInChildren<MusicClip>();
	}

	public MusicClip GetNextClip() {
		if (!started) {	
			currentClip = 0;
			started = true;
		} else if (clips.Length > 1) {
			currentClip = 1 + (currentClip  + 1) % (clips.Length - 1); // loop through all clips but the first
		}

		Debug.Log("queued clip at index " + currentClip);
		return clips[currentClip];
	}
}


