using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private int ScoreValue=0;
    Text scoreText;
    static ScoreCounter scoreCounter;
    public static ScoreCounter Instance => scoreCounter;

    private void Awake()
    {
        if (scoreCounter == null)
            scoreCounter = this;
        else
            Destroy(this);
    }
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    
    public void score()
    {
        ScoreValue += 10;
        scoreText.text = "Score: " + ScoreValue;

    }
}
