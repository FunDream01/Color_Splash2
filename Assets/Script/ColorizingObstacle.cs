using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorizingObstacle : MonoBehaviour
{
    public Color color;
    public int ColorIndex=0;
    [HideInInspector]
    public bool Started=false;
    
    void Start()
    {
        Started=true;
        //Color();
    }

    void Update()
    {
        
    }
    public void Color(){ 

        LevelManager manager = FindObjectOfType<LevelManager>();
        color.a =0;
        if (manager.colors[ColorIndex].Color==color){
            if (ColorIndex>=manager.colors.Length-1) ColorIndex = 0;
            else  ColorIndex++;
        }
        color = manager.colors[ColorIndex].Color;
        color.a=1;
        // switch color 
        GetComponent<SpriteRenderer>().color = color;
    }
}
