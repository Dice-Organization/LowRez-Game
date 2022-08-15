using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject LoadingScreen;
    private const float MinLoadedTime = 2f;

    // Start is called before the first frame update
    private void Awake() {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        SceneManager.LoadSceneAsync((int)SceneIndex.TitleScreen);
        LoadingScreen.SetActive(false);
    }

    public void LoadScene()
    {
        
        StartCoroutine(LoadScreenRoutine());
    }


    

    private IEnumerator LoadScreenRoutine()
    {
        LoadingScreen.SetActive(true);

        float loadedTime = 0;
        
        if(SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            while (!loadingOperation.isDone)
            {   
                
                yield return null;
            }
        }
        else
        {
            LoadingScreen.SetActive(false);
            SceneManager.LoadSceneAsync((int)SceneIndex.TitleScreen);
        }
        

        while(loadedTime < MinLoadedTime)
        {
            loadedTime += Time.deltaTime;
            yield return null;
        }
        
       
        

        
        LoadingScreen.SetActive(false);
    }
}
