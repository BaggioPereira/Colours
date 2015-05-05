using UnityEngine;
using System.Collections;

public class PressurePad : MonoBehaviour {
    public GameObject[] objects;
    Animation anim;
    public bool padIsLoaded;
	// Use this for initialization
	void Start () {
        padIsLoaded = false;
        anim = gameObject.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        checkLoaded();
	}

    void OnCollisionEnter(Collision collision)
    {
            if (padIsLoaded == false)
            {
                if (!anim.IsPlaying("Unpressed"))
                {
                anim.Play("Pressed");
                new WaitForSeconds(anim["Pressed"].length);
                padIsLoaded = true;
                }
            }
    }

    void OnCollisionExit(Collision collision)
    {
            if (padIsLoaded == true)
            {
                if (!anim.IsPlaying("Pressed"))
                {
                anim.Play("Unpressed");
                new WaitForSeconds(anim["Unpressed"].length);
                padIsLoaded = false;
                }
            }        
    }

    void checkLoaded()
    {
        if(padIsLoaded)
        {
            for (int i = 0; i < objects.Length; i++)
                objects[i].SetActive(true);
        }

        else
        {
            for (int i = 0; i < objects.Length; i++)
                objects[i].SetActive(false);
        }
    }
}
