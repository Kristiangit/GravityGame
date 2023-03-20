using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(!PauseMenu.activeSelf)
            {
                Time.timeScale = 0f;
                PauseMenu.SetActive(true);
                Cursor.visible = true;

            }
            else {
                Time.timeScale = 1f;
                PauseMenu.SetActive(false);
                Cursor.visible = false;
            }
        }
    }
    public void quit () {
        Application.Quit(); 
    }
    public void resume () {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        Cursor.visible = false;
    }
}
