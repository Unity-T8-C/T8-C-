using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPanel : MonoBehaviour
{
    public void retry()
    {
        GameManager.Instance.retry();
    }
}
