using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {
    GameObject carriedObject;
    bool carrying;
    public float distance = 3.0f;
	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
        //check if object is picked up or not
        if(carrying)
        {
            carry(carriedObject);
            checkDrop();
        }

        else
        {
            pickUp();
        }
	}

    //carry the block smoothly
    void carry(GameObject o)
    {
        o.transform.position = Vector3.Lerp(o.transform.position, Camera.main.transform.position + Camera.main.transform.forward * distance, Time.deltaTime * distance);
        o.transform.rotation = Quaternion.identity;
    }

    //pickup the block if within range
    void pickUp()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 3))
            {
                Pickupable p = hit.collider.GetComponent<Pickupable>();
                if(p!=null)
                {
                    carrying = true;
                    carriedObject = p.gameObject;
                    p.gameObject.GetComponent<Rigidbody>().useGravity = false;
                }
            }
        }
    }

    //wait to see if key is pressed before dropping the block
    void checkDrop()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            dropObject();
        }
    }

    // drop the object
    void dropObject()
    {
        carrying = false;
        carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
        carriedObject = null;
    }
}
