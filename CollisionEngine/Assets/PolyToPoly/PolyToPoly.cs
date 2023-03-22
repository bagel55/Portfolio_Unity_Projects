using System;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class PolyToPoly : MonoBehaviour
{
    public Vector2[] OBJ1Verticies;
    public Vector2[] OBJ2Verticies;

    public GameObject OBJ1;
    public GameObject OBJ2;
    public GameObject I;

    private void Start()
    {
        //pentagon = new Vector2[5];
        //randomPoly = new Vector2[8];

        float angle = 360f / OBJ1Verticies.Length;
        for (int c = 0; c < OBJ1Verticies.Length; c++)
        {
            float z = angle * c;
            float x = 300 + Mathf.Cos(z * Mathf.Deg2Rad) * 100;
            float y = 200 + Mathf.Sin(z * Mathf.Deg2Rad) * 100;
            OBJ1Verticies[c] = new Vector2(x, y);
        }

        float a = 0;
        int i = 0;
        while (a < 360)
        {
            float x = Mathf.Cos(a * Mathf.Deg2Rad) * UnityEngine.Random.Range(30, 50);
            float y = Mathf.Sin(a * Mathf.Deg2Rad) * UnityEngine.Random.Range(30, 50);
            OBJ2Verticies[i] = new Vector2(x, y);
            a += UnityEngine.Random.Range(15, 40);
            i += 1;
        }
    }

    private void Update()
    {
        OBJ1Verticies = OBJ1.GetComponent<SpriteRenderer>().sprite.vertices;
        OBJ2Verticies = OBJ2.GetComponent<SpriteRenderer>().sprite.vertices;

        Vector2 mouse = Input.mousePosition;
        Vector2 diff = mouse - OBJ2Verticies[0];
        for (int i = 0; i < OBJ2Verticies.Length; i++)
        {
            OBJ2Verticies[i] += diff;
        }

        bool hit = PolyPoly(OBJ1Verticies, OBJ2Verticies);
        if (hit)
        {
            Debug.Log("Hit");
        }
        else
        {
            Debug.Log("Not Hit");
        }
    }

    private bool PolyPoly(Vector2[] p1, Vector2[] p2)
    {
        int next = 0;
        for (int current = 0; current < p1.Length; current++)
        {
            next = current + 1;
            if (next == p1.Length)
            {
                next = 0;
            }

            Vector2 vc = p1[current];
            Vector2 vn = p1[next];

            bool collision = PolyLine(p2, vc.x, vc.y, vn.x, vn.y);
            if (collision)
            {
                return true;
            }

            collision = PolyPoint(p1, p2[0].x, p2[0].y);
            if (collision)
            {
                return true;
            }
        }

        return false;
    }

    public static bool PolyLine(Vector2[] vertices, float x1, float y1, float x2, float y2)
    {
        int next = 0;
        for (int current = 0; current < vertices.Length; current++)
        {
            next = current + 1;
            if (next == vertices.Length)
                next = 0;

            float x3 = vertices[current].x;
            float y3 = vertices[current].y;
            float x4 = vertices[next].x;
            float y4 = vertices[next].y;

            if (LineLine(x1, y1, x2, y2, x3, y3, x4, y4))
                return true;
        }
        return false;
    }

    // LINE/LINE
    public static bool LineLine(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
    {
        float uA = ((x4 - x3) * (y1 - y3) - (y4 - y3) * (x1 - x3)) / ((y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1));
        float uB = ((x2 - x1) * (y1 - y3) - (y2 - y1) * (x1 - x3)) / ((y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1));

        if (uA >= 0 && uA <= 1 && uB >= 0 && uB <= 1)
            return true;
        return false;
    }

    // POLYGON/POINT
    public static bool PolyPoint(Vector2[] vertices, float px, float py)
    {
        bool collision = false;

        int next = 0;
        for (int current = 0; current < vertices.Length; current++)
        {
            next = current + 1;
            if (next == vertices.Length)
                next = 0;

            Vector2 vc = vertices[current];
            Vector2 vn = vertices[next];

            if (((vc.y > py && vn.y < py) || (vc.y < py && vn.y > py)) &&
                (px < (vn.x - vc.x) * (py - vc.y) / (vn.y - vc.y) + vc.x))
            {
                collision = !collision;
            }
        }
        return collision;
    }
}