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
    }

    void OnDisable()
    {
        CanvasUpdate.TextUpdate -= UpdateText;
    }

    private void Awake()
    {        
        ScoreText = GetComponent<Text>();
    }

    private void UpdateText(int points) 
    {
        ScoreText.text = "Score: " + String.Format("{0:00000000}", points);
    }
}