//FunDream Studios 2020

using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ColorMix : MonoBehaviour
{
    
    public COLOR_CODE color1;
    public Color C1;
    public COLOR_CODE color2;
    public Color C2;

    [HideInInspector] public List<OurColor> lc;


    [Header("Mixed Result")] 
  /*   public Color SoftenedRGBSubtractiveMix; //https://en.wikipedia.org/wiki/Subtractive_color
    public Color XYZAdditiveMix; //https://en.wikipedia.org/wiki/SRGB#The_sRGB_transfer_function_.28.22gamma.22.29
    public Color CartoonUnadjusted; //https://en.wikipedia.org/wiki/Alpha_compositing#Alpha_blending 

    [Header("C1 & C2 - Saturation and Brightness Adjusted Results")] 
    public Color SaturationAdjustedRGBSubtractive;
    public Color SaturationAdjustedXYZAdditive; */
    public Color ResultingColor;


    public static Color s_mix_soft(Color c1, Color c2)
    {
        
        double[] col = new double[3];
        col[0] = 1f - Math.Sqrt(((Math.Pow((double)(1f-c1.r),2.0) + Math.Pow((double)(1f-c2.r),2.0))/2.0));
        col[1] = 1f - Math.Sqrt(((Math.Pow((double)(1f-c1.g),2.0) + Math.Pow((double)(1f-c2.g),2.0))/2.0));
        col[2] = 1f - Math.Sqrt(((Math.Pow((double)(1f-c1.b),2.0) + Math.Pow((double)(1f-c2.b),2.0))/2.0));

        return new Color((float)col[0],(float)col[1],(float)col[2],1);
    }



    public static Color XYZMix(Color c1, Color c2)
    {
        double[] rgb1 = new double[3];
        double[] rgb2 = new double[3];
        rgb1[0] =  c1.r;
        rgb1[1] =  c1.g;
        rgb1[2] =  c1.b;
        rgb2[0] =  c2.r;
        rgb2[1] =  c2.g;
        rgb2[2] =  c2.b;
        double[] xyz1= SRGB2XYZ(rgb1);
        double[] xyz2= SRGB2XYZ(rgb2);
        double[] result = new double[3];
        result[0] = (xyz1[0] + xyz2[0]);
        result[1] = (xyz1[1] + xyz2[1]);
        result[2] = (xyz1[2] + xyz2[2]);
        double[] rgbresult = XYZ2SRGB(result);
        return new Color((float)rgbresult[0],(float)rgbresult[1],(float)rgbresult[2]);
    }


    public static Color CartoonMix(Color c1, Color c2)
    {
        c1.a /= 2f;
        return AlphaBlend(c1,c2);
    }


    public static Color AdjustSaturation(Color rs)
    {   
        float H,S,V;
        Color.RGBToHSV(rs,out H, out  S, out V);
        S = 1f;
        V = 1f;
        rs = Color.HSVToRGB(H,S,V,false);
        return rs;
    }
    
    
    //FOR XYZ MIX
    
    public static double[] XYZ2SRGB(double[] xyz)
    {
        double[] d = new double[3];
        d[0] =  3.2404542*xyz[0] - 1.5371385*xyz[1] - 0.4985314*xyz[2];
        d[1] = -0.9692660*xyz[0] + 1.8760108*xyz[1] + 0.0415560*xyz[2];
        d[2] =  0.0556434*xyz[0] - 0.2040259*xyz[1] + 1.0572252*xyz[2];
        d[0] = adj_f(d[0]);
        d[1] = adj_f(d[1]);
        d[2] = adj_f(d[2]);
        return d;
    }

    public static double[] SRGB2XYZ(double[] rgb)
    {
        double[] d  = new double[3];
        rgb[0] = adj_r(rgb[0]);
        rgb[1] = adj_r(rgb[1]);
        rgb[2] = adj_r(rgb[2]);
        d[0] =  0.41239080*rgb[0] + 0.35758434*rgb[1] + 0.18048079*rgb[2];
        d[1] =  0.21263901*rgb[0] + 0.71516868*rgb[1] + 0.07219242*rgb[2];
        d[2] =  0.01933082*rgb[0] + 0.11919478*rgb[1] + 0.95053215*rgb[2];
        return d;
    }


    static double  adj_f(double C) {
    if (Math.Abs(C) < 0.0031308) {
        return 12.92 * C;
    }
    return 1.055 * Math.Pow(C, 0.41666) - 0.055;
    }

    static double adj_r(double C) {
    if (Math.Abs(C) < 0.04045) {
        return (1/12.92) * C;
    }
    return Math.Pow(((C + 0.055)/(1.055)),2.4);
    }

    //FOR CARTOON MIX:

    public static Color AlphaBlend(Color src,Color dst)
    {
        Color outy = new Color();
        outy.a = src.a  + dst.a * (1f - src.a);
        if(outy.a != 0)
        {
        outy.r = (src.r*src.a + dst.r*dst.a*(1f-src.a)) / outy.a;
        outy.g = (src.g*src.a + dst.g*dst.a*(1f-src.a)) / outy.a;
        outy.b = (src.b*src.a + dst.b*dst.a*(1f-src.a)) / outy.a;
        }
        return outy;
    }

}
