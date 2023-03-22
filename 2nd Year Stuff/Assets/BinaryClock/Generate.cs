using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Generate : MonoBehaviour
{
    public GameObject LED;
    GameObject[,] L = new GameObject[10,10 ];
    public AudioSource audioSRC;
    public AudioClip ding;
    public bool played;
    int[] T = new int[6];

    string Timers;
    private string currentTime;

    void Start()
    {
        played = false;
        
        for (int x = 0; x < 6; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                L[x,y] = Instantiate(LED, new Vector3(x, y, 0), Quaternion.identity);
            }
        }
        Timers = "13:18, 13:19, 13:20, 13:21, 13:22, 13:23, 13:24";
    }

    void FixedUpdate()
    {
        int H = System.DateTime.Now.Hour;
        if (H > 12)
        {
            //H -= 12; //to put back into 12 hour time.
        }
        int M = System.DateTime.Now.Minute;
        int S = System.DateTime.Now.Second;

        currentTime = (H + ":" + M).ToString();
        //Debug.Log(currentTime);

        if (Timers.IndexOf(currentTime, 0)!=-1 && played == false)
        {
            Debug.Log("Time");
            played = true;
            audioSRC.PlayOneShot(ding);
        }

        //Debug.Log(H + ":" + M + ":" + S);
        T[0] = H / 10;
        T[1] = H % 10;
        T[2] = M / 10;
        T[3] = M % 10;
        T[4] = S / 10;
        T[5] = S % 10;   
        
        for(int i = 0; i < 6; i++)
        {
            ChangeLights(i, T[i]);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!played)
            {
                audioSRC.PlayOneShot(ding);
            }
        }
        //Alarms
        if (H == 8 && M == 45 && S == 0)
        {
            if (!played)
            {
                audioSRC.PlayOneShot(ding);
                played = true;
            }
        }
        if (H == 11 && M == 45 && S == 0)
        {
            if (!played)
            {
                audioSRC.PlayOneShot(ding);
                played = true;
            }
        }

        if (S == 60) played = false;

    }

    private void HornSound()
    {

    }

    private void ChangeLights(int i, int v)
    {
        //L[i, 0].GetComponent<SpriteRenderer>().color = new Color(v/10.0f, v/10.0f, v/10.0f);
        //bitwise &
        for (int b = 0; b < 4; b++)
        {
            int bit = (int) Mathf.Pow(2, b);
            if((bit & v) != 0)
            {
                L[i, b].GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
            } else
            {
                L[i, b].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
            }
            
        }


    }
}
