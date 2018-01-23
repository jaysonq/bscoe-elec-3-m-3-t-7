using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchdowncolor : MonoBehaviour {

    GameObject rocket;
    Renderer _renderer;
    [SerializeField] float range = 15f;
	// Use this for initialization
	void Start ()
    {
        rocket = GameObject.Find("rocket");
        _renderer = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(rocket.transform.position, transform.position) < range && _renderer.material.color != Color.green)
        {
            _renderer.material.color = Color.blue;
        }
        else if (Vector3.Distance(rocket.transform.position, transform.position) >= range)
        {
            _renderer.material.color = Color.red;
        }
	}
}
