using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitPointBarController : MonoBehaviour
{

    [SerializeField] private PlayerMover playerMover;

    private Image HPBar;

    [SerializeField] private float HP;
    [SerializeField] private float MaxHP;
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
