using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DanceNoteSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] danceMoves;
    [SerializeField] int index;
    [SerializeField] int noteAmount;

    [SerializeField] float timeInterval;

    [SerializeField] Slider progressBar;
    int currentAmount = 0;

    private void Start()
    {
        StartCoroutine(WaitForStart());
    }

    void Update()
    {
        index = Random.Range(0, 4);

        if (progressBar.value == noteAmount)
        {

        }
    }

    public void SpawnDanceMove(int spawnNumber)
    {
        if (currentAmount < spawnNumber)
        {
            currentAmount++;
            GameObject a = Instantiate(danceMoves[index], transform.position, Quaternion.identity) as GameObject;
        }
    }

    public void AddValueToProgressBar(int amount)
    {
        progressBar.value += amount;
    }

    IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(DanceMoveWave());
    }

    IEnumerator DanceMoveWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeInterval);
            SpawnDanceMove(noteAmount);
        }
    }
}
