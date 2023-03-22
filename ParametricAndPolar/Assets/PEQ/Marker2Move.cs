﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker2Move : MonoBehaviour
{
    TrailRenderer TR;
    void Start()
    {
        TR = GetComponent<TrailRenderer>();
        TR.enabled = false;
        transform.position = PEQ.Astroid(0);
        TR.enabled = true;
    }
    void Update()
    {
        float t = Time.time;
        transform.position = PEQ.Astroid(t);
    }
}
