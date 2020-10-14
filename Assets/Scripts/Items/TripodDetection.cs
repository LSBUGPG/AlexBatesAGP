using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripodDetection : MonoBehaviour
{
    [Header("Camera GameObjects")]
    [SerializeField] private Camera mainCam;
    [SerializeField] private Camera tripodCam;

    private bool inRangeOfCamera = false;
    private CharacterController playerController;
    private bool isLookingThrough = false;

    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRangeOfCamera)
        {
            if (!isLookingThrough)
            {
                //View through the camera object
                mainCam.depth = -2;
                tripodCam.depth = 0;

                //Block Player
                playerController.canMove = false;

                //Set Status
                isLookingThrough = true;
            }

            else
            {
                mainCam.depth = 0;
                tripodCam.depth = -2;

                //Block Player
                playerController.canMove = true;

                //Set Status
                isLookingThrough = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CameraTripod"))
        {
            inRangeOfCamera = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CameraTripod"))
        {
            inRangeOfCamera = false;
        }
    }
}