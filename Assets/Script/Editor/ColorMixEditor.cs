using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ColorMix))]
public class ColorMixEditor: Editor 
{
    
   ColorMix CM;
    
    
    void OnEnable()
    {
        CM = base.target as ColorMix;
    }

    public override void OnInspectorGUI()
    {

        base.OnInspectorGUI();
        
        if(GUI.changed || CM.lc == null || CM.lc.SequenceEqual(CM.GetComponent<LevelManager>().colors)){ 
        CM.lc = new List<OurColor>(CM.GetComponent<LevelManager>().colors);
        CM.C1 = Mixer.Index2Color(CM.color1, CM.GetComponent<LevelManager>()); 
        CM.C2 = Mixer.Index2Color(CM.color2, CM.GetComponent<LevelManager>());
      /*   CM.SoftenedRGBSubtractiveMix = ColorMix.s_mix_soft(CM.C1,CM.C2);
        CM.XYZAdditiveMix = ColorMix.XYZMix(CM.C1,CM.C2);
        CM.CartoonUnadjusted= ColorMix.CartoonMix(CM.C1,CM.C2);
        CM.SaturationAdjustedRGBSubtractive = ColorMix.AdjustSaturation(ColorMix.s_mix_soft(CM.C1,CM.C2));
        CM.SaturationAdjustedXYZAdditive = ColorMix.AdjustSaturation(ColorMix.XYZMix(CM.C1,CM.C2));
        CM.CartoonAdjusted = ColorMix.AdjustSaturation(ColorMix.CartoonMix(CM.C1,CM.C2)); */
        EditorGUILayout.LabelField("Mixed Color: " + (CM.color1|CM.color2).ToString());
        CM.ResultingColor = Mixer.Index2Color(CM.color1 | CM.color2, CM.GetComponent<LevelManager>());
    }
    }
}

