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
   
    
    
    //to start spawning
    public void SpawnButton()
    {
        startSpawning = true;                     //it will stay true forever unless
        StartCoroutine(spawning());               //
    }                                             //
    public void stopSpawningbutton()              //
    {
        startSpawning = false;                    // we have this to stop the loop
                                                  // then from unity we add them to Trigger-event 
    }







    IEnumerator spawning()
    {
        while (startSpawning&&NumberOfBalls>0) 
        {
            Instantiate(ball, spawner.position, Quaternion.identity);   //we use this to spawn balls(game object,position , rotation)  Quaternion.identity means rotation =0
            NumberOfBalls--;
            yield return new WaitForSeconds(delay);                     //we have to have this to make (IEnumerator spawning()) works and we added delay to the spawning balls

        }
    }

   



}
