using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicScript : MonoBehaviour
{
    static float FearMeter;
    static float MusicMeter;
    public Text FearText;
    public Text MusicText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // multiple fear states: completely content, unsettled, anxious, fearful, terrified
        if(FearMeter > 0f && FearMeter < 60f){
            FearText.text = "Fear Level: Unfazed";
        }
        if(FearMeter > 60f && FearMeter < 120f){
            FearText.text = "Fear Level: Unsettled";
        }
        if(FearMeter > 120f && FearMeter < 180f){
            FearText.text = "Fear Level: Anxious";
        }
        if(FearMeter > 180f && FearMeter < 240f){
            FearText.text = "Fear Level: Fearful";
        }
        if(FearMeter > 240f && FearMeter < 300f){
            FearText.text = "Fear Level: Terrified";
        }
        // multiple music states: beginning, past initial stages, halfway point, close to ending
        
    }
}
