using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI levelIndicator;
    public Color32 [] colors;
    public Material GameMaterial;
    public static LevelManager instant;
    public int WinColor;
    public GameObject WinScreen;
    public GameObject LoseScreen;
    Analytics analytics;
    public GameObject analyticsPrefab;
    int PlayerLevel;
    int Level;
    
    void Start()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            Level = PlayerPrefs.GetInt("Level");
        }
        else
        {
            PlayerPrefs.SetInt("Level", 1);
        }
        Level = PlayerPrefs.GetInt("Level");
        levelIndicator=GameObject.FindGameObjectWithTag(Tags.indicator).GetComponent<TextMeshProUGUI>();
        levelIndicator.text= "Level "+ (Level+1);
        PlayerLevel = PlayerPrefs.GetInt("PlayerLevel");
        instant=this;

        ColorShader();
        analytics = FindObjectOfType<Analytics>();
        if(analytics == null)
        {
            Instantiate(analyticsPrefab);
            analytics = analyticsPrefab.GetComponent<Analytics>();
        }
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        StartCoroutine(analytics.waitToCall(analytics.LogLevelStarted,SceneManager.GetActiveScene().buildIndex));
        
        //ameObject.FindGameObjectWithTag(Tags.Resrart).GetComponent<Button>().onClick.AddListener(delegate{RestartScene();});
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
        Debug.Log("Win");
        Level = PlayerPrefs.GetInt("Level");
        Level++;
        PlayerPrefs.SetInt("Level",Level);

        analytics.LogLevelSucceeded(SceneManager.GetActiveScene().buildIndex);
        if (PlayerLevel+1>20){
            PlayerPrefs.SetInt("PlayerLevel", 1);
        }else{
            PlayerPrefs.SetInt("PlayerLevel", PlayerLevel+1);
        }
        PlayerLevel = PlayerPrefs.GetInt("PlayerLevel");
        FinishGamePlay();
        WinScreen.SetActive(true);
    }
    public void Lose(){
        
        analytics.LogLevelFailed(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Lose");
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
