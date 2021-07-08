using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] int MAX_TIMER_IN_SEC = 120;

    static float m_timer;
    TMPro.TextMeshProUGUI m_text;
    
    void Start()
    {
        m_timer = MAX_TIMER_IN_SEC;
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
}
