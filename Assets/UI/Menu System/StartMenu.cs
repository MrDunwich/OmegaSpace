using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Canvas menuCanvas;
    [SerializeField] private string firstLevel;

    private void Start()
    {
        menuCanvas.gameObject.SetActive(true);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(firstLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
