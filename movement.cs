using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movement : MonoBehaviour {
   
    public float amplitude = 2f;
    public float frequency = 2f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    public enum Axis { Horizontal, Vertical };
    public Axis floatAxis;
    // Use this for initialization
    void Start () {
        posOffset = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (floatAxis == Axis.Horizontal)
        {
            FloatObjectHorizontal();
        }
        else
        {
            FloatObjectVertical();
        }

    }
    void FloatObjectVertical()
    {
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }

    void FloatObjectHorizontal()
    {
        tempPos = posOffset;
        tempPos.x += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}
