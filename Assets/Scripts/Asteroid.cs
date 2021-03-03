using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Vector2 rotateSpeedRange;
    public Vector2 moveSpeedRange;
    public Vector3 center;

    float rotateSpeed;
    float moveSpeed;

    private void Start()
    {
        rotateSpeed = Random.Range(rotateSpeedRange.x, rotateSpeedRange.y);
        moveSpeed = Random.Range(moveSpeedRange.x, moveSpeedRange.y);
    }

    
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(other.collider.gameObject.name);

        if (other.collider.gameObject.GetComponent<BallScript>())
        {
            //change score
            GameManager.score++;
        }
        if (other.collider.gameObject.GetComponent<Paddle>())
        {
            Debug.Log("Game Over in Asteroid");

            //call gameover from singelton instance
            GameManager.instance.GameOver();
        }
        
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //turn
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);

        //move
        transform.position -= (transform.position - center).normalized * moveSpeed * Time.deltaTime;

        if(Vector3.Distance(transform.position, center) < 0.2f)
        {
            Destroy(this.gameObject);
        }

    }
}
