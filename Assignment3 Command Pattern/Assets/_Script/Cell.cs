using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Cell : MonoBehaviour
{
    public Renderer rend;
    public Color aliveColor;
    public Color deadColor;
    MeshRenderer meshRenderer;

    public int x, y, neighbors, state;

    private void Start()
    {
        rend = gameObject.GetComponentInChildren<Renderer>();
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        UpdateColor();
    }

    public void UpdateColor()
    {
        if (state == 1)
        {
            //rend.material.color = aliveColor;
            meshRenderer.enabled = false;
        }
        else
        {
            meshRenderer.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && state == 1)
        {
            Debug.Log("Player On the Wrong Way! ");

        }
    }
}
