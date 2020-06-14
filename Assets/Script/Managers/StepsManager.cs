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
    
    public GameObject TwoSteps;
    public GameObject ThreeSteps;
    
    public ProgressLevel progress;
    void Start()
    {
        Instance=this;

        if (SpawnerManager.Instance.NumberOfSteps==0){

        }else if (SpawnerManager.Instance.NumberOfSteps==1)
        {
            GameObject indecator =  Instantiate(TwoSteps);
            progress=indecator.GetComponent<ProgressLevel>();
        }else if (SpawnerManager.Instance.NumberOfSteps==2){
            GameObject indecator =  Instantiate(ThreeSteps);
            progress=indecator.GetComponent<ProgressLevel>();
        }
    }
    void Update()
    {
        
    }
    public void NextStep( int step){
        
        FindObjectOfType<DrawLine>().enabled=false;
        FindObjectOfType<SpawnerManager>().enabled=false;
        FindObjectOfType<SpawnerManager>().stopSpawningbutton();
        //UiCanves.SetActive(false);
        if(progress!=null){
            progress.Dots[step-1].SetActive(true);
        }
        Vector3 pos = new Vector3(0,step*-7,-10);
        Cameras.transform.DOMove(pos,1,true).OnComplete(delegate{
            
            //FindObjectOfType<DrawLine>().ClearLines();
            FindObjectOfType<DrawLine>().enabled=true;
        });

    }
}
