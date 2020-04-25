
using UnityEngine;
public class IntToColor 
{
    public static Color32 switchColor(int index){
        if (index==0) return Color.white;
        else if (index==1) return Color.red;
        else if (index==2) return Color.blue;
        else if (index==3) return Color.green;
        else if (index==4) return Color.black;
        else return Color.white;
    }

}
public class Mixer{

    // color 0 + color 1 == 1
    // color 0 + color 2 == 2
    // color 1 + color 2 == 3
    // color 2 + color 1 == 3
    // color 3 + color 1 == 4
    public static int ColorIndex (int ObstacleColor, int ParitcleColor){
        if ((ObstacleColor==1&&ParitcleColor==2) 
            ||(ObstacleColor==2&&ParitcleColor==1)){
            return 3;
        }
        else if (ParitcleColor==3&&ObstacleColor==1){
            return 4;
        }
        else if (ParitcleColor==0){
            return ObstacleColor;
        }
        else return 0;
    }
}

 