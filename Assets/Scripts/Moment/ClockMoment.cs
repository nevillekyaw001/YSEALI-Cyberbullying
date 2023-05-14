using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClockMoment : MonoBehaviour
{
    [SerializeField] int clickTimes;
    int numberTimes = 0;

    [SerializeField] Animator clockAnim;
    [SerializeField] Animator alanAnim;
    [SerializeField] GameObject blanket;
    [SerializeField] string nextScene;

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        clockAnim.SetBool("wakeHim", true);
        StartCoroutine(SceneStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerClick()
    {
        clockAnim.SetBool("wakeHim", true);
        if (numberTimes < clickTimes)
        {
            StartCoroutine(RunTimeInterval());
            numberTimes++;
        }
        else
        {
            blanket.SetActive(false);
            alanAnim.SetTrigger("awake");
            StartCoroutine(SceneFinish());
        }
        
    }

    IEnumerator SceneStart()
    {
        yield return new WaitForSeconds(2f);
        clockAnim.SetBool("wakeHim", false);
    }
    IEnumerator RunTimeInterval()
    {
        yield return new WaitForSeconds(1f);
        clockAnim.SetBool("wakeHim", false);
    }

    IEnumerator SceneFinish()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(nextScene);
    }
}
