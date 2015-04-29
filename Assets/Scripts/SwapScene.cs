using UnityEngine;
using UnityEditor;
using System.Collections;

public class SwapScene : MonoBehaviour {
    Material red, green, blue, cyan, yellow, magenta, white;
    GameObject plane, sphere, cube, cylinder;
    bool redBool = false, greenBool = false, blueBool = false;

	// Use this for initialization
	void Start () 
    {
        plane = GameObject.Find("Plane");
        sphere = GameObject.Find("Sphere");
        cube = GameObject.Find("Cube");
        cylinder = GameObject.Find("Cylinder");
        red = (Material) Resources.Load("ShadersMaterials/Red");
        green = (Material) Resources.Load("ShadersMaterials/Green");
        blue = (Material) Resources.Load("ShadersMaterials/Blue");
        magenta = (Material)Resources.Load("ShadersMaterials/Magenta");
        cyan = (Material)Resources.Load("ShadersMaterials/Cyan");
        yellow = (Material)Resources.Load("ShadersMaterials/Yellow");
        white = (Material)Resources.Load("ShadersMaterials/White");
        if(!redBool && !greenBool && !blueBool)
        {
            sphere.SetActive(false);
            cube.SetActive(false);
            cylinder.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            sphere.SetActive(false);
            cylinder.SetActive(false);
            cube.SetActive(true);
            plane.GetComponent<Renderer>().material = blue;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            cube.SetActive(false);
            cylinder.SetActive(false);
            sphere.SetActive(true);
            plane.GetComponent<Renderer>().material = green;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            sphere.SetActive(false);
            cube.SetActive(false);
            cylinder.SetActive(true);
            plane.GetComponent<Renderer>().material = red;          
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            cube.SetActive(false);
            sphere.SetActive(true);
            cylinder.SetActive(true);
            plane.GetComponent<Renderer>().material = yellow;         
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            cube.SetActive(true);
            sphere.SetActive(false);
            cylinder.SetActive(true);
            plane.GetComponent<Renderer>().material = magenta;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            cube.SetActive(true);
            sphere.SetActive(true);
            cylinder.SetActive(false);
            plane.GetComponent<Renderer>().material = cyan;
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    cube.SetActive(false);
        //    sphere.SetActive(false);
        //    cylinder.SetActive(false);
        //    plane.GetComponent<Renderer>().material = white;
        //}
	}
}
