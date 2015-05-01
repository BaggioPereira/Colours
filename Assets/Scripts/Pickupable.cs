using UnityEngine;
using System.Collections;

public class Pickupable : MonoBehaviour {
    public float x, y, z;
	// Use this for initialization
	void Start () {
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
        z = gameObject.transform.position.z;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
