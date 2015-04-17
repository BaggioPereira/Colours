using UnityEngine;
using System.Collections;

public class Swap : MonoBehaviour {
    Material red, green, blue;
    GameObject plane;
    Renderer rend;

	// Use this for initialization
	void Start () {
        plane = GameObject.Find("Plane");
        red = (Material) Resources.Load("ShadersMaterials/Red");
        green = (Material) Resources.Load("ShadersMaterials/Green");
        blue = (Material) Resources.Load("ShadersMaterials/Blue");
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            rend.material = blue;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rend.material = green;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rend.material = red;
        }
	}
}
