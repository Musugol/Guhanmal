using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    AudioSource StartBGM;
    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void BgmPlay()
    {
        if (Instance == null)
            StartBGM = gameObject.GetComponent<AudioSource>();
        else
            StartBGM = Instance.GetComponent<AudioSource>();
        StartBGM.enabled = true;
    }

    public void BgmStop()
    {
        if (Instance == null)
            StartBGM = gameObject.GetComponent<AudioSource>();
        else
            StartBGM = Instance.GetComponent<AudioSource>();
        StartBGM.enabled = false;
    }
}
