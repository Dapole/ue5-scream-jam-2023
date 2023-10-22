using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startCanvas;
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject menuAboutTeam;
    private GameObject controlObject;
    [SerializeField] private GameObject finishMenu;
    public bool isGameStarted = false;

    private bool isMenuActive = false;

    private void Start()
    {
        finishMenu.SetActive(false);
        menuCanvas.SetActive(false);
        menuAboutTeam.SetActive(false);
        startCanvas.SetActive(true);
        controlObject = GameObject.FindGameObjectWithTag("Player");
        ChangeGameState(startCanvas, true);
    }

    private void ChangeGameState(GameObject UI, bool state)
    {
        isMenuActive = state;
        UI.SetActive(state);
        if (controlObject != null)
        {
            controlObject.GetComponent<FirstPersonController>().enabled = !state;
        }
        if (state)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGameStarted) return;
            if (isMenuActive)
            {
                ChangeGameState(menuCanvas, false);
            }
            else
            {
                ChangeGameState(menuCanvas, true);
            }
        }
    }

    public void StartGame()
    {
        isGameStarted = true;
        ChangeGameState(startCanvas, false);
    }
    
    public void FinishGame()
    {
        ChangeGameState(finishMenu, true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OpenAuthors()
    {
        if(!isGameStarted)
            isGameStarted = true;
        menuCanvas.SetActive(false);
        startCanvas.SetActive(false);
        ChangeGameState(menuAboutTeam, true);
    }

    public void BackButton()
    {
        ChangeGameState(menuAboutTeam, false);
        ChangeGameState(menuCanvas, false);
        ChangeGameState(startCanvas, false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
