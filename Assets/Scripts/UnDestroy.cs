using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnDestroy : MonoBehaviour {
	public AudioSource myMusic; 
	void Awake ()
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("Music");
		if (objs.Length > 1)
			Destroy (this.gameObject);
		DontDestroyOnLoad (this.gameObject);
	}
	void Update () {
		myMusic.volume = Global.musiclevel;
	}
}
