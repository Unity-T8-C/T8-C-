using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StorySlideShow : MonoBehaviour
{
    public Image storyImage; // 스토리 이미지를 표시할 UI 이미지
    public Sprite[] storySprites; // 스토리 이미지 배열
    public float changeInterval = 5f; // 이미지 변경 간격 (초)
    public string StartSceneName = "StartScene"; // 게임 시작 씬 이름

    private int currentImageIndex = 0;

    void Start()
    {
        StartCoroutine(ChangeImage());
    }

    IEnumerator ChangeImage()
    {
        while (true)
        {
            storyImage.sprite = storySprites[currentImageIndex];

            // 마지막 이미지에 도달했는지 확인
            if (currentImageIndex == storySprites.Length - 1)
            {
                yield return new WaitForSeconds(changeInterval);

                // 게임 시작 씬으로 전환
                SceneManager.LoadScene(StartSceneName);
                break;
            }

            currentImageIndex = (currentImageIndex + 1) % storySprites.Length;
            yield return new WaitForSeconds(changeInterval);
        }
    }
}
