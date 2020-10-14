using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    public Behaviour behaviour;
    public float sceneLoadDelay;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //get the name of the photo as string called; String photoName
            behaviour.enabled = true;
            StartCoroutine(LoadNewScene());
        }
    }

    IEnumerator LoadNewScene()
    {
        yield return new WaitWhile(() => behaviour.enabled);
        SceneManager.LoadScene(behaviour.name);
    }
}
