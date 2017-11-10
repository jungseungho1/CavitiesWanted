using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pickUp : MonoBehaviour
{
    public bool hasPlayer = false;
    public AudioClip[] soundToPlay;
    private AudioSource audio;
    public GameObject Poof;
    public GameObject InstPoof;


    void Start()
    {
        audio = GetComponent<AudioSource>();
    }


    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hasPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hasPlayer = false;
        }
    }




    void Update()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        //if (hasPlayer && Input.GetMouseButton(0))


        if (hasPlayer && (GameObject.Find("jawJoint").GetComponent<SimpleSerial>().chomp))
        {
            Debug.Log("Eating " + gameObject.name);
            GetComponent<Rigidbody>().isKinematic = true;
            RandomAudio();

            this.GetComponent<PerlinFly>().enabled = false;
            this.GetComponent<Rotate>().enabled = false;

            Destroy(gameObject);
            Instantiate(InstPoof, Poof.transform.position, Quaternion.identity);
            GameObject sceneControl = GameObject.Find("sceneControl");
            loadScene loadScript = sceneControl.GetComponent<loadScene>();
            loadScript.countdown++;
            }
            else
            {
            GetComponent<Rigidbody>().isKinematic = false;
            transform.parent = null;
            this.GetComponent<PerlinFly>().enabled = true;
            this.GetComponent<Rotate>().enabled = true;
        }
    }

    void RandomAudio()
    {
        if (audio.isPlaying)
        {
            return;
        }
        audio.clip = soundToPlay[Random.Range(0, soundToPlay.Length)];
        audio.Play();
    }

}