using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Posing : MonoBehaviour
{
    [SerializeField] Button poseButton;
    [SerializeField] GameObject changePoseButton;
    [SerializeField] Sprite[] sprites;
    [SerializeField] SpriteRenderer sr;

    public int numberOfPose = 4;
    public float decreasedSpeed = 0.5f;
    int index = 0;

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

        if(index >= 2)
        { 
            index = 0;
        }
    }

    public void FinishPosing()
    {

    }

}
