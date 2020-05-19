using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public OurColor[] colors;
    public TextMeshProUGUI levelIndicator;
    public static LevelManager instant;
    public GameObject WinScreen;
    public GameObject LoseScreen;
    Analytics analytics;
    public GameObject analyticsPrefab;
    EndPointManager[] managers;
    int PlayerLevel;
    int Level;
    public bool Finish;
    public bool DidWin;
    void Start()
    {
        managers=FindObjectsOfType<EndPointManager>();

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
        levelIndicator.text= "Level "+ Level;

        PlayerLevel = PlayerPrefs.GetInt("PlayerLevel");
        instant=this;

        analytics = FindObjectOfType<Analytics>();
        if(analytics == null)
        {
            Instantiate(analyticsPrefab);
            analytics = analyticsPrefab.GetComponent<Analytics>();
        }
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        StartCoroutine(analytics.waitToCall(analytics.LogLevelStarted,SceneManager.GetActiveScene().buildIndex));
        
    }
    void Update()
    {
        
    }
    public void CheckEndPoints(){
        Finish =true;
        DidWin=true;

        foreach(EndPointManager end in managers){
            if (end.State==1){
                DidWin=false;
                //Finish =false;
                Lose();
                break;
            }
        }
        if (DidWin==true){

            foreach(EndPointManager end in managers){
                if (end.State==0){
                    Finish=false;
                    break;
                }
            }

            if (Finish==true){
                Win();
            }
        }
        
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
[System.Serializable]
public class OurColor{
    public string name;
    public Color Color;
}
