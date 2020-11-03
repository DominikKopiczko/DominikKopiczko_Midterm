 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;
 public class CarScript : MonoBehaviour
 {
    private Vector3 startPos;
    public Transform target;
    public float speed;
    void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards (transform.position, target.position, step);
    }
    void OnTriggerEnter2D(Collider2D collision)
    { 
        Destroy(gameObject);
    }
}