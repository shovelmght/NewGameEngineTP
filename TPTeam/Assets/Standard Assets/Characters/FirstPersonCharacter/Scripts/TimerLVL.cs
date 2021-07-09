using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerLVL : MonoBehaviour
{
    [SerializeField] int m_MaxTimer = 120;
    [SerializeField] int m_TimerTillGiveHint = 30;

    static float m_timer;
    TMPro.TextMeshProUGUI m_text;

    void Start()
    {
        m_timer = m_MaxTimer;
        m_text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        m_timer -= Time.deltaTime;
        if (Mathf.RoundToInt(m_timer % 60) < 10)
        {
            m_text.text = Mathf.Floor(m_timer / 60) + ":0" + Mathf.RoundToInt(m_timer % 60);
        }
        else
        {
            m_text.text = Mathf.Floor(m_timer / 60) + ":" + Mathf.RoundToInt(m_timer % 60);
        }
    }

    public float GetTimer()
    {
        return m_timer;
    }

    public int GetTimerTillHint()
    {
        return m_TimerTillGiveHint;
    }
}
