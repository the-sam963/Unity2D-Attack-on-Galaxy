using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Renderer mashRenderer;
    public float speed;

    void Start()
    {
        
    }

    
    void Update()
    {
        Vector2 offSet = mashRenderer.material.mainTextureOffset;
        offSet = offSet + new Vector2(0, speed*Time.deltaTime);
        mashRenderer.material.mainTextureOffset = offSet;
    }
}
