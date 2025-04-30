using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoadManager : MonoBehaviour
{
    public static ScenesLoadManager instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            Application.targetFrameRate = 60;
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public async void OpenGameScene()
    {
       await SceneManager.LoadSceneAsync(1);
    }

    public async void OpenMainMenuScene()
    {
        await SceneManager.LoadSceneAsync(0);
    }
}
