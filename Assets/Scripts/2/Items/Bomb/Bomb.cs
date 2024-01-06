using System.Collections;
using UnityEngine;

public class BombBoom : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve curve;
    [SerializeField]
    private AudioClip boomAudio;            // 사운드 파일
    [SerializeField]
    private float boomDelay = 0.5f; // 폭탄 이동 시간 (0.5초 후 폭발)
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

            // boomDelay에 설정된 시간동안 startPosition부터 endPosition까지 이동
            // curve에 설정된 그래프처럼 처음엔 빠르게 이동하고, 목적지에 다다를수록 천천히 이동
            transform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(percent));

            yield return null;
        }

        // 이동이 완료된 후 애니메이션 변경
        animator.SetTrigger("OnBoom");

        //오디오
        //audioSource.clip = boomAudio;
        //audioSource.Play();
    }

    public void OnBoom()
    {
        
       // 현재 게임 내에서 "Enemy" 태그를 가진 모든 오브젝트 정보를 가져온다
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // 현재 게임 내에서 "Meteor" 태그를 가진 모든 오브젝트 정보를 가져온다
        GameObject[] meteorites = GameObject.FindGameObjectsWithTag("Meteor");

        // 모든 적 파괴
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        // 모든 운석 파괴
        for (int i = 0; i < meteorites.Length; ++i)
        {
            meteorites[i].GetComponent<Meteorite>().OnDie();
        }            
       

        // Boom 오브젝트 삭제
        Destroy(gameObject);
       
    }
}