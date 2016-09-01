using UnityEngine;
using System.Collections;
using UnityEditor;

public class DisableAllRigbody
{

    [MenuItem("FUG/Disable Select Rigbody")]
    public static void Exec()
    {
        var o = Selection.activeGameObject;
        Debug.Log(o.name);
        Rigidbody[] rigs = o.GetComponentsInChildren<Rigidbody>();
        foreach (var rig in rigs)
        {
            rig.isKinematic = true;
        }
    }
    [MenuItem("FUG/Enable Select Rigbody")]
    public static void Execute()
    {
        var o = Selection.activeGameObject;
        Debug.Log(o.name);
        Rigidbody[] rigs = o.GetComponentsInChildren<Rigidbody>();
        foreach (var rig in rigs)
        {
            rig.isKinematic = false;
        }
    }
    [MenuItem("FUG/Die Object")]
    public static void DieObject()
    {
        var o = Selection.activeGameObject;
        var anim = o.GetComponent<Animator>();
        var agent = o.GetComponent<NavMeshAgent>();
        var behavoir = o.GetComponent<BehaviorDesigner.Runtime.BehaviorTree>();
        behavoir.enabled = false;
        agent.enabled = false;
        anim.enabled = false;
        DisableAllRigbody.Execute();
    }
}
