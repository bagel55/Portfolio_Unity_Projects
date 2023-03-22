using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolyGoneISGone : MonoBehaviour
{
    public SpriteRenderer sr;
public GameObject i1;
    public GameObject i2;
    public GameObject i3;
    public GameObject i4;

    private void Update()
    {
        if (i1.GetComponent<Indicate>().Goody == true || i2.GetComponent<Indicate>().Goody == true || i3.GetComponent<Indicate>().Goody == true || i4.GetComponent<Indicate>().Goody == true)
        {
            sr.color = new Color(0, 1, 0);
        } else
        {
            sr.color = new Color(1, 0, 0);
        }
    }

}
