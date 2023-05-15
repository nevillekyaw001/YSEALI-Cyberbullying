using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using PixelCrushers.DialogueSystem;
using System.Collections;

public class Posing : MonoBehaviour
{
    [SerializeField] Button poseButton;
    [SerializeField] nextScene nS;
    [SerializeField] GameObject changePoseButton;
    [SerializeField] Sprite[] sprites;
    [SerializeField] SpriteRenderer sr;

    public int numberOfPose = 4;
    public float decreasedSpeed = 0.5f;
    int index = -1;

    int increaseAmount = 1;
    public bool isPressed;

    [SerializeField] Slider flexomenter;
    [SerializeField] Slider progressBar;

    private float currentValue = 0f;
    private bool isIncreasing = false;

    private void Start()
    {
        changePoseButton.SetActive(false);
    }
    void Update()
    {
        

        if (!isPressed && flexomenter.value > 0) 
        {
            flexomenter.value = flexomenter.value - decreasedSpeed;
        }
        else
        {
            flexomenter.value++;
        }

        if(flexomenter.value < 800)
        {
            changePoseButton.SetActive(false);
        }
        else if(flexomenter.value >= 1000)
        {
            changePoseButton.SetActive(true);
        }

        if(progressBar.value >= numberOfPose)
        {
            FinishPosing();
        }

    }

    public void PosingButtonPressed(bool pressed)
    {
        isPressed = pressed;
    }

    public void ChangePose()
    {
        index++;
        progressBar.value += increaseAmount;
        sr.sprite = sprites[index];

        if (index >= 2)
        { 
            index = 0;
        }
    }

    public void FinishPosing()
    {
        StartCoroutine(WaitForFinish());
    }

    IEnumerator WaitForFinish()
    {
        yield return new WaitForSeconds(2f);
        nS.NextScene();

    }

}
