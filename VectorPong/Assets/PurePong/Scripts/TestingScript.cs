using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    private Prect p;
    private Color c;
    void Start()
    {
        p = new Prect("PrimRect", 40, 40, 100, 100, false, "simple");
        c = new Color(1, 0.5f, 0);
    }
    void Update()
    {

    }
    private void OnGUI()
    {
        Manager.GUIDrawRect(p.rect, c);
    }
}
