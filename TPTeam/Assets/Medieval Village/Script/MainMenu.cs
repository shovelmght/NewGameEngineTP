using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    GameObject m_Camera;
    Transform m_CameraTransform;
    AudioSource m_CameraAudioSource;

    [SerializeField] float RotationPerFrameY = 0.01f;
    [SerializeField] private AudioClip MainMenuMusic;

    void Start()
    {
        m_Camera = GameObject.FindGameObjectWithTag("Camera");
        m_CameraTransform = m_Camera.GetComponent<Transform>();
        m_CameraAudioSource = m_Camera.GetComponent<AudioSource>();

        m_CameraAudioSource.loop = true;
        m_CameraAudioSource.clip = MainMenuMusic;
        m_CameraAudioSource.Play();
    }

    
    void Update()
    {
        m_CameraTransform.Rotate(new Vector3(0f, RotationPerFrameY, 0f));
    }

    public void PlayButton()
    {
        AsyncOperation AsyncLoadGame = SceneManager.LoadSceneAsync("Medieval Village");
        AsyncOperation AsyncUnloadMainMenu = SceneManager.UnloadSceneAsync("MainMenu");
    }
}
