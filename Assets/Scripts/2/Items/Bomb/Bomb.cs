using System.Collections;
using UnityEngine;

public class BombBoom : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve curve;
    [SerializeField]
    private AudioClip boomAudio;            // ���� ����
    [SerializeField]
    private float boomDelay = 0.5f; // ��ź �̵� �ð� (0.5�� �� ����)
    private Animator animator;
    private AudioSource audioSource;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        StartCoroutine("MoveToCenter");
    }

    private IEnumerator MoveToCenter()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = Vector3.zero;
        float current = 0;
        float percent = 0;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / boomDelay;

            // boomDelay�� ������ �ð����� startPosition���� endPosition���� �̵�
            // curve�� ������ �׷���ó�� ó���� ������ �̵��ϰ�, �������� �ٴٸ����� õõ�� �̵�
            transform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(percent));

            yield return null;
        }

        // �̵��� �Ϸ�� �� �ִϸ��̼� ����
        animator.SetTrigger("OnBoom");

        //�����
        //audioSource.clip = boomAudio;
        //audioSource.Play();
    }

    public void OnBoom()
    {
        
       // ���� ���� ������ "Enemy" �±׸� ���� ��� ������Ʈ ������ �����´�
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // ���� ���� ������ "Meteor" �±׸� ���� ��� ������Ʈ ������ �����´�
        GameObject[] meteorites = GameObject.FindGameObjectsWithTag("Meteor");

        // ��� �� �ı�
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        // ��� � �ı�
        for (int i = 0; i < meteorites.Length; ++i)
        {
            meteorites[i].GetComponent<Meteorite>().OnDie();
        }            
       

        // Boom ������Ʈ ����
        Destroy(gameObject);
       
    }
}