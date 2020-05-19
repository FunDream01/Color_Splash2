
public class Mixer{

    // color 0 + color 1 == 1
    // color 0 + color 2 == 2
    // color 1 + color 2 == 3
    // color 2 + color 1 == 3
    // color 3 + color 1 == 4
    public static int ColorIndex (int ObstacleColor, int ParitcleColor)
    {
        // white
        if (ParitcleColor==-1){
            return ObstacleColor;
        }
        
        if ((ObstacleColor==0&&ParitcleColor==1) 
            ||(ObstacleColor==1&&ParitcleColor==0)){
            return 4;
        }
        if ((ObstacleColor==0&&ParitcleColor==2) 
            ||(ObstacleColor==2&&ParitcleColor==0)){
            return 5;
        }
        if ((ObstacleColor==0&&ParitcleColor==3) 
            ||(ObstacleColor==3&&ParitcleColor==0)){
            return 6;
        }
        if ((ObstacleColor==1&&ParitcleColor==2) 
            ||(ObstacleColor==2&&ParitcleColor==1)){
            return 7;
        }
        if ((ObstacleColor==1&&ParitcleColor==3) 
            ||(ObstacleColor==3&&ParitcleColor==1)){
            return 8;
        }
        if ((ObstacleColor==2&&ParitcleColor==4) 
            ||(ObstacleColor==4&&ParitcleColor==2)){
            return 9;
        }

        if ((ObstacleColor==4&&ParitcleColor==2) 
            ||(ObstacleColor==2&&ParitcleColor==4)){
            return 10;
        }if ((ObstacleColor==7&&ParitcleColor==3) 
            ||(ObstacleColor==3&&ParitcleColor==7)){
            return 11;
        }if ((ObstacleColor==3&&ParitcleColor==4) 
            ||(ObstacleColor==4&&ParitcleColor==3)){
            return 12;
        }if ((ObstacleColor==8&&ParitcleColor==4) 
            ||(ObstacleColor==4&&ParitcleColor==8)){
            return 13;
        }
        
        /*
        if (ParitcleColor==ObstacleColor+1){
            return ObstacleColor+2;
        }
        else if (ParitcleColor+1==ObstacleColor){
            return ParitcleColor+2;
        }
        */
        else return 100;
        
       
        /*
        else if (ParitcleColor==3&&ObstacleColor==1){
            return 4;
        }
        else if (ParitcleColor==0){
            return ObstacleColor;
        }
        else return 0;
        */
    }
}

 