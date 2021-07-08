using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollected : MonoBehaviour
{
    [SerializeField] private AudioClip[] m_GoldPickUpSound;

    private AudioSource m_AudioSource;
    private MeshRenderer m_render;
    LineRenderer m_LineRenderer;
    Timer m_timer;

    void Start()
    {
        m_timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        m_render = GetComponent<MeshRenderer>();
        m_AudioSource = GetComponent<AudioSource>();
        m_LineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (m_timer.GetTimer() <= 30)
        {
            m_LineRenderer.SetPosition(0, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position);
            m_LineRenderer.SetPosition(1, transform.position);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int RandomSoundIdx = Random.Range(0, m_GoldPickUpSound.Length);
            m_AudioSource.clip = m_GoldPickUpSound[RandomSoundIdx];
            m_AudioSource.Play();
            m_render.enabled = false;
            StartCoroutine(WaitAndDestroy(m_GoldPickUpSound[RandomSoundIdx].length));
        }
    }

    IEnumerator WaitAndDestroy(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        Destroy(gameObject);
    }
}
