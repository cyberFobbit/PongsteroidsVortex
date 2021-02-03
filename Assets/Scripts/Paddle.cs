using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float smoothing = 20;
    public float sensitivity = 14;
    public float offsetFromCenter = 1;

    public float target;
    public Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        target = transform.rotation.z;
        targetPos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        target = target + Input.mouseScrollDelta.y * sensitivity;
        targetPos.x = -Mathf.Sin(transform.eulerAngles.z * 2 * Mathf.PI / 360) * offsetFromCenter;
        targetPos.y = Mathf.Cos(transform.eulerAngles.z * 2 * Mathf.PI / 360) * offsetFromCenter;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, target), smoothing * Time.deltaTime);
        transform.position = targetPos;

    }
}
