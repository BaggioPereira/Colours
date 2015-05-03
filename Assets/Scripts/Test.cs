using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
    public TwoDimensionalArray[] Array;
	// Use this for initialization
	void Start () 
    {
        for (int i = 0; i < Array.Length; i++ )
        {
            Array[i].active = new bool[Array[i].switchs.Length];
        }
            //for (int i = 0; i < Array.Length; i++)
            //{
            //    //Debug.Log(i.ToString());
            //    for (int j = 0; j < Array[i].objects.Length; j++)
            //    {
            //        //Debug.Log(Array[i].objects[j].name);
            //    }
            //}
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        for(int i  = 0; i < Array.Length; i++)
        {
            for(int j = 0; j<Array[i].switchs.Length; j++)
            {
                if(Array[i].switchs[j] == null)
                {
                    Array[i].active[j] = false;
                }

                else
                {
                    Array[i].active[j] = true;
                }
            }
        }
	}
}
