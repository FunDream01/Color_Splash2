using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Color32 [] colors;
    public Material GameMaterial;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void ColorShader(){
        
        GameMaterial.SetColor("_1Color", colors[0]);
        GameMaterial.SetColor("_2Color", colors[1]);
        GameMaterial.SetColor("_3Color", colors[2]);
        GameMaterial.SetColor("_4Color", colors[3]);
        GameMaterial.SetColor("_5Color", colors[4]);
        GameMaterial.SetColor("_6Color", colors[5]);
        GameMaterial.SetColor("_7Color", colors[6]);
        GameMaterial.SetColor("_8Color", colors[7]);
    }
}
