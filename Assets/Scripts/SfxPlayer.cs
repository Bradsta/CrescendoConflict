using UnityEngine;
using System.Collections.Generic;

/*
HOW TO USE:
1. Drag the SfxPlayer prefab into the scene
2. Adjust the soundEffects list size
3. Drag the sound effects into the list

To play a sound effect, call playSoundEffect() with the name of the AudioClip,
optionally specifying a volume to play it at.
*/

public class SfxPlayer : MonoBehaviour {
    public float Volume = 1.0f;
    public AudioClip[] soundEffects;

	private AudioSource audioSource;
	private Dictionary<string, AudioClip> soundEffectsDict;

	// Use this for initialization
	void Start () {
		GameObject child = new GameObject("AudioSource");
		child.transform.parent = gameObject.transform;
		audioSource = child.AddComponent<AudioSource>();
        audioSource.volume = Volume;

		soundEffectsDict = new Dictionary<string, AudioClip>();

		// create dictionary from soundEffects
		foreach (var clip in soundEffects) {
			Debug.Log("adding " + clip.name + " to soundEffectsDict");
			soundEffectsDict[clip.name] = clip;
		}
	}

	public void PlaySoundEffect(string name, float volume = 1.0f) {
		audioSource.PlayOneShot(soundEffectsDict[name], volume);
	}
}
