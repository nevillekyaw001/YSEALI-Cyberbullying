using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject nameText;
    public TextMeshProUGUI nameComponent;
    public TextMeshProUGUI subtitleComponent;

    public string[] names;
    public string[] lines;
    public string newName;
    public float textSpeed;
    int index;

    // Start is called before the first frame update
    void Start()
    {
        subtitleComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (names[index] == "")
        {
            nameText.SetActive(false);
        }
        else
        {
            nameText.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(subtitleComponent.text == lines[index]) 
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                subtitleComponent.text = lines[index];
            }

            if (names[index] == "") 
            {
                nameText.SetActive(false);
            }
            else
            {
                nameText.SetActive(true);
            }
        }
    }

    void StartDialogue()
    {
        index= 0;
        nameComponent.text = names[index];
        StartCoroutine(TypeLine());
    }

    private void NextLine()
    {

        if(index < lines.Length - 1) 
        {
            index++;
            subtitleComponent.text = string.Empty;
            nameComponent.text = names[index];
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator TypeLine()
    {

        foreach (char c in lines[index].ToCharArray()) 
        {
            subtitleComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
