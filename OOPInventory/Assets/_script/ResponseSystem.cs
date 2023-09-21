using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResponseSystem : MonoBehaviour, IObserver
{
    
    [SerializeField] Subject subject;
    protected int Score = 0;
    public TextMeshProUGUI ScoreText;

    void Start()
    {
        foreach (Subject subject in FindObjectsOfType<Subject>())
        {
            subject.AddObserver(this);
        }
    }
    void Update()
    {
        ScoreText.text = Score.ToString();
    }

    public void OnNotify(Actions action)
    {
        switch (action)
        {
            case (Actions.getFlower):
                Score += Flower.point;
                Debug.Log(Score);
                return;
        }
    }

    //public void OnEnable()
    //{
    //    subject.AddObserver(this);
    //}

    //public void OnDisable()
    //{
    //    subject.RemoveObserver(this);
    //}
    
    
}
