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

    public float gravityScale;

    bool trailOff = false;
    TrailRenderer trail;
    // Start is called before the first frame update
    void Start()
    {
        //set global variables
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        trail = GetComponent<TrailRenderer>();

        rb.AddForce(new Vector2(0,1) * speed, ForceMode2D.Impulse); //give the ball a swift kick to the pants
    }

    // Update is called once per frame
    void Update()
    {
        if (trailOff)
        {
            trail.emitting = true;
            trailOff = false;
        }

        //rb.velocity = speed * Vector3.Normalize(Vector2.Lerp(Vector3.Normalize(rb.velocity), -1 * Vector3.Normalize(transform.position), gravityScale * Time.deltaTime)); //maintain a constant speed and drift towards the center
        rb.AddForce(-transform.position * gravityScale, ForceMode2D.Force);
        
        //TorusWrapBall(); //pretty self explanatory, iyam
    }
    void TorusWrapBall(){

        Vector3 screenPos = cam.WorldToViewportPoint(transform.position); //just store this for better readability

        Vector3 destVp = cam.WorldToViewportPoint(transform.position); //Destination vector in Viewport space (easier to do math on)
        
        if(screenPos.x > 1|| screenPos.x < 0) //if out of bounds x
        {
            trail.emitting = false;
            trailOff = true;

            destVp.x = Mathf.Abs(screenPos.x - 0.99f); //flippity
            transform.position = cam.ViewportToWorldPoint(destVp); //your ball is my property
        }
        if(screenPos.y > 1 || screenPos.y < 0) //if out of bounds y
        { 
            trail.emitting = false;
            trailOff = true;

            destVp.y = Mathf.Abs(screenPos.y - 0.99f); //floppity
            transform.position = cam.ViewportToWorldPoint(destVp); //your ball is my property
        }
    
    }
}
