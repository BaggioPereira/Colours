using UnityEngine;
using System.Collections;

public class LevelTrigger : MonoBehaviour {
    public GameObject levelComplete;
	// Use this for initialization
	void Start () 
    {
        levelComplete.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        levelComplete.SetActive(true);
    }
}
