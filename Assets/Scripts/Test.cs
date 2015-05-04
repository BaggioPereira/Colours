using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
    SwapScene scene;
    public TwoDimensionalArray[] Array;
	// Use this for initialization
	void Start () 
    {
        for (int i = 0; i < Array.Length; i++ )
        {
            Array[i].active = new bool[Array[i].switches.Length];
            scene = GetComponent<SwapScene>();
        }        
	}
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < Array.Length; i++)
        {
            for(int j = 0 ; j < Array[i].switches.Length; j++)
            {
                if(Array[i].switches[j].GetComponent<Pressable>().pressed)
                {
                    Array[i].active[j] = true;
                }

                else
                {
                    Array[i].active[j] = false;
                }
            }
        }

        for (int i = 0; i < Array.Length; i++)
        {
            if (allTrue(i))
            {
                for (int j = 0; j < Array[i].objects.Length; j++)
                {
                    if(Array[i].objects[j].CompareTag("World"))
                    {
                        if(scene.blueBool == true)
                        {
                            if(Array[i].objects[j].GetComponent<Renderer>().material.color == Color.blue)
                            {
                                Array[i].objects[j].GetComponent<Associate>().associated = true;
                                Array[i].objects[j].SetActive(true);
                            }
                        }

                        else if (scene.redBool == true)
                        {
                            if (Array[i].objects[j].GetComponent<Renderer>().material.color == Color.red)
                            {
                                Array[i].objects[j].GetComponent<Associate>().associated = true;
                                Array[i].objects[j].SetActive(true);
                            }
                        }

                        else
                        {
                            Array[i].objects[j].SetActive(true);
                        }
                    }
                } 
            }

            else
            {
                for (int j = 0; j < Array[i].objects.Length; j++)
                {
                    if(Array[i].objects[j].GetComponent<Pickupable>())
                    {
                        Array[i].objects[j].transform.position = new Vector3(Array[i].objects[j].GetComponent<Pickupable>().x, Array[i].objects[j].GetComponent<Pickupable>().y, Array[i].objects[j].GetComponent<Pickupable>().z);
                        Array[i].objects[j].SetActive(false);
                    }

                    else if(Array[i].objects[j].CompareTag("World"))
                    {
                        if(scene.blueBool == true || scene.blueBool == false)
                        {
                            Array[i].objects[j].GetComponent<Associate>().associated = false;
                            Array[i].objects[j].SetActive(false);
                        }
                    }
                }
            }
        }
	}

    bool allTrue(int i)
    {
        for(int j = 0; j< Array[i].switches.Length; j++)
        {
            if(!Array[i].active[j])
            {
                return false;
            }
        }
        return true;
    }   
}
