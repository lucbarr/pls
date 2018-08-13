using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
  public int score = 45;
  public Text scoreText;
  public Text bustedText;

  void Update () {
    scoreText.text = "score: " + (score/10f);
    if (score <= 0) {
      score = 0;
      bustedText.text = "SE FUDEU";
    }
  }

  public void CarHit() {
    score -= 1;
  }
}
