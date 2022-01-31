using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CanvasInfo : MonoBehaviour
{    
    [SerializeField]
    private Text ScoreText;

    [SerializeField]
    private Text MultiplierText;

    void OnEnable()
    {        
        CanvasUpdate.TextUpdate += UpdateText;
        CanvasUpdate.MultiplierText += UpdateMultiplier;
    }

    void OnDisable()
    {
        CanvasUpdate.TextUpdate -= UpdateText;
        CanvasUpdate.MultiplierText -= UpdateMultiplier;
    }

    private void UpdateText(int score) 
    {
        ScoreText.text = "SCORE: " + String.Format("{0:00000000}", score);
    }

    private void UpdateMultiplier(float points)
    {        
        MultiplierText.text = "MULTIPLIER: x" + points;
    }
}