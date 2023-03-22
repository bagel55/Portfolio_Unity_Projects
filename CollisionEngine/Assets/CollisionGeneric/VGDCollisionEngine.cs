using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VGDCollisionEngine
{
    public static bool PointPoint(float ax, float ay, float bx, float by)
    {
        if (ax == bx && ay == by)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool PointPointBuffer(float ax, float ay, float bx, float by, float buffer)
    {
        float diffX = ax - bx;
        float diffY = ay - by;
        if (Mathf.Abs(diffX) < buffer && Mathf.Abs(diffY) < buffer)
        {
            return true;
        }
        return false;
    }

    public static bool CircleBox(float cx, float cy, float cr, float boxTop, float boxBottom, float boxLeft, float boxRight)
    {
        float testX = cx;
        float testY = cy;

        if (cx < boxLeft) testX = boxLeft;
        else if (cx > boxBottom) testX = boxRight;
        float distX = cx - testX;

        if (cy > boxTop) testY = boxTop;
        else if (cy < boxBottom) testY = boxBottom;
        float distY = cy - testY;

        float distance = Mathf.Sqrt(distX * distX + distY * distY);
        if (distance <= cr)
        {
            return true;
        }
        return false;
    }

    public static bool CircleCircle(float ax, float ay, float ar, float bx, float by, float br)
    {
        float dX = ax - bx;
        float dY = ay - by;
        float dist = Mathf.Sqrt(dX * dX + dY * dY);
        if (dist <= (ar + br)) return true;

        return false;
    }

    public static bool PointSegment(float px, float py, float e1x, float e1y, float e2x, float e2y, float buffer)
    {
        float lineLength = distance(e1x, e1y, e2x, e2y);
        float d1 = distance(px, py, e1x, e1y);
        float d2 = distance(px, py, e2x, e2y);
        if (d1 + d2 >= lineLength - buffer && d1+d2 <= lineLength + buffer) return true;


        return false;
    }

    private static float distance(float x1, float y1, float x2, float y2)
    {
        float dX = x1 - x2;
        float dY = y1 - y2;
        float d = Mathf.Sqrt(dX * dX + dY * dY);
        return d;
    }
}