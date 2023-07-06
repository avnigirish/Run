using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSphere : MonoBehaviour
{
    Rigidbody rb;
    Camera mainCamera;
    bool ground1;
    bool ground2;
    bool invert;
    bool isRotated;
    int count;
    Animation anim;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.GetComponent<Rigidbody>().freezeRotation = true;
        mainCamera = Camera.main;
        mainCamera.enabled = true;
        anim = mainCamera.GetComponent<Animation>();
        audio = GetComponent<AudioSource>();
        ground1 = true;
        ground2 = false;
        invert = false;
        isRotated = false;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.Translate(Vector3.forward * 5f * Time.deltaTime);
        transform.Translate(Vector3.forward * 5f * Time.deltaTime, Space.World);

        if (transform.position.y <= 1 && transform.position.y >= 0.9)
            ground1 = true;
        else
            ground1 = false;

        if (transform.position.y <= 9 && transform.position.y >= 8.9)
            ground2 = true;
        else
            ground2 = false;

        if (transform.position.y < -10 || transform.position.y > 20) { 
            if(invert)
                Physics.gravity = -1 * Physics.gravity;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKey(KeyCode.RightArrow) && count==0)
        {
            if (transform.position.x < 10)
                transform.Translate(Vector3.right * 5f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && count==0)
        {
            if (transform.position.x > -10)
                transform.Translate(Vector3.left * 5f * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audio.Play();
            if (ground1)
            {
                rb.AddForce(Vector3.up * 50f * 10);
                ground1 = false;
            }
            if (ground2)
            {
                rb.AddForce(Vector3.down * 50f * 10);
                ground2 = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            audio.Play();
            if (!ground1 && !ground2)
                return;

            count++;

            if (!invert && (ground1 || ground2) && count>0)
                invert = true;
            else if(invert && (ground1 || ground2))
                invert = false;

            isRotated = false;
            Physics.gravity = -1 * Physics.gravity;

        }

        if (invert && count>0)
        {
            if (!isRotated)
            {      
                if (mainCamera.transform.rotation.eulerAngles.z != 180)
                {
                    anim.Play("Invert Movement");
                    Debug.Log("if statement for invert gravity");
                }
                else
                    isRotated = true;       
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (transform.position.x > -10)
                    transform.Translate(Vector3.left * 5f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (transform.position.x < 10)
                    transform.Translate(Vector3.right * 5f * Time.deltaTime);
            }

        }
        else if (!invert && count>0){
            
            if (!isRotated)
            {
                if (mainCamera.transform.rotation.eulerAngles.z != 0)
                {
                    anim.Play("Non Invert Movement");
                    Debug.Log("if statement for no invert gravity");
                }
                else
                    isRotated = true;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (transform.position.x < 10)
                    transform.Translate(Vector3.right * 5f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (transform.position.x > -10)
                    transform.Translate(Vector3.left * 5f * Time.deltaTime);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Cube(Clone)")
        {
            if (invert)
                Physics.gravity = -1 * Physics.gravity;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
