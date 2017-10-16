using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour {

    //an array of the prefabs
    public GameObject[] _Prefabs;
    public GameObject Endblock;

    //public List<GameObject> _PrefabsList;
    
    public GameObject activeChunk;

    public GameObject _trigger;
	// Use this for initialization
	void Start ()
    {
        CreatePrefab();
	}

    void CreatePrefab()
    {
        var chunckChilds = activeChunk.GetComponentsInChildren<Transform>();
        Vector3 spawnPos = Vector3.zero;
        foreach (Transform t in chunckChilds)
        {
            if (t.name == "EndCube")
            {
                spawnPos = new Vector3(t.position.x + 1, t.position.y, t.position.z);
            }
        }
        GameObject clone = Instantiate(_Prefabs[RNum()], spawnPos, Quaternion.identity) as GameObject;
        activeChunk = clone;

        for(int i = 0; i < 1; i++)
        {
            DestroyObject(clone, 10.0f);
        }
    }

    int RNum()
    {
        System.Random random = new System.Random();
        return random.Next(0, _Prefabs.Length);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "trigger")
        {
            print(collider.name);
            Debug.Log("object created");
            CreatePrefab();
            DestroyObject(_trigger);
        }
    }
}
