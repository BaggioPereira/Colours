using UnityEngine;
using System.Collections;
using System.Linq;

public class ReverseNormals : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Mesh mesh = gameObject.GetComponent<MeshFilter>().mesh;
        mesh.triangles = mesh.triangles.Reverse().ToArray();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
