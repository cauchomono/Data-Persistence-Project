using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class MainManagerMenu : MonoBehaviour
{
    public static MainManagerMenu Instance;
    public string username;
    public TMP_InputField usernameInputField;
    public int highScore;
    public string highScoreUsername;

    public MainManager mainManager;
    public int highPoints;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);

        LoadData();

    }

    public void SetUser()
    {
        username = usernameInputField.text;
    }



    [System.Serializable]
    class MaxPoints
    {
        public string username;
        public int points;
    }

    public void SaveData(string username, int points)
    {
        MaxPoints maxPoints = new MaxPoints();
        maxPoints.username = MainManagerMenu.Instance.username;
        maxPoints.points = points;

        MainManagerMenu.Instance.highScoreUsername = MainManagerMenu.Instance.username;
        MainManagerMenu.Instance.highScore = points;

        string json = JsonUtility.ToJson(maxPoints);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            MaxPoints maxPoints = JsonUtility.FromJson<MaxPoints>(json);
            highScore = maxPoints.points;
            highScoreUsername = maxPoints.username;
        }

    }

}
