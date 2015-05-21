using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RsScoreManager : MonoBehaviour {

    public Text scoreText;

    float score = 0f;

    void Awake()
    {
        score = 0f;
        if (scoreText != null)
            scoreText.text = score.ToString();
    }

    public void Reset()
    {
        score = 0f;
        if (scoreText != null)
            scoreText.text = score.ToString();
    }

    public float GetScore()
    {
        return score;
    }

    public void AddScore(float value)
    {
        score += value;
        if (scoreText != null)
            scoreText.text = score.ToString();
    }

}
