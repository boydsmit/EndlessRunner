using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathbarrier : MonoBehaviour {

    [SerializeField]
    private GameObject _player;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "deathborder")
        {
            Debug.Log("Destroyed");
            switchScene("Main");
            //StartCoroutine("switchScene");
        }
        if (collider.tag == "spike")
        {
            Debug.Log("Spikes");
            switchScene("Main");
        }
    }

    private void switchScene(string Main)
    {
        SceneManager.LoadScene(Main);
    }
}