using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineDrawer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector2 mousePos;
    private int linesCount = 0;
    private bool initClick = false;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (initClick)
        {
            RenderLine();
        }
    }

    public void DestroyLine()
    {
        linesCount = 0;
        lineRenderer.positionCount = linesCount;
        initClick = false;
    }

    public void StartLineRender(bool click, Vector2 buttonPos)
    {
        if (!click && !initClick)
        {
            return;
        }

        buttonPos = Camera.main.ScreenToWorldPoint(buttonPos);

        if (!initClick)
        {
            lineRenderer.positionCount = 2;
        }

        lineRenderer.SetPosition(linesCount, new Vector3(buttonPos.x, buttonPos.y, 0f));
        linesCount++;
        lineRenderer.positionCount = linesCount + 1;
        initClick = true;
    }

    public void RenderLine()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lineRenderer.SetPosition(linesCount, new Vector3(mousePos.x, mousePos.y, 0f));
    }
}
