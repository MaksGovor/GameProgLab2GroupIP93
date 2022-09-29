using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{

    [SerializeField] int keysCount = 3;
    [SerializeField] Text scoreView;
    private SceneSwitcher sceneSwitcher;
    private int score;

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
