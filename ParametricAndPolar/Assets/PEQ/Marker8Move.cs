using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker8Move : MonoBehaviour
{
    TrailRenderer TR;
    public float stTime;
    void Start()
    {
        TR = GetComponent<TrailRenderer>();
        TR.enabled = false;
        transform.position = PEQ.SpiralOfArch(0);
        TR.enabled = true;
    }
    private void Awake()
    {
        stTime = Time.time;
    }
    void Update()
    {
        float t = stTime;
        stTime++;
        transform.position = PEQ.SpiralOfArch(t * 20);
        Destroy(gameObject, 5);
    }
}
