using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventOneScript : MonoBehaviour
{
    public SpriteRenderer EnvLightSprite1;
    public SpriteRenderer EnvLightSprite2;
    public Vector3 LightScaleRate = new Vector3(0.5f,0.5f,0);  
    public bool LightsOff;
    // Start is called before the first frame update
    void Start()
    {
        LightsOff = false;
        // eventually make a list of all the lights in order to change them at once or figure out how to use game object to change all of them
    }

    // Update is called once per frame
    void Update()
    {
        if(LightsOff == true && EnvLightSprite1.transform.localScale.x >= 0){
            EnvLightSprite1.transform.localScale -= LightScaleRate * Time.deltaTime;
        }
        if(LightsOff == true && EnvLightSprite2.transform.localScale.x >= 0){
            EnvLightSprite2.transform.localScale -= LightScaleRate * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")){
            LightsOff = true;
            Debug.Log("lights have been triggered by player");
        }
    }
}
