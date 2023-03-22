using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public GameObject Bol;
    public int score;
    public GameObject WINtxt;
    public TMP_Text ScoreT;

    public GameObject P1;
    public GameObject P2;
    void Start()
    {
        Bol = GameObject.Find("Bol");
    }

    private void Update()
    {
        ScoreT.SetText(score.ToString());
        if (score >= 11)
        {
            WINtxt.SetActive(true);
            Bol.SetActive(false);
            P1.SetActive(false);
            P2.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score++;
    }
}
