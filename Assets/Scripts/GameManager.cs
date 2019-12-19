using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {
	public GameObject[] objects;
	public GameObject newcanvas;
	public GameObject charactercanvas;
	public GameObject Pause;
	public GameObject Settings;
	public GameObject Hunter;
	public GameObject Swat;
	private bool paused;
	public bool Paused
	{
		get { return paused; }
	}
	private static GameManager instance;
	public static GameManager Instance
	{
		get 
		{
			if (instance == null) 
			{
				instance = GameObject.FindObjectOfType<GameManager> ();
			}
			return GameManager.instance; 
		}
	}
	// Use this for initialization
	void Start () {
		if (Global.hunterselected) {
			Hunter.SetActive (true);
			Swat.SetActive (false);
		} 
		else 
		{
			Hunter.SetActive (false);
			Swat.SetActive (true);
		}
		charactercanvas.SetActive (false);
		newcanvas.SetActive (false);
		Settings.SetActive (false);
		for (int i = 0; i < 2; i++)
		{
			objects [i].SetActive (true);
		}
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void PauseGame ()
	{
		paused = !paused;
		Hunter.SetActive (false);
		Swat.SetActive (false);
		for (int i = 0; i < 2; i++)
		{
			objects [i].SetActive (false);
		}
		newcanvas.SetActive (true);
		Pause.SetActive (false);
	}
	public void NotPauseGame ()
	{
		paused = !paused;
		for (int i = 0; i < 2; i++)
		{
			objects [i].SetActive (true);
		}
		if (Global.hunterselected) {
			Hunter.SetActive (true);
			Swat.SetActive (false);
		} else 
		{
			Hunter.SetActive (false);
			Swat.SetActive (true);
		}
		newcanvas.SetActive (false);
		Pause.SetActive (true);
	}
	public void ToMainMenu()
	{
		SceneManager.LoadScene("Menu");
	}
	public void ToSettings()
	{
		newcanvas.SetActive (false);
		Settings.SetActive (true);
		charactercanvas.SetActive (false);
	}
	public void ToPauseMenu ()
	{
		charactercanvas.SetActive (false);
		Settings.SetActive (false);
		if (paused) 
			newcanvas.SetActive (true);
		else
			newcanvas.SetActive (false);
	}
	public void ToDeathMenu ()
	{
		newcanvas.SetActive (true);
		Settings.SetActive (false);
		charactercanvas.SetActive (false);
	}
	public void SelectSwat ()
	{
		Global.hunterselected = false;
		Global.swatselected = true;
	}
	public void SelectHunter ()
	{
		Global.hunterselected = true;
		Global.swatselected = false;
	}
	public void ToCharacterChoice()
	{
		newcanvas.SetActive (false);
		Settings.SetActive (false);
		charactercanvas.SetActive (true);
	}
	public void SelectControlclassic()
	{
		Global.control = 1;
	}
	public void SelectControlalt()
	{
		Global.control = 2;
	}
	public void SelectControlbuttons()
	{
		Global.control = 3;
	}

}

