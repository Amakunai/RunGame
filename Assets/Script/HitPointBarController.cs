using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitPointBarController : MonoBehaviour
{
    
    public PlayerMover playerMover;

    private Image HPBar;
    public float HP;
    public float MaxHP;
    // Start is called before the first frame update
    void Start()
    {
        this.HPBar = GetComponent<Image>();
        MaxHP = playerMover.HP;
    }

    // Update is called once per frame
    void Update()
    {
        HP = playerMover.HP;
        HPBar.fillAmount = HP/MaxHP;
    }
}
