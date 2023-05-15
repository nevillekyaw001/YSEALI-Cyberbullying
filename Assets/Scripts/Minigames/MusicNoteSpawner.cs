using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicNoteSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] musicNotes;
    [SerializeField] GameObject DialogueEvents;
    [SerializeField] GameObject miniGameEvents;
    [SerializeField] nextScene nS;


    [SerializeField] float timeInterval;
    [SerializeField] int noteAmount;
    [SerializeField] int index;
    [SerializeField] Slider progressBar;

    public int[] angles;
    int currentAmount = 0;

    private void Start()
    {
        StartCoroutine(WaitForStart());
        Pla
    }

    void Update()
    {
        index = Random.Range(0, 3);
        if(progressBar.value >= noteAmount) 
        { 
            StartCoroutine(WaitForFinish());
        }
    }

    public void spawnMusicNotes(int spawnNumber)
    {
        if (currentAmount < spawnNumber)
        {
            currentAmount++;
            GameObject a = Instantiate(musicNotes[index], transform.position, Quaternion.identity) as GameObject;
        }
    }

    public void AddValueToProgressBar(int amount)
    {
        progressBar.value += amount;
    }

    IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(MusicNoteWave());
    }

    IEnumerator WaitForFinish() 
    {
        
        yield return new WaitForSeconds(1f);
        if (DialogueEvents)
        {
            DialogueEvents.SetActive(true);

        }

        if (miniGameEvents)
        {
            miniGameEvents.SetActive(false);
        }

    }

    IEnumerator MusicNoteWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeInterval);
            spawnMusicNotes(noteAmount);
        }
    }


}
