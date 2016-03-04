using UnityEngine;
using System.Collections;

public class Spwaner : MonoBehaviour {

    
    public GameObject[] Enemys;

	// Use this for initialization
	void Start () {
	    if(!(Enemys.Length > 0))
        {
            Debug.LogError("Dont have enemys to spwan.");
            return;
        }
        SpawnItem[] spawns = (SpawnItem[]) FindObjectsOfType(typeof(SpawnItem));
        if(!(spawns.Length > 0))
        {
            Debug.LogError("Dont have enemys spwan position");
        }
        foreach(SpawnItem si in spawns)
        {
            GameObject obj = Instantiate(GetSpawnObject(), si.transform.position, si.transform.rotation) as GameObject;
        }
	}
	
    GameObject GetSpawnObject()
    {
        if(Enemys.Length < 1)
        {
            return null;
        }
        int index = Random.Range(0, Enemys.Length);
        return Enemys[index];
    }

	// Update is called once per frame
	void Update () {
	
	}
}
