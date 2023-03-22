using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Collision2
{
    private static float distance(float x1, float y1, float x2, float y2)
    {
        float dX = x1 - x2;
        float dY = y1 - y2;
        float d = Mathf.Sqrt(dX * dX + dY * dY);
        return d;
    }
    // POLYGON/CIRCLE
    public static bool polyCircle(Vector3[] vertices, float cx, float cy, float r)
    {

        // go through each of the vertices, plus
        // the next vertex in the list
        int next = 0;
        for (int current = 0; current < vertices.Length; current++)
        {

            // get next vertex in list
            // if we've hit the end, wrap around to 0
            next = current + 1;
            if (next == vertices.Length) next = 0;

            // get the PVectors at our current position
            // this makes our if statement a little cleaner
            Vector3 vc = vertices[current];    // c for "current"
            Vector3 vn = vertices[next];       // n for "next"

            // check for collision between the circle and
            // a line formed between the two vertices
            bool collision = lineCircle(vc.x, vc.y, vn.x, vn.y, cx, cy, r);
            if (collision) return true;
        }

        // the above algorithm only checks if the circle
        // is touching the edges of the polygon – in most
        // cases this is enough, but you can un-comment the
        // following code to also test if the center of the
        // circle is inside the polygon

        // boolean centerInside = polygonPoint(vertices, cx,cy);
        // if (centerInside) return true;

        // otherwise, after all that, return false
        return false;
    }
    // LINE/CIRCLE
    public static bool lineCircle(float x1, float y1, float x2, float y2, float cx, float cy, float r)
    {
        // is either end INSIDE the circle?
        // if so, return true immediately
        bool inside1 = pointCircle(x1, y1, cx, cy, r);
        bool inside2 = pointCircle(x2, y2, cx, cy, r);
        if (inside1 || inside2) return true;

        // get length of the line
        float distX = x1 - x2;
        float distY = y1 - y2;
        float len = Mathf.Sqrt((distX * distX) + (distY * distY));

        // get dot product of the line and circle
        float dot = (((cx - x1) * (x2 - x1)) + ((cy - y1) * (y2 - y1))) / Mathf.Pow(len, 2);

        // find the closest point on the line
        float closestX = x1 + (dot * (x2 - x1));
        float closestY = y1 + (dot * (y2 - y1));

        // is this point actually on the line segment?
        // if so keep going, but if not, return false
        bool onSegment = linePoint(x1, y1, x2, y2, closestX, closestY);
        if (!onSegment) return false;

        // get distance to closest point
        distX = closestX - cx;
        distY = closestY - cy;
        float distance = Mathf.Sqrt((distX * distX) + (distY * distY));

        // is the circle on the line?
        if (distance <= r)
        {
            return true;
        }
        return false;
    }
    // LINE/POINT
    public static bool linePoint(float x1, float y1, float x2, float y2, float px, float py)
    {

        // get distance from the point to the two ends of the line
        float d1 = distance(px, py, x1, y1);
        float d2 = distance(px, py, x2, y2);

        // get the length of the line
        float lineLen = distance(x1, y1, x2, y2);

        // since floats are so minutely accurate, add
        // a little buffer zone that will give collision
        float buffer = 0.1f;    // higher # = less accurate

        // if the two distances are equal to the line's
        // length, the point is on the line!
        // note we use the buffer here to give a range, rather
        // than one #
        if (d1 + d2 >= lineLen - buffer && d1 + d2 <= lineLen + buffer)
        {
            return true;
        }
        return false;
    }



    // POINT/CIRCLE
    public static bool pointCircle(float px, float py, float cx, float cy, float r)
    {

        // get distance between the point and circle's center
        // using the Pythagorean Theorem
        float distX = px - cx;
        float distY = py - cy;
        float distance = Mathf.Sqrt((distX * distX) + (distY * distY));

        // if the distance is less than the circle's 
        // radius the point is inside!
        if (distance <= r)
        {
            return true;
        }
        return false;
    }


    // POLYGON/POINT
    // only needed if you're going to check if the circle
    // is INSIDE the polygon
    public static bool polygonPoint(Vector3[] vertices, float px, float py)
    {
        bool collision = false;

        // go through each of the vertices, plus the next
        // vertex in the list
        int next = 0;
        for (int current = 0; current < vertices.Length; current++)
        {

            // get next vertex in list
            // if we've hit the end, wrap around to 0
            next = current + 1;
            if (next == vertices.Length) next = 0;

            // get the PVectors at our current position
            // this makes our if statement a little cleaner
            Vector3 vc = vertices[current];    // c for "current"
            Vector3 vn = vertices[next];       // n for "next"

            // compare position, flip 'collision' variable
            // back and forth
            if (((vc.y > py && vn.y < py) || (vc.y < py && vn.y > py)) &&
                 (px < (vn.x - vc.x) * (py - vc.y) / (vn.y - vc.y) + vc.x))
            {
                collision = !collision;
            }
        }
        return collision;
    }
}
