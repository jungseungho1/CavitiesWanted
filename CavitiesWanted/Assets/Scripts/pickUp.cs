using UnityEngine;
using System.Collections;

public class pickUp : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    public float throwForce = 10;
    bool hasPlayer = false;
    bool beingCarried = false;
    public AudioClip[] soundToPlay;
    private AudioSource audio;
    private bool touched = false;
    float timeLookedAt = 0f;
    public float sizeDecrease = 1f;
    public float rayLangth = 0.5f;
    public GameObject Poof;
    public GameObject InstPoof;


    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit myRayHit = new RaycastHit();
        Debug.DrawRay(ray.origin, ray.direction * rayLangth);

        float dist = Vector3.Distance(gameObject.transform.position, player.position);

        if (Physics.Raycast(ray, out myRayHit, rayLangth))
        {
            if (myRayHit.collider == GetComponent<Collider>())
            {
                //Debug.Log("raycast hit on " + gameObject.name);
                if (dist <= rayLangth)
                {
                    hasPlayer = true;
                }
            }
        }
        else
        {
            hasPlayer = false;
        }
        //if (hasPlayer && Input.GetMouseButton(0))
        if (hasPlayer && (GameObject.Find("jawJoint").GetComponent<SimpleSerial>().chomp = true))
        {
            //Debug.Log("we got " + gameObject.name);
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = playerCam;
            beingCarried = true;
            RandomAudio();

            this.GetComponent<PerlinFly>().enabled = false;
            this.GetComponent<Rotate>().enabled = false;

            Instantiate(InstPoof, Poof.transform.position, Quaternion.identity);
            Destroy(gameObject);

            //transform.localScale *= sizeDecrease;
            //timeLookedAt += Time.deltaTime;

            //if (timeLookedAt >= 1f)
            //{
            //    timeLookedAt = 0f;
            //    Destroy(gameObject);
            //    GameObject sceneControl = GameObject.Find("sceneControl");
            //    loadScene loadScript = sceneControl.GetComponent<loadScene>();
            //    loadScript.countdown++;

            //}
        }
        if (beingCarried)
        {
            if (touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }
            //if (Input.GetKeyDown("o"))
            //{
            //    GetComponent<Rigidbody>().isKinematic = false;
            //    transform.parent = null;
            //    beingCarried = false;
            //    GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
            //                RandomAudio();
            //}
            //else if (Input.GetKeyDown("i"))
            else if (!Input.GetMouseButton(0))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                this.GetComponent<PerlinFly>().enabled = true;
                this.GetComponent<Rotate>().enabled = true;
                timeLookedAt = 0f;

            }
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
    void OnTriggerEnter()
    {
        if (beingCarried)
        {
            touched = true;
        }
    }
}