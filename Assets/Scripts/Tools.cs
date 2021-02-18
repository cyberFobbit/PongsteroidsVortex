using System.Collections;
using UnityEngine;

public class Tools : MonoBehaviour
{
    public static Tools instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying...");
            Destroy(this);
        }
    }

    public void Tween(object parentComponent, string variableName, object to, float time, bool Vector3 = false)
    {
        if (Vector3) StartCoroutine(TweenVector3(parentComponent, variableName, (Vector3)to, time));
        else StartCoroutine(TweenValue(parentComponent, variableName, (float)to, time));
    }

    private IEnumerator TweenVector3(object target, string variableName, Vector3 to, float time)
    {
        Vector3 difference = to - (Vector3)GetValue(target, variableName);
        Vector3 stepSize = difference / (time / 0.01f);
        
        for (float i = 0; i < difference.magnitude; i += stepSize.magnitude)
        {
            SetProperty(target, variableName, (Vector3)GetProperty(target, variableName) + stepSize);
            yield return new WaitForSeconds(0.01f);
        }
        SetProperty(target, variableName, to);
    }

    private IEnumerator TweenValue(object target, string variableName, float to, float time)
    {
        float difference = to - (float)GetValue(target, variableName);
        float stepSize = difference / (time / 0.01f);
        for (float i = 0; i < Mathf.Abs(difference); i += Mathf.Abs(stepSize))
        {
            AddValue(target, variableName, stepSize);
            yield return new WaitForSeconds(0.01f);
        }
        SetValue(target, variableName, to);
    }

    public static void SetProperty(object target, string variableName, object value)
    {
        System.Type type = target.GetType();
        type.GetProperty(variableName).SetValue(target, value);
    }

    public static void SetValue(object target, string variableName, object value)
    {
        System.Type type = target.GetType();
        type.GetField(variableName).SetValue(target, value);
    }

    public static object GetValue(object target, string variableName)
    {
        try
        {
            System.Type type = target.GetType();
            return type.GetField(variableName).GetValue(target);
        }
        catch
        {
            try
            {
                System.Type type = target.GetType();
                return type.GetProperty(variableName).GetValue(target);
            }
            catch
            {
                return null;
            }
        }
    }

    public static object GetProperty(object target, string variableName)
    {
        try
        {
            System.Type type = target.GetType();
            return type.GetProperty(variableName).GetValue(target);
        }
        catch
        {
            try
            {
                System.Type type = target.GetType();
                return type.GetField(variableName).GetValue(target);
            }
            catch
            {
                return null;
            }
        }
    }

    public static void AddValue(object target, string variableName, float value)
    {
        System.Type type = target.GetType();
        print(type.Name);
        print(type.GetField(variableName).GetType().Name);
        type.GetField(variableName).SetValue(target, (float)GetValue(target, variableName) + value);

    }
}
