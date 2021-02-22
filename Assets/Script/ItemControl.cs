using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControl : MonoBehaviour
{
    [SerializeField] private GameObject item;
    [SerializeField] private ScoreControl ScoreControl;
    [SerializeField] private PlayerMover PlayerMover;

    [SerializeField] private bool score;
    [SerializeField] private bool ink;

    [SerializeField] private int ideascore;
    [SerializeField] private float inkscore;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            item.SetActive(false);

            if (score) 
            {
                ScoreControl.score += ideascore;
            }

            if (ink)
            {
                PlayerMover.HP += inkscore;
            }
        }
    }
}
