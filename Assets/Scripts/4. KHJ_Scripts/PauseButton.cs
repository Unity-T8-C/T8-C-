using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    bool m_bPause;

    void Update()
    {
        if (this.m_bPause == true)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void Pause()
    {
        if(m_bPause == false)
        {
            this.m_bPause = true;
        }
        else
        {
            this.m_bPause = false;
        }
    }
}
