using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointManager : MonoBehaviour
{
    public ParticleSystem WinParticalSystem;
    public COLOR_CODE WinColor;
    
    public Color32 WinColor32;
    private int WinPartical;
    public int NumberOfParticalToWin;
    private int ElsePartical;
    public int NumberOfParticalToLose;
    public bool Filled;
    public bool Win;
    public int State=0; 
    public SpriteRenderer Colored;
    public Color32 spcolor;

    void Start()
    {
       // WinColor=LevelManager.instant.WinColor;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tags.Particle)&&StepsManager.Instance.Step==SpawnerManager.Instance.NumberOfSteps){

            Destroy(other.gameObject);
            Particle particle=other.GetComponent<Particle>();

            if (particle.ColorIndex==WinColor){
                WinColor32=particle.GetComponent<SpriteRenderer>().color;
                WinPartical++;
                FillWinColor();
                if (WinPartical==SpawnerManager.Instance.FinalWinBalls){
                    State=2;
                    Filled=true;
                    Win=true;
                }
            }
            else{
                ElsePartical++;
                if (ElsePartical==SpawnerManager.Instance.FinalLoseBalls){
                    State=1;
                    Filled=true;
                    Win=false;
                    //LevelManager.instant.CheckEndPoints();
                }
            }
        }
        if (Filled){
            if(Win){
                
                LevelManager.instant.Win();
                
            }else{

                LevelManager.instant.Lose();
            }
        }
    }
    void FillWinColor(){
        spcolor = Colored.color;
        if (spcolor.a>230){
            spcolor.a=255;
        }else{ 
            spcolor.a+=10;
        }
        Colored.color = spcolor;
        WinParticalSystem.startColor=WinColor32;
        //WinParticalSystem.Play();
        Instantiate(WinParticalSystem);
    }
}
