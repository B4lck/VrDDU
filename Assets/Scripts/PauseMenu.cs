using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject wristUI;

    public bool ActiveWristUI = true;

    // Start is called before the first frame update
    void Start()
    {
        DisplayWristUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
            DisplayWristUI();
    }
    public void DisplayWristUI()
    {
        if(ActiveWristUI)
        {
            wristUI.SetActive(false);
            ActiveWristUI = false;
            Time.timeScale = 1;
        }
        else if (!ActiveWristUI)
        {
            wristUI.SetActive(true);
            ActiveWristUI = true;
            Time.timeScale = 0;
        }
    }
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
