using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public int score;

    public int level;

    public float currentUpCooldown;
    public float upCooldown;
    public float currentScoreCooldown;
    public float scoreCooldown;

    public bool onGame;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
        currentUpCooldown = upCooldown;
        currentScoreCooldown = scoreCooldown;
        onGame = true;

        level = 1;
	}
	
	// Update is called once per frame
	void Update () {
        currentUpCooldown -= Time.deltaTime;
        currentScoreCooldown -= Time.deltaTime;
        if (currentScoreCooldown <= 0 && onGame == true)
        {
            score += level;
            currentScoreCooldown = scoreCooldown;
        }

        scoreText.text = score.ToString();

        if (currentUpCooldown <= 0)
        {
            level += 1;
            currentUpCooldown = upCooldown;
        }
	}
}
