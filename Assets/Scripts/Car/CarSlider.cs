using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CarSlider : MonoBehaviour {
  public Slider slider;
  public Image fill;

  public float duration = 100;
  float progress;

  void Start() {
    slider.value = 1;
  }

  void Update() {
    slider.value = Mathf.MoveTowards(slider.value, 0, Time.deltaTime / duration);
    fill.color = new Color(1-slider.value, slider.value, 0);

    if(slider.value == 0) Destroy(gameObject);
  }

  void OnDisable() {
    slider.enabled = false;
    slider.gameObject.SetActive(false);
  }
}
