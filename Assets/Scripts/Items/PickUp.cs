using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Transform dropPlace;
    [SerializeField] private float pickMinimumDistance = 2f;
    [SerializeField] private ChangeFaces changeScript;

    Vector3 offset;
    Vector3 startPos;
    float posX;
    float posZ;
    float posY;
    private Rigidbody rb;
    private Vector3 velocity;

    private bool locked = false;
    private bool isPicked = false;

    private bool isPlaced = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        if (!locked && Vector3.Distance(this.gameObject.transform.position, Camera.main.transform.position) < pickMinimumDistance)
        {
            isPicked = true;
            startPos = transform.position;
            offset = Camera.main.WorldToScreenPoint(transform.position);
            posX = Input.mousePosition.x - offset.x;
            posY = Input.mousePosition.y - offset.y;
            posZ = Input.mousePosition.z - offset.z;
        }
    }

    void OnMouseDrag()
    {
        if (!locked && isPicked)
        {
            float disX = Input.mousePosition.x - posX;
            float disY = Input.mousePosition.y - posY;
            float disZ = Input.mousePosition.z - posZ;
            Vector3 lastPos = Camera.main.ScreenToWorldPoint(new Vector3(disX, disY, disZ));
            transform.position = new Vector3(lastPos.x, lastPos.y, lastPos.z);
            velocity = rb.velocity;
        }
    }

    private void OnMouseUp()
    {
        /* if (Mathf.Abs(transform.position.x - bluePlace.position.x) <= 0.5f &&
            Mathf.Abs(transform.position.x - bluePlace.position.x) <= 0.5f)
        {
            transform.position = new Vector3(bluePlace.position.x, bluePlace.position.y);
            locked = true;
        } */
        rb.AddForce(velocity);
        isPicked = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUpPlace"))
        {
            //Lock Object In Place
            locked = true;
            isPicked = false;
            transform.position = dropPlace.position;
            isPlaced = true;

            //Start Changes
            changeScript.StartChanges();

        }
    }
}