using UnityEngine;
using System.Collections;

public class Create : MonoBehaviour {
    public GameObject needactive;
    public GameObject first;
    public bool reappear1;
	// Use this for initialization
	void Start () 
    {
        if(first == null)
        {
            reappear1 = true;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(first!=null)
        {
            if (first.GetComponent<Pressable>().pressed)
            {
                reappear1 = true;
            }

            else
            {
                reappear1 = false;
            }
        }

        if (reappear1)
        {
            needactive.SetActive(true);
        }

        else
        {
            needactive.transform.position =new Vector3(needactive.GetComponent<Pickupable>().x, needactive.GetComponent<Pickupable>().y, needactive.GetComponent<Pickupable>().z);
            needactive.SetActive(false);
            
            
        }
	}
}
