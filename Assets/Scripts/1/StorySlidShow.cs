using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StorySlideShow : MonoBehaviour
{
    public Image storyImage; // ���丮 �̹����� ǥ���� UI �̹���
    public Sprite[] storySprites; // ���丮 �̹��� �迭
    public float changeInterval = 5f; // �̹��� ���� ���� (��)

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