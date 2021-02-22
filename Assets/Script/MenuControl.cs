using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    [SerializeField]private GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!menu.activeSelf)
            {
                menu.SetActive(true);
                Time.timeScale = 0f;
            }
            else if (menu.activeSelf)
            {
                menu.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }
}
