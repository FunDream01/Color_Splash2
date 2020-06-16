using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

           

// See https://www.alanzucconi.com/2015/07/26/enum-flags-and-bitwise-operators/
[Flags]
public enum COLOR_CODE : int
{
    NONE = 0,
    COLOR_0 = 1,
    COLOR_1 = 2,
    COLOR_2 = 4,
    COLOR_3 = 8,
    COLOR_4 = 16,
    COLOR_5 = 32 //Continue with 64,128,256,1024 etc. powers of 2.
}     


public class Mixer
{

    // color 0 + color 1 == 1
    // color 0 + color 2 == 2
    // color 1 + color 2 == 3
    // color 2 + color 1 == 3
    // color 3 + color 1 == 4
   
    public static COLOR_CODE ColorIndex(COLOR_CODE ObstacleColor, COLOR_CODE ParticleColor)
    {

       // if (ParticleColor == -1) return ObstacleColor;

        return (ObstacleColor | ParticleColor); //In a flag based system, you can combine this way.



        // white
        /*   if (ParitcleColor==-1){
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
          } */

        /*
        if (ParitcleColor==ObstacleColor+1){
            return ObstacleColor+2;
        }
        else if (ParitcleColor+1==ObstacleColor){
            return ParitcleColor+2;
        }
        */
        //else return 100;


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


    public static Color Index2Color(COLOR_CODE index, LevelManager lm)
    {
        if(index == COLOR_CODE.NONE) return new Color(1,1,1,1);
        byte[] bytes = BitConverter.GetBytes((int)index);

        int bitPos = 0;

        Color rs = new Color(1,1,1,1);
        bool rs_created = false;

        while (bitPos < 8 * bytes.Length)
        {
            int byteIndex = bitPos / 8;
            int offset = bitPos % 8;
            bool isSet = (bytes[byteIndex] & (1 << offset)) != 0;

            if(isSet)
            {
                if(!rs_created)
                {rs = lm.colors[bitPos].Color; 
                rs_created = true;}
                else
                {
                    if(bitPos < lm.colors.Length)
                    rs = ColorMix.CartoonMix(lm.colors[bitPos].Color, rs);
               // rs = ColorMix.AdjustSaturation(rs);
                } 

            }

            bitPos++;
        }
        return ColorMix.AdjustSaturation(rs);
    }

}
