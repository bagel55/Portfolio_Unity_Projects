using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instance8 : MonoBehaviour
{
    public GameObject Mrk8;
    private float Timer;
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            Mrk8 = Instantiate(Mrk8, new Vector3(0, 0, 0), transform.rotation);
            Timer = 0.3f;
        }
    }
}
