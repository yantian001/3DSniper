using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{


    public AS_ActionCamera ActionCamera;


    // Use this for initialization
    void Start()
    {
        if(ActionCamera == null)
        {
            ActionCamera = FindObjectOfType(typeof(AS_ActionCamera)) as AS_ActionCamera;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        //启用特效镜头
        if (ActionCamera != null)
        {
            if (enemys.Length <= 1)
            {
                ActionCamera.gameObject.SetActive(true);
            }
            else
            {
                ActionCamera.gameObject.SetActive(false);
            }
        }

        if (enemys == null || enemys.Length <= 0)
        {
            if (!ActionCamera.InAction)
                Debug.Log("Success");
        }

    }
}
