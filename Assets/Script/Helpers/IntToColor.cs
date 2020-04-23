
using UnityEngine;
public class IntToColor 
{
    public static Color32 switchColor(int index){
        if (index==0) return Color.white;
        else if (index==1) return Color.red;
        else if (index==2) return Color.blue;
        else if (index==3) return Color.green;
        else if (index==4) return Color.yellow;
        else if (index==5) return Color.magenta;
        else if (index==6) return Color.cyan;
        else if (index==7) return Color.black;
        else return Color.white;
    }

}
public class Mixer{
    public static int ColorIndex (int ObstacleColor, int ParitcleColor){
        if ((ObstacleColor==1&&ParitcleColor==2)
            ||(ObstacleColor==2&&ParitcleColor==1)){
            return 3;
        }
        else if ((ObstacleColor==4&&ParitcleColor==5)
            ||(ObstacleColor==5&&ParitcleColor==4)){
            return 6;
        }
        else if (ParitcleColor==0){
            return ObstacleColor;
        }
        else return 0;
    }
}

 