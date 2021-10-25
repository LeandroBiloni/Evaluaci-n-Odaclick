using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIProgressBarController : MonoBehaviour
{
    [SerializeField] private Image _pointsProgressBar;
    [SerializeField] private TextMeshProUGUI _pointsText;
    // Start is called before the first frame update
    void Start()
    {
        _pointsProgressBar.fillAmount = 0;
        GameManager.Instance.OnPointsUpdateEvent += UpdateBar;
    }


    private void UpdateBar(int current, int max)
    {
        float p = current / (float)max;
        
        if (p < 0)
            _pointsText.color = Color.red;
        else if (p < 0.75f)
            _pointsText.color = Color.white;
        else _pointsText.color = Color.green;
        
        _pointsText.text = "Points: " + current;
        
        _pointsProgressBar.fillAmount = p;
    }
}
