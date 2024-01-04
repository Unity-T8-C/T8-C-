using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StorySlideShow : MonoBehaviour
{
    public Image storyImage; // 스토리 이미지를 표시할 UI 이미지
    public Sprite[] storySprites; // 스토리 이미지 배열
    public float changeInterval = 5f; // 이미지 변경 간격 (초)

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
            currentImageIndex = (currentImageIndex + 1) % storySprites.Length;
            yield return new WaitForSeconds(changeInterval);
        }
    }
}