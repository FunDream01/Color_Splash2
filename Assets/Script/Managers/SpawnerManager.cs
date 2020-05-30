using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject ball;
    public Transform spawner;
    public int NumberOfBalls;
    public bool startSpawning;
    public float delay = 0.1f;
    float Angle = 0; 
    public Transform spawner2;
    public Transform spawner3;
    //to start spawning
    public void SpawnButton()
    {
        startSpawning = true;                     //it will stay true forever unless
        switch(StepsManager.Instance.Step){
            case 0 :
                StartCoroutine(spawning1()); 
            break;
            case 1 :
                StartCoroutine(spawning2()); 
            break;
            case 2 :
                StartCoroutine(spawning3());
            break;
        }              
    }                                             
    public void stopSpawningbutton()              //
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
            if (Angle<0&&Angle>-90){
                Angle=Angle-0.1f;
                yield return new WaitForSeconds(delay);   
            }
            spawner2.Rotate( new Vector3( 0, 0, Angle) );
        }
    }
    IEnumerator spawning3()
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

}
