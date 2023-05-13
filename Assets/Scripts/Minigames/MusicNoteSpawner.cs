using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicNoteSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] musicNotes;
    [SerializeField] float timeInterval;
    [SerializeField] int noteAmount;
    [SerializeField] int index;
    [SerializeField] Slider progressBar;

    public int[] angles;
    int currentAmount = 0;

    private void Start()
    {
        StartCoroutine(WaitForStart());
    }

    void Update()
    {
        if(progressBar.value == noteAmount) 
        { 
            
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
        yield return new WaitForSeconds(2f);
        StartCoroutine(MusicNoteWave());
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
