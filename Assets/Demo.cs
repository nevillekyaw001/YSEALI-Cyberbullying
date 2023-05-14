using GG.Infrastructure.Utils.Swipe;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    [SerializeField] private SwipeListener swipeListener;

    // Start is called before the first frame update
    void OnEnable()
    {
        swipeListener.OnSwipe.AddListener(OnSwipe);
    }

    private void OnSwipe(string swipe)
    {
        Debug.Log(swipe);
    }
    void OnDisable()
    {
        swipeListener.OnSwipe.RemoveListener(OnSwipe);
    }

}
