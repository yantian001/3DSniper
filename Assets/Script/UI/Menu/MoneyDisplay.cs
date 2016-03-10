using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour {

    Text text; 
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        if (text)
            text.text = Player.CurrentUser.Money.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
