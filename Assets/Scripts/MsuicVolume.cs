using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MsuicVolume : MonoBehaviour {
	public Slider Music;
	public AudioSource myMusic; 
	void Start (){
		Music.value = Global.musiclevel;
	}
	// Update is called once per frame
	void Update () {
		myMusic.volume =  Music.value;
		Global.musiclevel = myMusic.volume;
	}
}
