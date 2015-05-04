using UnityEngine;
using System.Collections;

public class SwapScene : MonoBehaviour {
    Material red, blue;
    GameObject[] objects;
    [HideInInspector]
    public bool redBool = false, blueBool = true;

	// Use this for initialization
	void Start () 
    {
        //Set colours
        red = (Material) Resources.Load("ShadersMaterials/Red");
        blue = (Material) Resources.Load("ShadersMaterials/Blue");

        //Get number of platforms/objects that are affects by scenes
        objects = GameObject.FindGameObjectsWithTag("World");

        //Set initial active for all "objects" depending on color that is active
        for(int i = 0; i<objects.Length;i++)
        {
            if(objects[i].GetComponent<Associate>().associated)
            {
                if (objects[i].GetComponent<Renderer>().material.color == blue.color)
                    objects[i].SetActive(true);

                else if (objects[i].GetComponent<Renderer>().material.color == red.color)
                    objects[i].SetActive(false);
            }      
            else if(!objects[i].GetComponent<Associate>().associated)
            {
                objects[i].SetActive(false);
            }
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        //wait for key input
        if(Input.GetKeyDown(KeyCode.Q))
        {
            //Swap scenes around
            redBool = !redBool;
            blueBool = !blueBool;
            //red blocks are visible and blue are invisible
            if(redBool)
            {
                
                for (int i = 0; i < objects.Length; i++)
                {
                    if(objects[i].GetComponent<Associate>().associated)
                    {
                        if (objects[i].GetComponent<Renderer>().material.color == red.color)
                            objects[i].SetActive(true);

                        else if (objects[i].GetComponent<Renderer>().material.color == blue.color)
                            objects[i].SetActive(false);
                    } 
                }
            }
            
            //blue blocks are visible and red are invisible
            else if(blueBool)
            {
                for (int i = 0; i < objects.Length; i++)
                {
                    if(objects[i].GetComponent<Associate>().associated)
                    {
                        if (objects[i].GetComponent<Renderer>().material.color == blue.color)
                            objects[i].SetActive(true);

                        else if (objects[i].GetComponent<Renderer>().material.color == red.color)
                            objects[i].SetActive(false);
                    }         
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
