using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker3Move : MonoBehaviour
{
    TrailRenderer TR;
    void Start()
    {
        TR = GetComponent<TrailRenderer>();
        TR.enabled = false;
        transform.position = PEQ.Epicycloid(0);
        TR.enabled = true;
    }
    void Update()
    {
        float t = Time.time;
        transform.position = PEQ.Epicycloid(t * 12);
    }
}
