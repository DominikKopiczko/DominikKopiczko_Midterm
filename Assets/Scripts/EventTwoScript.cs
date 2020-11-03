using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTwoScript : MonoBehaviour
{
    public bool SpawnCar;
    public GameObject car;
    static int CarNumber;
    // Start is called before the first frame update
    void Start()
    {
        SpawnCar = false;
        CarNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // figure out how to not make seventy million clones of a car >:(
        if(SpawnCar == true){
        Instantiate(car, new Vector3(-22, 20, 0), Quaternion.identity);
        SpawnCar = false;
        CarNumber ++;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && (CarNumber <= 1)){
            SpawnCar = true;
            Debug.Log("a car has been spawned by the player");
        }
    }
}
