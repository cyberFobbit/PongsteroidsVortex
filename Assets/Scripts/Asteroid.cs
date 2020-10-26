using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float rotateSpeed;
    public float moveSpeed;
    public Vector3 center;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //turn
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
        transform.position += (transform.position - center).normalized * moveSpeed * Time.deltaTime;



    }
}
