using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{

    private int score;
    public int keysCount = 3;
    public Text scoreView;
    private SceneSwitcher sceneSwitcher;

    void Start()
    {
        sceneSwitcher = FindObjectOfType<SceneSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreView.text = $"Keys: {score}/{keysCount}";
    }

    public void IncScore()
    {
        score++;
        if (score >= keysCount)
        {
            sceneSwitcher.Switch();
        }
    }
}
