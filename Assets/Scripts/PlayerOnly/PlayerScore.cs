using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

    public int score = 0;
    public GameObject scoreTextObject;
    Color scoreReachedColor = new Color(255, 0, 255, 255);

    public void Score (int amount)
    {
        scoreTextObject = GameObject.Find("TextMeshPro Score");
        score = score + amount;
        var scoreText = scoreTextObject.GetComponent<TextMeshProUGUI>();
        scoreText.text = "Score: " + score.ToString();
        if (score >= 100)

            scoreText.color = scoreReachedColor;
    }
	
}
