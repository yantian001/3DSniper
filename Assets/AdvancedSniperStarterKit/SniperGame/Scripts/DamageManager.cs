using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DamageManager : MonoBehaviour
{

	public GameObject[] deadbody;
	public AudioClip[] hitsound;
	public int hp = 100;
	public int Score = 10;
	private float distancedamage;

    public bool isEnemy = true;
    bool isDie = false;
	
	void Start(){
		
	}
	
	void Update(){
		if (hp <= 0) {
			Dead (Random.Range (0, deadbody.Length));
		}
	}
	
	public void ApplyDamage (int damage, Vector3 velosity, float distance)
	{
		if (hp <= 0) {
			return;
		}
		distancedamage = distance;
		hp -= damage;
        //Debug.Log(damage);
	}
	
	public void ApplyDamage (int damage, Vector3 velosity, float distance, int suffix)
	{
		if (hp <= 0) {
			return;
		}
		distancedamage = distance;
		hp -= damage;
		if (hp <= 0) {
			Dead (suffix);
		}
		
	}
	
	public void AfterDead (int suffix)
	{
        //int scoreplus = Score;

        //if(suffix == 2){
        //	scoreplus = Score * 5;	
        //}

        //ScoreManager score = (ScoreManager)GameObject.FindObjectOfType (typeof(ScoreManager));	
        //if(score){
        //	score.AddScore (scoreplus, distancedamage);
        //}
        EnemyDeadInfo edi = new EnemyDeadInfo();
        edi.score = Score;
        edi.transform = this.transform;
        edi.headShot = suffix == 2;
        LeanTween.dispatchEvent((int)Events.ENEMYDIE, edi);
	}
	
	
	public void Dead (int suffix)
	{
        if (isEnemy)
        {
            if (isDie) return;
            if (deadbody.Length > 0 && suffix >= 0 && suffix < deadbody.Length)
            {
                // this Object has removed by Dead and replaced with Ragdoll. the ObjectLookAt will null and ActionCamera will stop following and looking.
                // so we have to update ObjectLookAt to this Ragdoll replacement. then ActionCamera to continue fucusing on it.
                GameObject deadReplace = (GameObject)Instantiate(deadbody[suffix], this.transform.position, this.transform.rotation);
                // copy all of transforms to dead object replaced
                CopyTransformsRecurse(this.transform, deadReplace);
                // destroy dead object replaced after 5 sec
                Destroy(deadReplace, 5);
                // destry this game object.
                Destroy(this.gameObject, 1);
                this.gameObject.SetActive(false);
                //var o = gameObject;
                //var anim = o.GetComponent<Animator>();
                //var agent = o.GetComponent<NavMeshAgent>();
                //var behavoir = o.GetComponent<BehaviorDesigner.Runtime.BehaviorTree>();
                //behavoir.enabled = false;
                //agent.enabled = false;
                //anim.enabled = false;
                //Rigidbody[] rigs = o.GetComponentsInChildren<Rigidbody>();
                //foreach (var rig in rigs)
                //{
                //    rig.isKinematic = false;
                //}
                isDie = true;
            }
            AfterDead(suffix);
        }
        else
        {
            LeanTween.rotateZ(transform.root.gameObject, 90, 0.5f);
        }
	}
	
	// Copy all transforms to Ragdoll object
	public void CopyTransformsRecurse (Transform src, GameObject dst)
	{
		
	
		dst.transform.position = src.position;
		dst.transform.rotation = src.rotation;

		
		foreach (Transform child in dst.transform) {
			var curSrc = src.Find (child.name);
			if (curSrc) {
				CopyTransformsRecurse (curSrc, child.gameObject);
			}
		}
	}

}
