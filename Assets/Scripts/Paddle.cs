using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : MonoBehaviour
{
    public float sensitivity = 14;
    public float maxOffsetFromCenter = 1;
    public float minOffsetFromCenter = 0.3f;

    Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float mouseDist = Mathf.Clamp(Vector3.Distance((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero), minOffsetFromCenter, maxOffsetFromCenter);
        print(Vector3.Distance((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero));
        targetPos.x = -Mathf.Sin(transform.eulerAngles.z * 2 * Mathf.PI / 360) * mouseDist;
        targetPos.y = Mathf.Cos(transform.eulerAngles.z * 2 * Mathf.PI / 360) * mouseDist;
        
        GetComponent<Rigidbody2D>().velocity = (targetPos - transform.position) * sensitivity;

        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(Vector3.zero);
        float angle = -Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
