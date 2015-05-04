using UnityEngine;
using System.Collections;

public class LevelTrigger : MonoBehaviour {
    public Object NextScene;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Application.LoadLevel(NextScene.name);
    }
}
