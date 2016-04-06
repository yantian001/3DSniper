using UnityEngine;
using System.Collections;

public class SetFPS : MonoBehaviour
{
    public void Awake()
    {
        Application.targetFrameRate = -1;
    }
}
