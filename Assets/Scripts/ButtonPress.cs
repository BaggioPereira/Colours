using UnityEngine;
using System.Collections;

public class ButtonPress : MonoBehaviour {
    Animation anim;
    public bool pressed;
    public float distance = 3.0f;
	// Use this for initialization
	void Start () 
    {
        pressed = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        checkUnpress();

        press();
	}

    void press()
    {
        //if within range and pressed key, activate button
        if (Input.GetKeyDown(KeyCode.P))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, distance))
            {
                Pressable p = hit.collider.GetComponent<Pressable>();
                if (p != null)
                {
                    anim = p.GetComponent<Animation>();
                    if (!p.pressed)
                    {
                        if (!anim.IsPlaying("Unpressed"))
                        {
                            anim.Play("Pressed");
                            new WaitForSeconds(anim["Pressed"].length);
                            p.pressed = true;
                        }
                    }
                }
            }
        }
    }

    void checkUnpress()
    {
        //if within range and pressed key, deactivate button
        if(Input.GetKeyDown(KeyCode.P))
        {
            unpressObject();
        }
    }

    void unpressObject()
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distance))
        {
            Pressable p = hit.collider.GetComponent<Pressable>();
            if (p != null)
            {
                anim = p.GetComponent<Animation>();
                if (p.pressed)
                {
                    if (!anim.IsPlaying("Pressed"))
                    {
                        anim.Play("Unpressed");
                        new WaitForSeconds(anim["Unpressed"].length);
                        p.pressed = false;
                    }
                }
            }
        }
    }
}
