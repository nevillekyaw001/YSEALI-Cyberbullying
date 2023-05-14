using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoppingThought : MonoBehaviour
{
    [SerializeField] GameObject[] DialogueEvents;
    [SerializeField] GameObject[] miniGameEvents;
    [SerializeField] int thoughtNumber;
    [SerializeField] Slider progressBar;

    void Update()
    {
        if (progressBar.value >= thoughtNumber)
        {
            StartCoroutine(WaitForFinish());
        }
    }

    public void AddValueToProgressBar(int amount)
    {
        progressBar.value += amount;
    }

    IEnumerator WaitForFinish()
    {
        yield return new WaitForSeconds(1f);
        DialogueEvents[0].SetActive(true);
        miniGameEvents[0].SetActive(false);
    }
}
