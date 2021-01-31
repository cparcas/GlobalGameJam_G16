using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float TotalTime = 300;

    private float m_RemainingTime;
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private float timePerItem;

    public bool canChange;

    public bool lessTime;
    public GameObject player;
    public Vector3 spawner;

    // Use this for initialization
    void Start()
    {
        text.text = changeTime(TotalTime);
        m_RemainingTime = TotalTime;
        spawner = player.transform.position;
    }

    void OnEnable()
    {
        // Al activarlo reseteamos el tiempo total que dura el powerup
        //text.text = changeTime(TotalTime);
        //m_RemainingTime = TotalTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!lessTime)
        {
            m_RemainingTime -= 10.0f;
            lessTime = !lessTime;
        }
        m_RemainingTime -= Time.deltaTime;
        text.text = changeTime(m_RemainingTime);
        if (m_RemainingTime <= 0) //you can't have negative time less // you've lost
        {
            m_RemainingTime = 180;
            player.transform.position = spawner;

        }
    }
    public String changeTime(float time)
    {

        int secs = (int)time % 60;
        int minut = (int)time / 60;
        return string.Format("{0}:{1}", minut.ToString("00"), secs.ToString("00"));
    }

    public void moreTime()
    {

        m_RemainingTime += timePerItem;
        text.text = changeTime(m_RemainingTime);
    }
}