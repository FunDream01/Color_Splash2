using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Color32 [] colors;
    public Material GameMaterial;
    public static LevelManager instant;
    void Start()
    {
        instant=this;
    }
    void Update()
    {
        
    }
    public void ColorShader(){
        
        GameMaterial.SetColor("_1Color", colors[0]); // while 
        GameMaterial.SetColor("_2Color", colors[1]); // Red 
        GameMaterial.SetColor("_3Color", colors[2]); // Blue
        GameMaterial.SetColor("_4Color", colors[3]); // Green
        GameMaterial.SetColor("_5Color", colors[4]); // Yellow
        GameMaterial.SetColor("_6Color", colors[5]); // Pink
        GameMaterial.SetColor("_7Color", colors[6]); // cyan
        GameMaterial.SetColor("_8Color", colors[7]); // Black
    }
}
