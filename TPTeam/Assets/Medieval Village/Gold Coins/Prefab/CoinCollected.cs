using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollected : MonoBehaviour
{
    [SerializeField] private AudioClip[] m_GoldPickUpSound;

    private AudioSource m_AudioSource;
    private MeshRenderer m_render;

    void Start()
    {
        m_render = GetComponent<MeshRenderer>();
        m_AudioSource = GetComponent<AudioSource>();
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
