using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Studying : MonoBehaviour
{   Camera m_camera;
    public GameObject brush;
     GameObject[] brushes;
    GameObject[] numberOfBrushes;
    [SerializeField] int numberlines;
    public GameObject studying;
    public GameObject nextDialogue;
    public Slider progressBar;
    float conversionfloat;

    LineRenderer currentLineRenderer;

    Vector2 lastPos;

    private void Start()
    {
        m_camera = Camera.main;
        AudioManager.instance.Play(1);
    }
    private void Update()
    {
        Drawing();
        numberOfBrushes = GameObject.FindGameObjectsWithTag("Brush");

        progressBar.value = numberOfBrushes.Length;

        if(progressBar.value >= numberlines)
        {
            FinishStudying();
        }
    }

    public void Drawing()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CreateBrush();
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            PointToMousePos();
        }
        else
        {
            currentLineRenderer = null;
        }
    }

    void CreateBrush()
    {
        GameObject brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();

        //because you gotta have 2 points to start a line renderer, 
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);

        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);

    }

    void AddAPoint(Vector2 pointPos)
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }

    void PointToMousePos()
    {
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        if (lastPos != mousePos)
        {
            AddAPoint(mousePos);
            lastPos = mousePos;
        }
    }

    void FinishStudying()
    {
        
        brushes = GameObject.FindGameObjectsWithTag("Brush");
        for (int i = 0; i < brushes.Length; i++)
        {
            Destroy(brushes[i].gameObject);
        }
        if (nextDialogue)
        {
            nextDialogue.SetActive(true);
        }

        if (studying)
        {
            studying.SetActive(false);
        }
    }


}
