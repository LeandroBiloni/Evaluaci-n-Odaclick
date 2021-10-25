using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UITimeController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeText;
    
    // Start is called before the first frame update
    void Start()
    {
        _timeText.text = "Time: ";
        GameManager.Instance.OnTimeUpdateEvent += UpdateTime;
    }

    public void UpdateTime(float time)
    {
        if (time <= 30)
            _timeText.color = Color.red;
                
        _timeText.text = "Time: " + Mathf.FloorToInt(time);
    }
}
