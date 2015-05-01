using UnityEngine;
using System.Collections;
using System;

public class Create : MonoBehaviour {
    public GameObject needactive;
    public GameObject[] button;
    public bool[] reappear;
    
	// Use this for initialization
	void Start () 
    {
        reappear = new bool[button.Length];
	}
	
	// Update is called once per frame
	void Update () 
    {
        for(int i = 0; i < button.Length; i++)
        {
            if(button[i].GetComponent<Pressable>().pressed)
            {
                reappear[i] = true;
            }

            else
            {
                reappear[i] = false;
            }
        }

        if(allTrue)
        {
            needactive.SetActive(true);
        }

        else
        {
            needactive.transform.position = new Vector3(needactive.GetComponent<Pickupable>().x, needactive.GetComponent<Pickupable>().y, needactive.GetComponent<Pickupable>().z);
            needactive.SetActive(false);
        }
    }

    //method to check if all booleans are true
    bool allTrue
    {
        get
        {
            for (int i = 0; i < reappear.Length; i++)
            {
                if (!reappear[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
