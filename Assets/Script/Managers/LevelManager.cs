using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Color32 [] colors;
    public Material GameMaterial;
    public static LevelManager instant;
    public int WinColor;
    public GameObject WinScreen;
    public GameObject LoseScreen;
    
    void Start()
    {
        instant=this;
        ColorShader();
    }
    void Update()
    {
        
    }
    public void ColorShader(){
        
        GameMaterial.SetColor("_1Color", colors[0]); // while 
        GameMaterial.SetColor("_2Color", colors[1]); // Red 
        GameMaterial.SetColor("_3Color", colors[2]); // Blue
        GameMaterial.SetColor("_4Color", colors[3]); // Green
        GameMaterial.SetColor("_5Color", colors[4]); // Black
    }
    public void Win(){
        WinScreen.SetActive(true);
    }
    public void Lose(){
        LoseScreen.SetActive(true);
    }
    public void RestartScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
