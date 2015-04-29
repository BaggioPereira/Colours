using UnityEngine;
using System.Collections;

public class Create : MonoBehaviour {
    public GameObject first, needactive;
    public bool reappear;
	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (first.GetComponent<ButtonPress>().pressed)
        {
            reappear = true;
        }

        else
        {
            reappear = false;
        }

        if (reappear)
        {
            needactive.SetActive(true);
        }

        else
        {
            needactive.SetActive(false);
        }
	}
}
