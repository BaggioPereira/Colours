using UnityEngine;
using System.Collections;

public class SwapScene : MonoBehaviour {
    Material red, blue, magentatoon, magenta, greentoon, green, whitetoon, white, yellowtoon, yellow;
    GameObject[] objects;
    GameObject[] others;
    [HideInInspector]
    public bool redBool = false, blueBool = true;

	// Use this for initialization
	void Start () 
    {
        //Set colours
        red = (Material) Resources.Load("Materials/Red");
        blue = (Material) Resources.Load("Materials/BlueToonLitOutline");
        magentatoon = (Material)Resources.Load("Materials/MagentaToonLitOutline");
        magenta = (Material)Resources.Load("Materials/Magenta");
        greentoon = (Material)Resources.Load("Materials/GreenToonLitOutline");
        green = (Material)Resources.Load("Materials/Green");
        whitetoon = (Material)Resources.Load("Materials/WhiteToonLitOutline");
        white = (Material)Resources.Load("Materials/White");
        yellowtoon = (Material)Resources.Load("Materials/YellowToonLitOutline");
        yellow = (Material)Resources.Load("Materials/Yellow");

        //Get number of platforms/objects that are affects by scenes
        objects = GameObject.FindGameObjectsWithTag("World");
        others = GameObject.FindGameObjectsWithTag("Others");

        //Set initial active for all "objects" depending on color that is active
        for(int i = 0; i<objects.Length;i++)
        {
            if(objects[i].GetComponent<Associate>().associated)
            {
                if (objects[i].GetComponent<Renderer>().material.shader == blue.shader)
                    objects[i].SetActive(true);

                else if (objects[i].GetComponent<Renderer>().material.shader == red.shader)
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
                        if (objects[i].GetComponent<Renderer>().material.shader == red.shader)
                            objects[i].SetActive(true);

                        else if (objects[i].GetComponent<Renderer>().material.shader == blue.shader)
                            objects[i].SetActive(false);
                    } 
                }

                for(int i = 0; i<others.Length; i++)
                {
                    if (others[i].GetComponent<Renderer>().material.shader.name == magentatoon.shader.name)
                        others[i].GetComponent<Renderer>().material = magenta;

                    else if (others[i].GetComponent<Renderer>().material.shader.name == greentoon.shader.name)
                        others[i].GetComponent<Renderer>().material = green;

                    else if (others[i].GetComponent<Renderer>().material.shader.name == whitetoon.shader.name)
                        others[i].GetComponent<Renderer>().material = white;

                    else if (others[i].GetComponent<Renderer>().material.shader.name == yellowtoon.shader.name)
                        others[i].GetComponent<Renderer>().material = yellow;
                }
            }
            
            //blue blocks are visible and red are invisible
            else if(blueBool)
            {
                for (int i = 0; i < objects.Length; i++)
                {
                    if(objects[i].GetComponent<Associate>().associated)
                    {
                        if (objects[i].GetComponent<Renderer>().material.shader == blue.shader)
                            objects[i].SetActive(true);

                        else if (objects[i].GetComponent<Renderer>().material.shader == red.shader)
                            objects[i].SetActive(false);
                    }         
                }

                for (int i = 0; i < others.Length; i++)
                {
                    if (others[i].GetComponent<Renderer>().material.shader.name == magenta.shader.name)
                        others[i].GetComponent<Renderer>().material = magentatoon;

                    else if (others[i].GetComponent<Renderer>().material.shader.name == green.shader.name)
                        others[i].GetComponent<Renderer>().material = greentoon;

                    else if (others[i].GetComponent<Renderer>().material.shader.name == white.shader.name)
                        others[i].GetComponent<Renderer>().material = whitetoon;

                    else if (others[i].GetComponent<Renderer>().material.shader.name == yellow.shader.name)
                        others[i].GetComponent<Renderer>().material = yellowtoon;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
