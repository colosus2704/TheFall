using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CanvasUpdate : MonoBehaviour
{    
    public static event Action<int> TextUpdate = delegate { };
    public static event Action<float> MultiplierText = delegate { };

    void OnEnable()
    {
        GetComponent<ScoreSystem>().ScoreUpdater += UpdatePoints;
        MultiplierSystem.Updater += UpdateMultiplier;
    }

    void OnDisable()
    {
        GetComponent<ScoreSystem>().ScoreUpdater -= UpdatePoints;
        MultiplierSystem.Updater -= UpdateMultiplier;
    }

    private void UpdatePoints(int points)
    {
        TextUpdate(points);
    }
    private void UpdateMultiplier(float points)
    {
        MultiplierText(points);
    }
}