using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Text scoreCountText;
    int count = 00;
    void Start()
    {
        
    }

    void Update()
    {
        scoreCountText.text = count.ToString();
    }
    public void AddScore()
    {
        count++;
    }
}
