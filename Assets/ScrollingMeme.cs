using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScrollingMeme : MonoBehaviour
{
    [SerializeField] GameObject[] DialogueEvents;
    [SerializeField] GameObject[] miniGameEvents;

    [SerializeField] int allAddition;
    int addition = 1;
    [SerializeField] Slider progressBar;

    [SerializeField] Animator anim;
    void Update()
    {

        if (progressBar.value >= allAddition)
        {
            StartCoroutine(WaitForFinish());
        }
    }

    public void Click(int number)
    {
        if(number == 1)
        {
            progressBar.value++;
            anim.SetTrigger(progressBar.value.ToString());
        }
    else if(number == 2)
        {
            progressBar.value++;
            anim.SetTrigger(progressBar.value.ToString());
        }
        else
        {
            progressBar.value++;
            anim.SetTrigger(progressBar.value.ToString());
        }
    }

    public void AddValueToProgressBar(int amount)
    {
        progressBar.value += amount;
    }

    IEnumerator WaitForFinish()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);

    }
}
