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
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
        levelComplete.SetActive(true);
    }
}
