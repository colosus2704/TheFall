using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardWriter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ScoresDB.CreateDB();
        GetComponent<Text>().text = ScoresDB.LeaderBoardPrint();
    }
}
