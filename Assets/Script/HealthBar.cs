using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform Bar;

    void Start()
    {   
        
    }

    void Update()
    {
        
    }
    public void BarSize(float size)
    {
        Bar.localScale = new Vector2 (size, 1f);
    }

}
