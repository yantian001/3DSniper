using UnityEngine;
using System.Collections;

public class GamePause : MonoBehaviour
{

    public RectTransform pause;


    public void OnPause(LTEvent evt)
    {
        if (pause == null)
            return;
        if(GameValue.staus == GameStatu.InGame)
        {
            pause.anchoredPosition = Vector2.zero;
        }
        LeanTween.addListener((int)Events.GAMECONTINUE, OnContinue);
    }

    public void OnContinue(LTEvent evt)
    {
        LeanTween.removeListener((int)Events.GAMECONTINUE, OnContinue);
        pause.anchoredPosition = new Vector2(-Screen.width,0);
    }


    public void OnEnable()
    {
        LeanTween.addListener((int)Events.GAMEPAUSE, OnPause);
    }

    public void OnDisable()
    {
        LeanTween.removeListener((int)Events.GAMEPAUSE, OnPause);

    }
}
