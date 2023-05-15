using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField]
    AudioClip[] clips;

    [SerializeField]
    AudioSource aS;
    [SerializeField]
    AudioSource bS;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        aS= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(int index)
    {

        aS.clip = clips[index];
        aS.Play();
    }
    public void PlayBGM(AudioClip clip)
    {
        bS.clip = clip;
        bS.Play();
    }
}
