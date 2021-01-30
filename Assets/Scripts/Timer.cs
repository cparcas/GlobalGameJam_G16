using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public float TotalTime;

	private float m_RemainingTime;
	[SerializeField]
	private TextMeshProUGUI text;

	[SerializeField]
	private float timePerItem;

	public bool canChange;

	public bool inciarContador;

	// Use this for initialization
	void Start()
	{
	
	}

	void OnEnable()
	{
		// Al activarlo reseteamos el tiempo total que dura el powerup
		text.text = changeTime(TotalTime);
		m_RemainingTime = TotalTime;
	}

	// Update is called once per frame
	void Update()
	{
		// TODO 1 - Comprobamos si se ha acabado el tiempo
		if (m_RemainingTime <= 0)
		{
			canChange = false;
		}
		else
		{
			if (inciarContador && canChange)
			{
				// TODO 5 - Restamos al tiempo restante el tiempo que ha pasado
				m_RemainingTime -= Time.deltaTime;
				text.text = changeTime(m_RemainingTime);
			}

		}
	}
	public String changeTime(float time) {

		int secs = (int) time % 60;
		int minut = (int) time / 60;
		return string.Format("{0}:{1}", minut, secs);
	}

	public void moreTime() {

		m_RemainingTime += timePerItem;
		text.text = changeTime(m_RemainingTime);
	}
}
