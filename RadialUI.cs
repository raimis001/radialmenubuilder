using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class RadialUI : MonoBehaviour
{
	[Range(1,20)]
	public int count;
	[Range(0,1)]
	public float space = 0;
	public bool update;

	private void Update()
	{
		if (Application.isPlaying || !update)
			return;

		Redraw();
	}

	private void Redraw()
	{
		List<Transform> chids = new List<Transform>();
		for (int i = 1; i < transform.childCount; i++)
			chids.Add(transform.GetChild(i));

		foreach (Transform t in chids)
			DestroyImmediate(t.gameObject);

		for (int i = 1; i < count; i++)
			Instantiate(transform.GetChild(0), transform);

		float rad = (1f / count) * (1f - space);
		float grad = 360f / count;
		for (int i = 0; i < count; i++)
		{
			Image image = transform.GetChild(i).GetComponent<Image>();
			image.fillAmount = rad;
			Vector3 euler = image.transform.eulerAngles;
			euler.z = i * grad;
			image.transform.eulerAngles = euler;
		}
	}
}
