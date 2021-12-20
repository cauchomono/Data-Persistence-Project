using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuHandler : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    private int highScore;
    private string username;

    private void Start()
    {
        if(highScoreText != null)
        {
            highScore = MainManagerMenu.Instance.highScore;
            username = MainManagerMenu.Instance.highScoreUsername;

            highScoreText.text = "High Score: " + username + ":" + highScore;

        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        MainManagerMenu.Instance.SetUser();
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
            #else
        Application.Quit();
#endif
    }


}
