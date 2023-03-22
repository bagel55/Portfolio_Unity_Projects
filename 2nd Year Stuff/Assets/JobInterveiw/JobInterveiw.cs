using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobInterveiw : MonoBehaviour
{
    public string Text = "Please let your students know that if there is an issue with an order the BEST practice is to email me at" +
        " landeg@mukilteo.wednet.edu with their First and Last name as well as their order ID, it can " +
        "be located underneath the date on the receipt they receive after an order is complete, and clearly state the " +
        "issue with their order so that we can work to get those orders fixed the NEXT day of service. Although we would " +
        "love for each student to have their orders fulfilled completely the day of ordering, it is just not possible with " +
        "the current amount of orders we are receiving. Please avoid sending students to the Training Grounds Window to fix " +
        "an order. Thank you so much for supporting our programs " +
        "and showing our students grace and patience through this process.";

    public List<int> LetterList = new List<int>();

    void Start()
    {
        var charLookup = sample.Where(char.IsLetterOrDigit).ToLookup(c => c); // IsLetterOrDigit to exclude the space

        foreach (var c in charLookup)
            Debug.Log("Char:{0} Count:{1}", c.Key, charLookup[c.Key].Count());
    }

    void Update()
    {

    }
}
