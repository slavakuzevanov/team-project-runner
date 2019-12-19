using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    public Text highscoreText;
    public Text coinsText;
	public GameObject mainMenuHolder;
	public GameObject optionsMenuHolder;
	public GameObject R;
	public Slider[] volumeSliders;

	// Use this for initialization
	void Start () {
		highscoreText.text = "Best: " + ((int)PlayerPrefs.GetFloat ("Highscore"));
        coinsText.text = "Coins: " + ((int)PlayerPrefs.GetFloat("Coins"));
    }

    public void ToGame ()
    {
        SceneManager.LoadScene("Scene");
    }
	public void ToSettings ()
	{
		//SceneManager.LoadScene("Settings");
		mainMenuHolder.SetActive (false);
		optionsMenuHolder.SetActive (true);
	}
	public void ToMainMenu ()
	{
		mainMenuHolder.SetActive (true);
		optionsMenuHolder.SetActive (false);
	}
	public void SetMusic(float value)
	{

	}
	public void SetVolume(float value)
	{

	}
	public void Quit()
	{
		Application.Quit ();
	}
}
