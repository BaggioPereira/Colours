using UnityEngine;
using System.Collections;

public class Create : MonoBehaviour {
    SwapScene scene;
    public GameObject[] needactive;
    public GameObject[] button;
    public bool[] reappear;
    
	// Use this for initialization
	void Start () 
    {
        scene = GetComponent<SwapScene>();
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

        //if all buttons are pressed, make objects visible
        //also checks if item is a platform or not
        if(allTrue)
        {
            for (int i = 0; i < needactive.Length; i++)
            {
                if (needactive[i].CompareTag("World"))
                {
                    if (scene.blueBool == true)
                    {
                        if(needactive[i].GetComponent<Renderer>().material.color == Color.blue)
                            needactive[i].SetActive(true);
                    }

                    else if(scene.redBool == true)
                    {
                        if (needactive[i].GetComponent<Renderer>().material.color == Color.red)
                            needactive[i].SetActive(true);
                    }
                }

                else
                {
                    needactive[i].SetActive(true);
                }
            }    
        }

        //if not all buttons are pressed, make objects invisible
        //also checks if item is a platform or not
        else
        {
            for (int i = 0; i < needactive.Length; i++)
            {
                if (needactive[i].GetComponent<Pickupable>())
                {
                    needactive[i].transform.position = new Vector3(needactive[i].GetComponent<Pickupable>().x, needactive[i].GetComponent<Pickupable>().y, needactive[i].GetComponent<Pickupable>().z);
                    needactive[i].SetActive(false);
                }

                else if (needactive[i].CompareTag("World"))
                {
                    if (scene.blueBool == true || scene.blueBool == false)
                    {
                        needactive[i].SetActive(false);
                    }
                }
            } 
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
