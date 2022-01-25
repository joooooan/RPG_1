using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public static string nextScene;

    [SerializeField]
    Image progressBar;

    private void Start()

    {
        StartCoroutine(LoadScene());
    }

    public static void LoadScene(string sceneName)

    {

        nextScene = sceneName;

        SceneManager.LoadScene("LoadScene");

    }



    IEnumerator LoadScene()

    {

        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);

        op.allowSceneActivation = false; //로딩이 끝났을때 다음씬으로 넘어갈껀지 설정

        float timer = 0.0f;

        while (!op.isDone)

        {

            yield return null;

            timer += Time.deltaTime;
            if (op.progress < 0.9f) 
            { 
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer); 

                if (progressBar.fillAmount >= op.progress) 
                { 
                    timer = 0f; 
                } 

            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);

                if (progressBar.fillAmount == 1.0f)
                { 
                    op.allowSceneActivation = true; 
                    yield break; 
                }
            }
        }

    }
}
