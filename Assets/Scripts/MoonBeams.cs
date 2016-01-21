using UnityEngine;
using System.Collections;

public class MoonBeams : MonoBehaviour {

    public int moonbeam;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void onHit()
    {
        moonbeam++;
    }
}
