using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResponseSystem : Collections, IObserver
{
    
    [SerializeField] Subject subject;
    protected int Score = 0;
    protected int Life = 3;
    protected string notification;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI LifeText;
    public TextMeshProUGUI NotificationText;

    public AudioSource collectSound;
    void Start()
    {
        foreach (Subject subject in FindObjectsOfType<Subject>())
        {
            subject.AddObserver(this);
        }
    }
    void Update()
    {
        ScoreText.text = "Score: " + Score.ToString();
        LifeText.text = "Life: " + Life.ToString();
        NotificationText.text = notification;
    }

    public void OnNotify(Actions action)
    {
        switch (action)
        {
            case (Actions.getFlower):
                collectSound.Play();
                Score += Flower.point;
                notification = "You Collected a flower! +5 Points";
                return;
            case(Actions.getTrash):
                Life += Trash.life;
                notification = "That's Trash! You lost 1 life!";
                return;
            case (Actions.getStar):
                Life += Star.life;
                Score += Star.point;
                notification = "Nice Job! That's the only star in this game! +10 Points, +1 life";
                return;
        }
    }
    
}
