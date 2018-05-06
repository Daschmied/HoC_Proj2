using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Script : MonoBehaviour {

    private bool walking = false;
    private Vector3 spawnPoint;


	// Use this for initialization
	void Start () {
        spawnPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if(transform.position.y < -10f)
        {
            transform.position = spawnPoint;

        }

        Debug.Log("Here");

		if(walking)
        {
            transform.position = transform.position + Camera.main.transform.forward * .5f * Time.deltaTime;

        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider.name.Contains("plane"))
            {
                walking = false;
            }
            else
            {
                walking = true;
            }
        }
	}
}
