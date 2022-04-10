using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealthbar : MonoBehaviour
{
    public Image Bar;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void BarSize(float amount)
    {
        Bar.fillAmount = amount;
    }
}
