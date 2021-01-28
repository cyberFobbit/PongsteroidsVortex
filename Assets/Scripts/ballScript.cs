using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class BallScript : MonoBehaviour
{
    Camera cam;
    Rigidbody2D rb;
    public float speed;
    public Vector3 center;
    // Start is called before the first frame update
    void Start()
    {
        //set global variables
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();


        rb.AddForce(new Vector2(0,1) * speed, ForceMode2D.Impulse); //give the ball a swift kick to the pants
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = speed * Vector3.Normalize(Vector2.Lerp(Vector3.Normalize(rb.velocity), -1 * Vector3.Normalize(transform.position), 0.5f * Time.deltaTime)); //maintain a constant speed and drift towards the center
        WrapBall(); //pretty self explanatory, iyam
    }
    
    void WrapBall(){
        Vector3 destVp = cam.WorldToViewportPoint(transform.position); //Destination vector in Viewport space (easier to do math on)
        if(cam.WorldToViewportPoint(transform.position).x > 1
        || cam.WorldToViewportPoint(transform.position).x < 0){
            destVp.x = Mathf.Abs(cam.WorldToViewportPoint(transform.position).x - 1); //flippity
            transform.position = cam.ViewportToWorldPoint(destVp); //your ball is my property
        }
        if(cam.WorldToViewportPoint(transform.position).y > 1
        || cam.WorldToViewportPoint(transform.position).y < 0){ //if out of bounds
            destVp.y = Mathf.Abs(cam.WorldToViewportPoint(transform.position).y - 1); //floppity
            transform.position = cam.ViewportToWorldPoint(destVp); //your ball is my property
        }
    
    }
}
