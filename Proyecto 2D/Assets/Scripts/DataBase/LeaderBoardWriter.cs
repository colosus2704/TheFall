using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardWriter : MonoBehaviour
{
    void Start()
    {
        ScoresDB.CreateDB();
        GetComponent<Text>().text = ScoresDB.LeaderBoardPrint();
    }
}
