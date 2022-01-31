using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreSystem : MonoBehaviour
{
    public event Action<int> ScoreUpdater = delegate { };

    private int Score = 0;

    private void Start()
    {
        ResetPoints();
        ScoreUpdater(GetPoints());
    }

    public void FixedUpdate()
    {
        ScoreIncreaser(1);
    }

    public void ScoreIncreaser(int points)
    {
        Score += points;
        ScoreUpdater(GetPoints());
        
    }

    public void ResetPoints()
    {
        Score = 0;
    }

    public int GetPoints()
    {
        return Score;
    }

}
