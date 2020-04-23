using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorizingObstacle : MonoBehaviour
{
    public Color color;
    public int ColorIndex=0;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void SelectColor(){
        LevelManager manager = FindObjectOfType<LevelManager>();
        color.a =0;
        if (manager.colors[ColorIndex]==color){
            if (ColorIndex>=manager.colors.Length-1) ColorIndex = 0;
            else  ColorIndex++;
        }
        color = manager.colors[ColorIndex];
        color.a=1;
        // switch color 
        GetComponent<SpriteRenderer>().color = color;
    }
}
