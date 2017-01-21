using UnityEngine;
using System.Collections;

public class MusicTrack : MonoBehaviour {

	public MusicClip[] clips; 

	private int currentClip = 0;
	private bool started = false;

	// Use this for initialization
	void Start () {
		started = false;
		clips = GetComponentsInChildren<MusicClip>();
	}

	public MusicClip getNextClip() {
		if (!started) {			// All clip playback algorithms start from index 0 initially
			currentClip = 0;
			started = true;
		} else if (clips.Length > 1) {
			currentClip = (currentClip  + 1) % clips.Length;
		}

		return clips[currentClip];
	}
}


