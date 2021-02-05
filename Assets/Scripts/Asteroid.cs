using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Vector2 rotateSpeedRange;
    public Vector2 moveSpeedRange;
    public Vector3 center;

    public GameObject gameManager;

    float rotateSpeed;
    float moveSpeed;

    private void Start()
    {
        rotateSpeed = Random.Range(rotateSpeedRange.x, rotateSpeedRange.y);
        moveSpeed = Random.Range(moveSpeedRange.x, moveSpeedRange.y);

        gameManager = GameObject.Find("Spawner");
    }

    
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.gameObject.GetComponent<BallScript>())
        {
            gameManager.GetComponent<GameManager>().AddScore();
        }
        /*if (other.collider.gameObject.GetComponent<Paddle>())
        {
            Debug.Log("Game Over in Asteroid");
            gameManager.GetComponent<GameManager>().GameOver();
        }*/
        
        Destroy(this.gameObject);
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
