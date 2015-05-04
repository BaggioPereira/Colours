using UnityEngine;
using System.Collections;

public class LevelTrigger : MonoBehaviour {
    public string NextLevel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Application.LoadLevel(NextLevel);
    }
}
