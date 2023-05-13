using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Posing : MonoBehaviour
{
    [SerializeField] Button poseButton;
    [SerializeField] GameObject changePoseButton;

    public int numberOfPose = 4;
    public float decreasedSpeed = 0.5f;

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
        progressBar.value += increaseAmount;
    }

    public void FinishPosing()
    {

    }

}
