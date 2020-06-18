using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject ball;
    public Transform spawner;
    public int NumberOfSteps=2;
    public int NumberOfBalls;
    public int FinalWinBalls;
    public int FinalLoseBalls;
    public bool startSpawning;
    public float delay = 0.1f;
    public float DropButtonActivate=2;
    float Angle = 0; 
    Vector2 ContainerPosition; 
    public Transform spawner2;
    public Transform spawner3;
    public int[] BallsOfSpawner;
    public static SpawnerManager Instance;

    const float LOSE_SECONDS = 14f;
    private void Awake() {
        
        Instance=this;
    }
    void Start() {
    }

    
    int step_when_invoked;
    //to start spawning
    public void SpawnButton()
    {
        startSpawning = true;                     //it will stay true forever unless
        switch(StepsManager.Instance.Step){
            case 0 :
                StartCoroutine(spawning1()); 
            break;
            case 1 :
                Angle=0;
                ContainerPosition=spawner2.transform.position;
                StartCoroutine(spawning2()); 
            break;
            case 2 :
                Angle=0;
                ContainerPosition=spawner3.transform.position;
                StartCoroutine(spawning3());
            break;
        }              
    

    }
    bool invoked;
    private void Update() {
        if(!invoked && NumberOfBalls <= FinalLoseBalls) {
        Invoke("CheckLoss",LOSE_SECONDS);
        invoked = true;
        step_when_invoked = StepsManager.Instance.Step;
        }
    }

    public void CheckLoss()
    {
        if(step_when_invoked == StepsManager.Instance.Step) LevelManager.instant.Lose();
        Debug.Log("# loss");
        invoked = false;
    }                             

    public void stopSpawningbutton()          
    {
        startSpawning = false;                    // we have this to stop the loop
                                                  // then from unity we add them to Trigger-event 
    }

    IEnumerator spawning1()
    {
        while (startSpawning&&NumberOfBalls>0) 
        {
            GameObject gameObject= Instantiate(ball, spawner.position, Quaternion.identity);   //we use this to spawn balls(game object,position , rotation)  Quaternion.identity means rotation =0
            gameObject.GetComponent<SpriteRenderer>().color=Color.white;
            NumberOfBalls--;
            yield return new WaitForSeconds(delay);                     //we have to have this to make (IEnumerator spawning()) works and we added delay to the spawning balls;
            if (NumberOfBalls==0){
                //this.SendMessage("Lose");
            }
        }
    }
    IEnumerator spawning2()
    {   
        while (startSpawning) 
        {
            /*
            if (Angle>-90)
                Angle=Angle-0.1f;
            */
            ContainerPosition.x +=0.1f;
            yield return new WaitForSeconds(delay);   
            spawner2.position = ContainerPosition;
            //spawner2.Rotate( new Vector3( 0, 0, Angle) );
        }
    }
    IEnumerator spawning3()
    {
        while (startSpawning) 
        {
            /*
            if (Angle>-90)
                Angle=Angle-0.1f;
            */  
            ContainerPosition.x +=0.1f;
            yield return new WaitForSeconds(delay);   
            spawner3.position = ContainerPosition; 
            //spawner3.Rotate( new Vector3( 0, 0, Angle) );
        }
    }
}
