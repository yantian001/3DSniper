using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class EnemyShoot : MonoBehaviour
{

    public GameObject bullet;

    public Transform targetTranform;

    public Transform firePosition;

    public float spread;

    public void Start()
    {
        targetTranform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Fire()
    {
        if(bullet && targetTranform)
        {
            var b = (GameObject)GameObject.Instantiate(bullet, firePosition.position, Quaternion.LookRotation(targetTranform.position));
            //b.transform.SetParent(transform);
            // b.
            // b.GetComponent<Rigidbody>().velocity = b.transform.TransformDirection(firePosition.position - targetTranform.position);
            b.GetComponent<AS_Bullet>().source = transform;
            b.transform.forward =(targetTranform.position- firePosition.position + new Vector3(Random.Range(-spread,spread), Random.Range(-spread, spread), Random.Range(-spread, spread))).normalized;
        }
    }
}
