using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFaces : MonoBehaviour
{
    [Header("People Array")]
    public GameObject[] people;

    [Header("Parameters")]
    public float timeBetweenChanges = 1f;

    private bool hasStartedShifting = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartChanges()
    {
        hasStartedShifting = true;
        InvokeRepeating("NextChange", timeBetweenChanges, timeBetweenChanges);
    }

    private void NextChange()
    {
        foreach (GameObject item in people)
        {
            item.transform.localScale = new Vector3(item.transform.localScale.y, item.transform.localScale.z, item.transform.localScale.x);
        }
    }
}
