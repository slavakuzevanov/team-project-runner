using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Settings : MonoBehaviour {
	
	public Slider Music;
	//public AudioSource myMusic; 
	// Use this for initialization
	void Start () {
		Music.value = Global.musiclevel;
		//myMusic.volume = Global.musiclevel;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetMusic (float value)
	{
		Global.musiclevel = Music.value;
	}
	public void SetSound (float value)
	{
		Global.soundlevel = value;
	}
}
