using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    public Text textDisplay; // 텍스트를 표시할 UI 요소
    public string fullText; // 전체 표시할 텍스트
    public float typingSpeed = 0.05f; // 타이핑 속도 (초 단위)

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
