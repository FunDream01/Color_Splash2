using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LodeScene : MonoBehaviour
{
    public int PlayerLevel;
    void Start()
    {
        PlayerPrefs.DeleteAll();
        if (PlayerPrefs.HasKey("PlayerLevel"))
        {
            PlayerLevel = PlayerPrefs.GetInt("PlayerLevel");
            if (PlayerLevel > 20)
            {
                PlayerPrefs.SetInt("PlayerLevel", 1);
            }
            
        }
        else
        {
            PlayerPrefs.SetInt("PlayerLevel", 1);
            PlayerLevel=PlayerPrefs.GetInt("PlayerLevel");
        }
        
        SceneManager.LoadScene(PlayerLevel);
    }
    void Update()
    {
        
    }
}
