using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {
    private float score = 0.0f;
    public Text scoreText;
    private int difficultyLevel = 1;
    private int maxDifficulty = 100000;
    private int scoreToNextLevel = 10;
    private bool isDead = false;
    public DeathMenu deathMenu;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		if (!GameManager.Instance.Paused)
		{
			if (isDead) {
				return;
			}
			if (score >= scoreToNextLevel)
				LevelUp ();
			score += Time.deltaTime * difficultyLevel;
			scoreText.text = ((int)score).ToString ();
		}
	}
    void LevelUp()
    {
        if (difficultyLevel == maxDifficulty)
            return;
        
        scoreToNextLevel *= 2;
        difficultyLevel++;
        GetComponent<PlayerModer>().SetSpeed (difficultyLevel);
        Debug.Log(difficultyLevel);
    }
    public void OnDeath()
    {
        isDead = true;
        if( PlayerPrefs.GetFloat("Highscore") < score )
            PlayerPrefs.SetFloat("Highscore", score);
        
        deathMenu.ToggleEndMenu(score);
    }
}
