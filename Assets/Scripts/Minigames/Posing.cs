using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Posing : MonoBehaviour
{
    [SerializeField] Button PoseButton;
    [SerializeField] GameObject ChangePoseButton;

    public int numberOfPose = 4;

    int increaseAmount = 3;
    public bool isPressed;

    [SerializeField] Slider flexomenter;
    [SerializeField] Slider progressBar;

    private float currentValue = 0f;
    private bool isIncreasing = false;

    private void Start()
    {
        ChangePoseButton.SetActive(false);
    }
    void Update()
    {
        if (!isPressed) return;
        else
        {
            flexomenter.value++;
        }

        if(flexomenter.value < 1000)
        {
            ChangePoseButton.SetActive(false);
        }
        else if(flexomenter.value >= 1000)
        {
            ChangePoseButton.SetActive(true);
            PoseButton.interactable = false;
        }

    }

    public void PosingButtonPressed(bool pressed)
    {
        isPressed = pressed;
    }

    public void ChangePose()
    {
        flexomenter.value = 0;
        progressBar.value += increaseAmount;
        PoseButton.interactable = true;
        ChangePoseButton.SetActive(false);

    }

    public void FinishPosing()
    {

    }

}
