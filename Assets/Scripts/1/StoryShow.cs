using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryShow : MonoBehaviour
{
    public GameObject StoryPanel0;
    public GameObject StoryPanel1;
    public GameObject StoryPanel2;

    private void Start()
    {
        StartCoroutine(DelayTime(3));
    }

    IEnumerator DelayTime(float time)
    {
        yield return new WaitForSeconds(time);

        StoryPanel0.SetActive(false);
        StoryPanel1.SetActive(false);
        StoryPanel2.SetActive(true);
    }

    public void GoStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
