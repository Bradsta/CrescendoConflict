using UnityEngine;
using System.Collections.Generic;

public class SfxPlayer : MonoBehaviour {
	public AudioClip[] soundEffects;

	private AudioSource audioSource;
	public Dictionary<string, AudioClip> soundEffectsDict;

	// Use this for initialization
	void Start () {
		GameObject child = new GameObject("AudioSource");
		child.transform.parent = gameObject.transform;
		audioSource = child.AddComponent<AudioSource>();

		// create dictionary from soundEffects
		foreach (AudioClip clip in soundEffects) {
			Debug.Log("adding " + clip.name + " to soundEffectsDict");
			soundEffectsDict[clip.name] = clip;
		}
	}

	void playSoundEffect(string name, float volume = 1.0f) {
		audioSource.PlayOneShot(soundEffectsDict[name], volume);
	}
}
