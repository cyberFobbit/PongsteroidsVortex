using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float smoothing;
    public float sensitivity;

    public float target;
    // Start is called before the first frame update
    void Start()
    {
        target = transform.rotation.z;
    }

    // Update is called once per frame
    void Update()
    {
        target = target + Input.mouseScrollDelta.y * sensitivity;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, target), smoothing * Time.deltaTime);

    }
}
