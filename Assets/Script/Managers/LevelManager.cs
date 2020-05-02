using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Text levelIndicator;
    public Color32 [] colors;
    public Material GameMaterial;
    public static LevelManager instant;
    public int WinColor;
    public GameObject WinScreen;
    public GameObject LoseScreen;
    
    int PlayerLevel;
    
    void Start()
    {
        PlayerLevel = PlayerPrefs.GetInt("PlayerLevel");
        levelIndicator=GameObject.FindGameObjectWithTag(Tags.indicator).GetComponent<Text>();
        levelIndicator.text= "Level "+ PlayerLevel;
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
        
        if (PlayerLevel+1>11){
            PlayerPrefs.SetInt("PlayerLevel", 1);
        }else{
            PlayerPrefs.SetInt("PlayerLevel", PlayerLevel+1);
        }
        PlayerLevel = PlayerPrefs.GetInt("PlayerLevel");
        FinishGamePlay();
        WinScreen.SetActive(true);
    }
    public void Lose(){
        FinishGamePlay();
        LoseScreen.SetActive(true);
    }
    void FinishGamePlay(){
        FindObjectOfType<DrawLine>().enabled=false;
        GameObject.FindGameObjectWithTag(Tags.UI).SetActive(false);
    }
    public void RestartScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }public void NextLevel(){
        SceneManager.LoadScene(PlayerLevel);
    }
}
