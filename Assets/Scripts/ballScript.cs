using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class ballScript : MonoBehaviour
{
    Camera cam;
    Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.value,Random.value) * speed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += (new Vector3(0.09f, 0.05f, 0)); //randomly move ball
        
        WrapBall(); //pretty self explanatory, iyam
    }
    void WrapBall(){
        Vector3 destVp = new Vector3(0,0,cam.WorldToViewportPoint(transform.position).z); //Destination vecotr in Viewport space (easier to do math on)
        if(cam.WorldToViewportPoint(transform.position).x > 1
        || cam.WorldToViewportPoint(transform.position).x < 0
        || cam.WorldToViewportPoint(transform.position).y > 1
        || cam.WorldToViewportPoint(transform.position).y < 0){ //if out of bounds
            destVp.x = Mathf.Abs(cam.WorldToViewportPoint(transform.position).x - 1); //flippity
            destVp.y = Mathf.Abs(cam.WorldToViewportPoint(transform.position).y - 1); //floppity
            transform.position = cam.ViewportToWorldPoint(destVp); //your ball is my property
        }
    
    }
}
