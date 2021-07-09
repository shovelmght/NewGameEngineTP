using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class LVLMan : MonoBehaviour
{
    private float timerForest = 0;
    private float endTimerForest = 17;
    private float timerTown = 0;
    private float endTimerTown = 10;
    public FadeImg ScreenFall;
    public GameObject screenFallObj;
    public FadeTxt txtRestart;
    public GameObject objTxtRestart;
    public FadeImg uIRestart;
    public GameObject ObjUIRestart;
    [SerializeField] private AudioClip[] ambientSoundForest;
    [SerializeField] private AudioClip[] ambientSoundTown;
    [SerializeField] private AudioClip[] Music;
    public FirstPersonController fpc;
    public GameObject objFpc;
    public AudioSource audioSourceForestSonor;
    public AudioSource audioSourceTownSonor;
    public AudioSource audioSourceMusic;
    public bool m_Toggle = false;

    void Start()
    {
        screenFallObj = GameObject.FindGameObjectWithTag("FadeFall");
        ScreenFall = screenFallObj.GetComponent<FadeImg>();

        ObjUIRestart = GameObject.FindGameObjectWithTag("UIRestart");
        uIRestart = ObjUIRestart.GetComponent<FadeImg>();

        objTxtRestart = ObjUIRestart.transform.GetChild(0).gameObject;
        txtRestart = objTxtRestart.GetComponent<FadeTxt>();

        objFpc = GameObject.FindGameObjectWithTag("Player");
        fpc = objFpc.GetComponent<FirstPersonController>();

        audioSourceMusic.loop = true;
        audioSourceMusic.clip = Music[1];
        audioSourceMusic.Play();
    }
    private void Update()
    {
        if (timerForest > endTimerForest)
        {
            timerForest = 0;
            int n = Random.Range(1, ambientSoundForest.Length);
            audioSourceForestSonor.clip = ambientSoundForest[n];
            audioSourceForestSonor.PlayOneShot(audioSourceForestSonor.clip);
            ambientSoundForest[n] = ambientSoundForest[0];
            ambientSoundForest[0] = audioSourceForestSonor.clip;
        }
        timerForest += Time.deltaTime;

        if (timerTown > endTimerTown)
        {
            timerTown = 0;
            int n = Random.Range(1, ambientSoundTown.Length);
            audioSourceTownSonor.clip = ambientSoundTown[n];
            audioSourceTownSonor.PlayOneShot(audioSourceTownSonor.clip);
            ambientSoundTown[n] = ambientSoundTown[0];
            ambientSoundTown[0] = audioSourceTownSonor.clip;
        }
        timerTown += Time.deltaTime;
    }

    public void Fall()
    {
        StartCoroutine(ScreenFall.Lerp());
        StartCoroutine(uIRestart.Lerp());
        StartCoroutine(txtRestart.Lerp());
        StartCoroutine(FadeOut());
    }
    
    public IEnumerator FadeOut()
    {
        float startVolume = audioSourceMusic.volume;

        while (audioSourceMusic.volume > 0)
        {
        audioSourceMusic.volume -= startVolume * Time.deltaTime / 2;

            yield return null;
        }

    audioSourceMusic.Stop();
    audioSourceMusic.volume = startVolume;
    audioSourceMusic.clip = Music[0];
    audioSourceMusic.Play();
    fpc.SetCursorLock(false);

    }
}

