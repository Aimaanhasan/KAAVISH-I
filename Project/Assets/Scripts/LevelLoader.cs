using GoogleARCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    //new work

    public static int level;
    public static int chapter;

    public GameObject levelcompletecanvas;

    void Start()
    {
        levelcompletecanvas = GameObject.FindGameObjectWithTag("LevelCompleteCanvas");
        if (levelcompletecanvas != null)
            levelcompletecanvas.SetActive(false);
    }
    void Awake()
    {

    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(currentSceneIndex + 1));
        //SceneManager.LoadScene(currentSceneIndex + 1);

    }
    public void LoadPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(currentSceneIndex - 1));
    }

    //new work

    public void LoadChapter(int chapter1)
    {
        chapter = chapter1;
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(7));
    }
    public void LoadLevel(int level1)
    {
        level = level1;
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(6));
    }

    public void LoadNextLevel()
    {
        if (CloudVariables.ImportantValues[2] == 5)
        {
            CloudVariables.ImportantValues[1]++;
            CloudVariables.ImportantValues[2] = 0;
        }
        else
        {
            CloudVariables.ImportantValues[2]++;
        }
        Debug.Log(level);
        level = level + 1;

        if (level == 6)
        {
            chapter += 1;
            level = 0;
        }
        //var session = GameObject.Find("ARCore Device").GetComponent<ARCoreSession>(); session.SessionConfig.PlaneFindingMode = DetectedPlaneFindingMode.Horizontal; session.SessionConfig.EnablePlaneFinding = true; session.OnEnable();
        PlayGamesScript.Instance.SaveData();
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(6));
    }
    public void RestartLevel()
    {
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(6));
    }
    public void LoadStartScene()
    {
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(6));
        //SceneManager.LoadScene(6);
    }
    public void CreditsScene()
    {
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync("Credit"));
        //SceneManager.LoadScene("Credit");
    }
    public void LevelsScene()
    {
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync("Levels"));
        //SceneManager.LoadScene("Levels");
    }

    public void ChaptersScene()
    {
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync("Chapters"));
    }
    public void PlayScene()
    {
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(2));
        //SceneManager.LoadScene(2);
    }
    public void AchievementScene()
    {
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(0));
        //SceneManager.LoadScene(0);
    }
    public void SettingsScene()
    {
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync("Settings"));
        //SceneManager.LoadScene("Settings");
    }
    public void HelpScene()
    {
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync("HELP"));
        //SceneManager.LoadScene("HELP");
    }
    public void LoadMenuScene()
    {
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(1));
        //SceneManager.LoadScene(1);
    }
    public void ExitScreen()
    {
        Application.Quit();
    }
}
