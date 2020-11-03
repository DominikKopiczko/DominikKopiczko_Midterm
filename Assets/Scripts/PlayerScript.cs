using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{       
    public float speed;
    Vector3 movement;    
    public Vector3 LightScaleRate = new Vector3(0.5f,0.5f,0);  
    static AudioSource MusicSource;
    static bool MusicPlaying;  
    public SpriteRenderer LightSprite;
    static float FearMeter;
    static float MusicMeter;
    public Text FearText;
    public Text MusicText;
    public Text EndText;
    void Start()
    {
       MusicSource = GetComponent<AudioSource>();
       MusicPlaying = true;
       FearMeter = 0;
       MusicMeter = 4060;
    }

    void Update()
    {
        // movement
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        movement = new Vector3(moveHorizontal, moveVertical, 0f );
        movement = movement * speed * Time.deltaTime;
        transform.position += movement;

        // turn music on/off with a button 
        // if music is playing, pressing left shift will pause it
        if (MusicPlaying == true && Input.GetKeyDown(KeyCode.LeftShift)){
            MusicSource.Pause();
            MusicPlaying = false;
        }
        // if music is paused, pressing space will resume it
        if (MusicPlaying == false && Input.GetKeyDown(KeyCode.Space)){
            MusicSource.Play();
            MusicPlaying = true;
        }        

        // light changes with music
        // if music is playing, circle gets smaller
        if (MusicPlaying == true && LightSprite.transform.localScale.x >= 3){
           LightSprite.transform.localScale -= LightScaleRate * Time.deltaTime;

        }
        // if music is paused, circle gets bigger
        if (MusicPlaying == false && LightSprite.transform.localScale.x <= 5){
           LightSprite.transform.localScale += LightScaleRate * Time.deltaTime;

        }
        // if music is playing, music meter goes down and fear meter goes down
        if (MusicPlaying == true && MusicMeter > 0){
            MusicMeter = MusicMeter - 0.1f;
            Debug.Log(MusicMeter);
            if(FearMeter > 0){
            FearMeter = FearMeter - 0.1f;
            Debug.Log(FearMeter);
            }
        }
        // if music is off, music meter stops and fear meter goes up
        if (MusicPlaying == false && MusicMeter > 0){
            FearMeter = FearMeter + 0.1f;
            Debug.Log(MusicMeter);
            Debug.Log(FearMeter);
        }    
        // multiple fear states: completely content, unsettled, anxious, fearful, terrified
        if(FearMeter >= 0f && FearMeter < 60f){
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
        // multiple music states: beginning, mid-halfway, halfway point, mid-end, close to ending, about to end.
        if(MusicMeter >= 0f && MusicMeter < 580f){
            MusicText.text = "Music Level: About To End";
        }
        if(MusicMeter > 580f && MusicMeter < 1160f){
            MusicText.text = "Music Level: Close To Ending";
        }
        if(MusicMeter > 1160f && MusicMeter < 1740f){
            MusicText.text = "Music Level: Mid Ending";
        }
        if(MusicMeter > 1740f && MusicMeter < 2320f){
            MusicText.text = "Music Level: Halfway Point";
        }
        if(MusicMeter > 2900f && MusicMeter < 3480f){
            MusicText.text = "Music Level: Mid Halfway";
        } 
        if(MusicMeter > 3480f && MusicMeter < 4060f){
            MusicText.text = "Music Level: Beginning";
        } 
        // if music meter is 0, end game
        if (MusicMeter <= 0){
            EndText.text = "The End!";
            Debug.Log("End Game");
        }
        // if fear meter is 100, end game
        if (FearMeter >= 500){
            EndText.text = "The End!";
            Debug.Log("End Game");
        }
    }
}
