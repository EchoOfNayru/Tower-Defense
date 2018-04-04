using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour {

    public int health;
    public Text healthText;

    public delegate void DUpdateHealthUI();
    public DUpdateHealthUI OnUpdateHealthUI;

	// Use this for initialization
	void Start () {
        OnUpdateHealthUI += UpdateHealthUI;
        healthText.text = "Base Health : " + health;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateHealthUI()
    {
        healthText.text = "Base Health : " + health;
    }
}
