using UnityEngine;
using System.Collections;

public class ButtonPress : MonoBehaviour {
    Animation anim;
    public bool pressed;
    public int distance;
	// Use this for initialization
	void Start () 
    {
        anim = gameObject.GetComponent<Animation>();
        pressed = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, distance))
            {
                if(gameObject!=null)
                {
                    if(!pressed)
                    {
                        if (!anim.IsPlaying("Unpressed"))
                        {
                            anim.Play("Pressed");
                            new WaitForSeconds(anim["Pressed"].length);
                            pressed = true;
                        }   
                    }

                    else
                    {
                        if (!anim.IsPlaying("Pressed"))
                        {   
                            anim.Play("Unpressed");
                            new WaitForSeconds(anim["Unpressed"].length);
                            pressed = false;
                        }
                    }
                }
            }
        }       
	}
}
