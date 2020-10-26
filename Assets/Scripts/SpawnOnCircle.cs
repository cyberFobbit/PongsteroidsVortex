using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

public class SpawnOnCircle : MonoBehaviour
{
    public GameObject prefab;
    public bool onlyOnRadius;
    public float radius;
    public float interval;
    public float test;

    float t = 0;

    

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if(t >= interval)
        {
            if (onlyOnRadius)
            {
                float angle = Random.value * Mathf.PI * 2;
                
                Instantiate(prefab, transform.position + (transform.up * Mathf.Sin(angle) + transform.right * Mathf.Cos(angle)) * radius, Quaternion.identity);
            }
            else
            {
                float angle = Random.value * Mathf.PI * 2;
                Instantiate(prefab, transform.position + (transform.up * Mathf.Sin(angle) + transform.right * Mathf.Cos(angle)) * (radius * Random.value), Quaternion.identity);
            }
            t = 0;
        }
    }

    private void OnDrawGizmos()
    {
        //if (!Selection.Contains(this)) return;
        Handles.color = Color.blue;
        Handles.DrawWireDisc(transform.position, transform.forward, radius);

        Handles.color = new Color(1, 1, 1, 0.05f);
        if (!onlyOnRadius)
            Handles.DrawSolidDisc(transform.position, transform.forward, radius - (radius *0.01f));
    }
}
