using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float rotateSpeed;
    public float moveSpeed;
    public Vector3 center;

    // Update is called once per frame
    void Update()
    {
        //turn
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);

        //move
        transform.position += (transform.position - center).normalized * moveSpeed * Time.deltaTime;



    }
}
