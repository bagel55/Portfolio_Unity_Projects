using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicate : MonoBehaviour
{
    SpriteRenderer sr;
    public bool Goody; 
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public void SetValue(bool collision)
    {
        if (collision)
        {
            Goody = true;
            sr.color = new Color(0, 1, 0);
        }
        else
        {
            Goody = false;
            sr.color = new Color(1, 0, 0);
        }
    }
}
