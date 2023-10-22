using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startCanvas;
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject menuAboutTeam;
    [SerializeField] private GameObject controlObject;
    [SerializeField] private GameObject finishMenu;

    private bool isMenuActive = false;

    private void Start()
    {
        finishMenu.SetActive(false);
        ShowStartCanvas();
    }

    public void ShowStartCanvas()
    {
        startCanvas.SetActive(true);
        isMenuActive = false;
        if (controlObject != null)
        {
            controlObject.GetComponent<FirstPersonController>().enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuActive)
            {
                ResumeGame();
            }
            else
            {
                OpenMenu();
            }
        }
    }

    public void StartGame()
    {
        if (controlObject != null)
        {
            controlObject.GetComponent<FirstPersonController>().enabled = true;
        }
        startCanvas.SetActive(false);
        menuCanvas.SetActive(false);
    }

    public void OpenAuthors()
    {
        menuCanvas.SetActive(false);
        menuAboutTeam.SetActive(true);
    }

    public void OpenSettings()
    {
        
    }

    public void BackButton()
    {
        menuCanvas.SetActive(true);
        menuAboutTeam.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    

    public void OpenMenu()
    {
        menuCanvas.SetActive(true);
        isMenuActive = true;
        if (controlObject != null)
        {
            controlObject.GetComponent<FirstPersonController>().enabled = false;
        }
    }

    public void ResumeGame()
    {
        menuCanvas.SetActive(false);
        isMenuActive = false;
        if (controlObject != null)
        {
            controlObject.GetComponent<FirstPersonController>().enabled = true;
        }
    }
}
