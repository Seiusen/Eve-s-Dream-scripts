using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D bc;
    public int levelToLoad;

    public Vector3 position;
    public VectorValue playerStorage;

    public Image LoadInner;
    public GameObject loadingScreen;

    private void Start() 
    {
        anim = GetComponent<Animator>();   
        bc = GetComponent<BoxCollider2D>(); 
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            FadeToLevel();
        }
    }

    public void FadeToLevel()
    {
        anim.SetTrigger("fade");
    }

    public void OnFadeComplete()
    {
        playerStorage.initialValue = position;
        SceneManager.LoadScene(levelToLoad);
        StartCoroutine(LoadingScreenOnFade());
    }

    IEnumerator LoadingScreenOnFade()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelToLoad);
        loadingScreen.SetActive(true);
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            LoadInner.fillAmount = progress;
            yield return null;
        }
    }

}
