using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Canvas menuCanvas;
    [SerializeField] private string reloadLevel;
    private bool menuActive = false;

    private void Start()
    {
        menuCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !menuActive)
        {
            menuActive = true;
            menuCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && menuActive)
        {
            menuActive = false;
            menuCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(reloadLevel);
        Time.timeScale = 1;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
