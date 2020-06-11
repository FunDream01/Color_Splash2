using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class StepsManager : MonoBehaviour
{
    public int Step = 0 ;
    public GameObject Cameras;
    public GameObject UiCanves;
    public static StepsManager Instance;
    void Start()
    {
        Instance=this;
    }
    void Update()
    {
        
    }
    public void NextStep( int step){
        
        FindObjectOfType<DrawLine>().enabled=false;
        FindObjectOfType<SpawnerManager>().enabled=false;
        FindObjectOfType<SpawnerManager>().stopSpawningbutton();
        //UiCanves.SetActive(false);

        Vector3 pos = new Vector3(0,step*-7,-10);
        Cameras.transform.DOMove(pos,1,true).OnComplete(delegate{
            
            //FindObjectOfType<DrawLine>().ClearLines();
            FindObjectOfType<DrawLine>().enabled=true;
        });

    }
}
