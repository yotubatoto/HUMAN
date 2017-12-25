using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Now_Loading : MonoBehaviour   
{
    private AsyncOperation async;
    public GameObject now_loading;
    
    //public GameObject LoadingUi;
    //public Slider Slider;

    public void LoadNextScene()
    {
        //LoadingUi.SetActive(true);
        StartCoroutine(LoadScene("Stage_" +StageSelectManager.ST_OWNER_NUMBER +"_Scene"));
    }
    public void Load_NextScene_Title()
    {
        StartCoroutine(LoadScene("StageSelect_Scene"));
    }
    public void Load_NextScene_First()
    {
        StartCoroutine(LoadScene("Title_Scene"));
    }
    public void Load_NextScene_Ending()
    {
        StartCoroutine(LoadScene("Ending_Scene"));
    }
    //public void Load_NextScene_Des()
    //{
    //	StartCoroutine(LoadScene("Description_Scene"));
    //}
    IEnumerator LoadScene(string scene_name)
    {
        async = SceneManager.LoadSceneAsync(scene_name);

        while (!async.isDone)
        {
            //Slider.value = async.progress;
            //Debug.Log(async.progress);
            yield return null;
        }
    }
   
}