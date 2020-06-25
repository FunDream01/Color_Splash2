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
    public int PlayerLevel;
    public int Level;
    public bool Finish;
    public bool DidWin;
    void Start()
    {

        managers=FindObjectsOfType<EndPointManager>();
        
        PlayerLevel = PlayerPrefs.GetInt("PlayerLevel");
        if (SceneManager.GetActiveScene().buildIndex!=PlayerLevel&&PlayerLevel<=13){
            
            PlayerPrefs.SetInt("PlayerLevel",SceneManager.GetActiveScene().buildIndex);
            PlayerLevel = PlayerPrefs.GetInt("PlayerLevel");

        }
        
        levelIndicator=GameObject.FindGameObjectWithTag(Tags.indicator).GetComponent<TextMeshProUGUI>();
        levelIndicator.text= "Level "+ (PlayerLevel -1 );

      
        //Level = PlayerPrefs.GetInt("Level", 1);
       
        /*
        if (PlayerLevel>=12)// total num of levels 
        {
            Level = PlayerPrefs.GetInt("Level");
            levelIndicator=GameObject.FindGameObjectWithTag(Tags.indicator).GetComponent<TextMeshProUGUI>();
            levelIndicator.text= "Level "+ Level;
        }else{
            
            levelIndicator=GameObject.FindGameObjectWithTag(Tags.indicator).GetComponent<TextMeshProUGUI>();
            levelIndicator.text= "Level "+ PlayerLevel;
        }
        */

        instant=this;

        analytics = FindObjectOfType<Analytics>();
        if(analytics == null)
        {
            Instantiate(analyticsPrefab);
            analytics = analyticsPrefab.GetComponent<Analytics>();
        }
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        StartCoroutine(analytics.waitToCall(analytics.LogLevelStarted,SceneManager.GetActiveScene().buildIndex - 1));
        
        
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
        if(!DidWin){ // call function once
            Debug.Log("Win");
            /*
            Level = PlayerPrefs.GetInt("Level");
            PlayerPrefs.SetInt("Level",Level+1);
            */
            if(StepsManager.Instance.progress!=null){
            StepsManager.Instance.progress.Dots[StepsManager.Instance.Step].SetActive(true);
            }
            analytics.LogLevelSucceeded(SceneManager.GetActiveScene().buildIndex - 1);
            PlayerPrefs.SetInt("PlayerLevel", PlayerLevel+1);
            PlayerLevel = PlayerPrefs.GetInt("PlayerLevel");
            FinishGamePlay();
            WinScreen.SetActive(true);
            DidWin=true;
        var x = FindObjectOfType<DrawLine>().HandDrop;
        if(x != null) x.SetActive(false);
        }    
    }
    public void Lose(){

       if(LevelManager.instant.DidWin) return;
        analytics.LogLevelFailed(SceneManager.GetActiveScene().buildIndex - 1);
        Debug.Log("Lose");
        FinishGamePlay();
        LoseScreen.SetActive(true);
        var x = FindObjectOfType<DrawLine>().HandDrop;
        if(x != null) x.SetActive(false);
    }
    void FinishGamePlay(){
        FindObjectOfType<DrawLine>().enabled=false;
        GameObject.FindGameObjectWithTag(Tags.UI).SetActive(false);
    }
    public void RestartScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }public void NextLevel(){
        if (PlayerLevel>13){
            int RandomLevel = Random.Range(4,14);
            SceneManager.LoadScene(RandomLevel);
        }else{
            
            SceneManager.LoadScene(PlayerLevel);
        }
    }
}
[System.Serializable]
public class OurColor{
    public string name;
    public Color Color;
}
