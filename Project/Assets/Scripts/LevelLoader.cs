using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
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
