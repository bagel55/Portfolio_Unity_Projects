using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PEQ : MonoBehaviour
{
    public static Vector3 Circle(float t, float a = 2)
    {
        float x = a * Mathf.Cos(t);
        float y = a * Mathf.Sin(t);
        float z = 0f;

        return new Vector3(x, y, z);
    }

    public static Vector3 Circle3D(float t, float a = 2)
    {
        float x = a * Mathf.Cos(t);
        float y = a * Mathf.Sin(t);
        float z = a * t * Mathf.Sin(t) * Mathf.Cos(t);

        return new Vector3(x, y, z);
    }

    public static Vector3 Astroid(float t, float a = 3)
    {
        float x = a * Mathf.Pow(Mathf.Cos(t), 3);
        float y = a * Mathf.Pow(Mathf.Sin(t), 3);
        float z = 0f;

        return new Vector3(x, y, z);
    }

    public static Vector3 Epicycloid(float t, float a = 1, float b = 1)//, float c = 2)
    {
        float x = (a + b) * Mathf.Cos(t) - Mathf.Cos(b) * ((a / b + 1) * t);
        float y = (a + b) * Mathf.Sin(t) - Mathf.Sin(b) * ((a / b + 1) * t);
        //float z = (b + c) * Mathf.Tan(t) - Mathf.Tan(b) * ((b / c + 1) * t);
        float z = 0f;

        return new Vector3(x, y, z);
    }

    public static Vector3 Conchoid(float t,float a = 3)
    {
        float x = a + Mathf.Cos(t);
        float y = a * Mathf.Tan(t) + Mathf.Sin(t);
        float z = 0f;

        return new Vector3(x, y, z);
    }

    // Polar Equations

    private static Vector3 ToPolar(float r, float thea)
    {
        return new Vector3(r * Mathf.Cos(thea), r * Mathf.Sin(thea), r * 3);
    }

    public static Vector3 Freeth(float th, float a = 2)
    {
        float r = a * (1 + 2 * Mathf.Sin(th / 2));
        return ToPolar(r, th);

    }

    public static Vector3 Rhodonea(float th, float a = 3, float k = 9)
    {
        float r = a * Mathf.Sin(k * th);
        return ToPolar(r, th);
    }

    public static Vector3 Strophoid(float th, float a = 1)
    {
        float r = a * Mathf.Cos(2 * th) / Mathf.Cos(th);
        return ToPolar(r, th);
    }

    public static Vector3 SpiralOfArch(float th, float a = 0.001f)
    {
        float r = a * th;
        return ToPolar(r, th);
    }
}
