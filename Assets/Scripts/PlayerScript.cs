using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{       
    public float speed;
    Vector3 movement;    
    public Vector3 LightScaleRate = new Vector3(0.5f,0.5f,0);  
    AudioSource MusicSource;
    bool MusicPlaying;  
    public SpriteRenderer LightSprite;
    void Start()
    {
       MusicSource = GetComponent<AudioSource>();
       MusicPlaying = true;
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

    }
}
