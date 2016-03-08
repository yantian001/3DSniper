using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{


    public AS_ActionCamera ActionCamera;
    /// <summary>
    /// 
    /// </summary>
    public Spwaner spwaner = null;

    public HPSlider hp;

    public GameStatu statu { get; private set; }

    // Use this for initialization
    void Start()
    {
        if (ActionCamera == null)
        {
            ActionCamera = FindObjectOfType(typeof(AS_ActionCamera)) as AS_ActionCamera;
        }
        if (hp == null)
        {
            hp = FindObjectOfType(typeof(HPSlider)) as HPSlider;
        }

        if (spwaner == null)
        {
            var sp = GameObject.FindGameObjectWithTag("Spawner");
            if (sp)
            {
                spwaner = sp.GetComponent<Spwaner>();
                if (spwaner == null)
                { Debug.LogError("dont found spawner "); }
            }
        }

        ChangeGameStatu(GameStatu.InGame);
    }

    public void OnEnable()
    {
        LeanTween.addListener((int)Events.TIMEUP, OnTimeUp);
    }

    public void OnDisable()
    {
        LeanTween.removeListener((int)Events.TIMEUP, OnTimeUp);

    }


    // Update is called once per frame
    void Update()
    {
        //GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        ////启用特效镜头
        //if (ActionCamera != null)
        //{
        //    if (enemys.Length <= 1)
        //    {
        //        ActionCamera.gameObject.SetActive(true);
        //    }
        //    else
        //    {
        //        ActionCamera.gameObject.SetActive(false);
        //    }
        //}

        //if (enemys == null || enemys.Length <= 0)
        //{
        //    if (!ActionCamera.InAction)
        //        Debug.Log("Success");
        //}
        if(statu == GameStatu.InGame)
        {
            CheckGameStatus();
            CheckActionCamera();
        }
    }
    /// <summary>
    /// 检查游戏状态
    /// </summary>
    void CheckGameStatus()
    {
        //检查敌人是否杀完
        if (spwaner.GetEnemyCount() <= 0)
        {
            ChangeGameStatu(GameStatu.Completed);
            OnGameCompleted();
        }
        else if(hp.IsDead)
        {
            OnPlayerDie();
        }
    }

    void CheckActionCamera()
    {
        //启用特效镜头
        if (ActionCamera != null)
        {
            if (spwaner.GetEnemyCount() <= 1)
            {
                ActionCamera.gameObject.SetActive(true);
            }
            else
            {
                ActionCamera.gameObject.SetActive(false);
            }
        }

    }

    /// <summary>
    /// 更改游戏状态
    /// </summary>
    /// <param name="s"></param>
    void ChangeGameStatu(GameStatu s)
    {
        statu = s;
        GameValue.staus = statu;
        if (statu == GameStatu.Paused || statu == GameStatu.Failed || statu == GameStatu.Completed)
        {
            BahaviorGlobalVariables.SetVariableValue("InGame", false);
        }
        else
        {
            BahaviorGlobalVariables.SetVariableValue("InGame", true);
        }
    }

    void OnTimeUp(LTEvent evt)
    {
        Debug.Log("Time Up!");
        ChangeGameStatu(GameStatu.Failed);
    }

    /// <summary>
    /// 游戏完成
    /// </summary>
    void OnGameCompleted()
    {
        Debug.Log("Level Completed!");
        ChangeGameStatu(GameStatu.Completed);
    }

    void OnPlayerDie()
    {
        Debug.Log("Player Die!");
        ChangeGameStatu(GameStatu.Failed);
    }

}
