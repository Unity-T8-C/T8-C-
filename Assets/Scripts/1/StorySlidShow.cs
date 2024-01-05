using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StorySlideShow : MonoBehaviour
{
    public Image storyImage; // ���丮 �̹����� ǥ���� UI �̹���
    public Sprite[] storySprites; // ���丮 �̹��� �迭
    public float changeInterval = 5f; // �̹��� ���� ���� (��)
    public string StartSceneName = "StartScene"; // ���� ���� �� �̸�

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

            // ������ �̹����� �����ߴ��� Ȯ��
            if (currentImageIndex == storySprites.Length - 1)
            {
                yield return new WaitForSeconds(changeInterval);

                // ���� ���� ������ ��ȯ
                SceneManager.LoadScene(StartSceneName);
                break;
            }

            currentImageIndex = (currentImageIndex + 1) % storySprites.Length;
            yield return new WaitForSeconds(changeInterval);
        }
    }
}
