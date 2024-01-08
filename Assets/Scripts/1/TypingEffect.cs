using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    public Text textDisplay; // �ؽ�Ʈ�� ǥ���� UI ���
    public string fullText; // ��ü ǥ���� �ؽ�Ʈ
    public float typingSpeed = 0.05f; // Ÿ���� �ӵ� (�� ����)

    private void Start()
    {
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        textDisplay.text = " ";
        foreach (char letter in fullText.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
