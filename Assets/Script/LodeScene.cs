using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LodeScene : MonoBehaviour
{
    public int PlayerLevel;
    void Start()
    {
      /*   //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.HasKey("PlayerLevel"))
        {
            PlayerLevel = PlayerPrefs.GetInt("PlayerLevel");
            
            if (PlayerLevel > 12)
            {
                PlayerPrefs.SetInt("PlayerLevel", 1);
            }
            
        }
        else
        {
            PlayerPrefs.SetInt("PlayerLevel", 1);
            PlayerLevel=PlayerPrefs.GetInt("PlayerLevel");
        }
         */
        int lvl = PlayerPrefs.GetInt("PlayerLevel",2);
        lvl = Mathf.Min(lvl,13);
        PlayerPrefs.SetInt("PlayerLevel", lvl);
        SceneManager.LoadScene(lvl);
    }
    void Update()
    {
        
    }
}
