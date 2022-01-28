using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CanvasUpdate : MonoBehaviour
{    
    public static event Action<int> TextUpdate = delegate { };
        
    void OnEnable()
    {
        GetComponent<ScoreSystem>().ScoreUpdater += UpdatePoints;
    }

    void OnDisable()
    {
        GetComponent<ScoreSystem>().ScoreUpdater -= UpdatePoints;
    }

    private void UpdatePoints(int points)
    {
        TextUpdate(points);
    }
}