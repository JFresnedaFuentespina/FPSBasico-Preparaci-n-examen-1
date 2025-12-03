using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Button continueButton;
    public Button mainMenuButton;
    public Button exitButton;

    public GameObject pauseMenu;
    public bool isPaused = false;
    void Start()
    {
        isPaused = false;
        continueButton.onClick.AddListener(HidePause);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void GoToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    private void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
            Application.Quit();
        
#endif
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            ShowPause(true);
        }
    }

    void ShowPause(bool show)
    {
        pauseMenu.SetActive(show);

        if (show)
        {
            Time.timeScale = 0f;
            isPaused = true;

            // Mostrar cursor para poder interactuar con el menú
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f;
            isPaused = false;

            // Ocultar cursor de nuevo
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }


    void HidePause()
    {
        ShowPause(false);
    }
}
