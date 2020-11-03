using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventThree : MonoBehaviour
{
    public bool SpawnPerson;
    public GameObject person;
    static int PersonNumber;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPerson = false;
        PersonNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // figure out how to not make seventy million clones of a car >:(
        if(SpawnPerson == true){
        Instantiate(person, new Vector3(1.3f, 37, 0), Quaternion.identity);
        SpawnPerson = false;
        PersonNumber ++;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && (PersonNumber <= 1)){
            SpawnPerson = true;
            Debug.Log("a car has been spawned by the player");
        }
    }
}
