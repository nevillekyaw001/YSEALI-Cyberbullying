using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Thought : MonoBehaviour
{
    [SerializeField] int numbersToClick;
    int clickAmount = 0;

    private void OnMouseDown()
    {
        if(clickAmount==numbersToClick)
        {
            GameObject.FindAnyObjectByType<PoppingThought>().AddValueToProgressBar(1);
            Destroy(gameObject);
        }
        else
        {
            clickAmount++;
        }
    }
}
