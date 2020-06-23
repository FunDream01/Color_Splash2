using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public Gradient LineColor;
    public GameObject linePrefab;
    public GameObject currentLine;
    public GameObject parent;

    private GameObject DrawingTut;
    private GameObject DropButton;

    [HideInInspector]
    public LineRenderer lineRenderer;

    public EdgeCollider2D edgeCollider;
    [HideInInspector]
    public List<Vector2> fingerPositions;

    public Sprite DropTutorial;
    public SpriteRenderer Overlay;
    private void Start()
    {
        DrawingTut = GameObject.FindGameObjectWithTag(Tags.DrawingTut);
        DropButton = GameObject.FindGameObjectWithTag(Tags.DropButton);

        DropButton.SetActive(false);
    }
    public bool tutorial;
    public bool freeze;

    public GameObject[] Slidings;
    public GameObject HandDrop;
    // Update is called once per frame
    void Update()
    {
        if (freeze) return;
        if (Input.GetMouseButtonDown(0))
        {
            if (!tutorial)
            {
                if (DrawingTut.activeSelf == true)
                {
                    DrawingTut.SetActive(false);
                    Invoke("DropButtonActive", SpawnerManager.Instance.DropButtonActivate);
                }
            }

            creatLine();

        }
        if (Input.GetMouseButton(0))
        {
            Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(tempFingerPos, fingerPositions[fingerPositions.Count - 1]) > .1f)
            {
                UpdateLine(tempFingerPos);
            }
        }
        if (Input.GetMouseButtonUp(0) && tutorial)
        {

            if (parent.transform.childCount == 1)
            {
                Slidings[1].SetActive(true);
                Slidings[2].SetActive(false);
            }

            if (parent.transform.childCount >= 2)
            {
                if (DrawingTut.activeSelf == true)
                {
                    DrawingTut.SetActive(false);
                    DropButtonActive();
                    Overlay.sprite = DropTutorial;
                    tutorial = false;
                    freeze = true;
                    HandDrop.SetActive(true);
                    foreach (GameObject s in Slidings)
                    {
                        s.SetActive(false);
                    }
                }
            }
        }

    }

    void creatLine()
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);

        lineRenderer = currentLine.GetComponent<LineRenderer>();
        lineRenderer.colorGradient = LineColor;
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
        fingerPositions.Clear();
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0, fingerPositions[0]);
        lineRenderer.SetPosition(1, fingerPositions[1]);
        edgeCollider.points = fingerPositions.ToArray();
        currentLine.transform.parent = parent.transform;
    }

    void UpdateLine(Vector2 newFingerPos)
    {
        fingerPositions.Add(newFingerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPos);
        edgeCollider.points = fingerPositions.ToArray();
        currentLine.transform.parent = parent.transform;

    }
    public void ClearLines()
    {
        foreach (Transform child in parent.transform)
        {
            Destroy(child.gameObject);
        }
    }
    void DropButtonActive()
    {
        DropButton.SetActive(true);
    }
}

