using TMPro;
using UnityEngine;

namespace Utils {
public class FPS : MonoBehaviour {
	public TMP_Text fpsText;
	private float t;
	private float avg;
	private int c;

	private void Update() {
		if (t > Time.time) {
			c++;
			avg += 1f / Time.deltaTime;
			return;
		}

		fpsText.text = "FPS: " + Mathf.Round(avg / c);
		t = Time.time + 0.5f;
		avg = 0;
		c = 0;
	}
}
}