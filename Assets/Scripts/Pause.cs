using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
    public bool pauseGame;
    public GameObject pauseObject;
	// Use this for initialization
	void Start () 
    {
        pauseObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
    {
        pause();

        //unpause();
	}

    void pause()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (!pauseGame)
            {
                pauseGame = true;
                pauseObject.SetActive(true);
                gameObject.GetComponent<PlayerMovement>().enabled = false;
            }

            else
            {
                pauseGame = false;
                pauseObject.SetActive(false);
                gameObject.GetComponent<PlayerMovement>().enabled = true;
            }
        }
    }
}
