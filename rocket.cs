using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rocket : MonoBehaviour {
    Rigidbody _rigidbody;
    [SerializeField] Vector3 initialpos;
    GameObject touchdown;
  
    float speed = 5f;
    public float mainThrust = 1000f;
    public float rcsThrust = 200f;
    AudioSource _audiosource;
    bool isSoundPlaying;
    bool isCollisionOn;

	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody>();
        _audiosource = GetComponent<AudioSource>();
        initialpos = new Vector3(-0.1798952f, 4.512645f, -1.240017f);
        touchdown = GameObject.Find("touchdown");
        isSoundPlaying = false;
        isCollisionOn = true;


 //       Transform(speed * Time.deltaTime)
	}

    // Update is called once per frame
    void Update () {
        ProcessInput();
	}
    public void ProcessInput() {
        
        if (Input.GetKey(KeyCode.Space))
        {
            print("space");
            _rigidbody.AddRelativeForce(Vector3.up*mainThrust * Time.deltaTime);
            if (!isSoundPlaying)
            {

                _audiosource.Play();
                isSoundPlaying = true;
            }
            else {
                _audiosource.Pause();
                isSoundPlaying = false;
            }
            
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.forward*rcsThrust * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward*rcsThrust * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.O)) {
            isCollisionOn = !isCollisionOn;
                
        }
    }
    private void OnCollisionEnter(Collision collision)

    {
        if (isCollisionOn)
        {
            if (collision.gameObject.tag == "Obstacle")
            {
                transform.SetPositionAndRotation(initialpos, Quaternion.identity);
                _rigidbody.angularVelocity = new Vector3(0f, 0f, 0f);
                SceneManager.LoadScene(0);


            }
        }
        if (collision.gameObject.name == "touchdown")
        {
           
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {

                touchdown.GetComponent<Renderer>().material.color = Color.green;
            }
            else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
       
    }
    //private void OnCollisionExit(Collision collision)
    //{
    //    touchdown.GetComponent<Renderer>().material.color = Color.red;
    //}

    
}
