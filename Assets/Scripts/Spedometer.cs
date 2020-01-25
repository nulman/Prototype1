using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spedometer : MonoBehaviour
{
    private PlayerController player;
    private Slider spedometer;
    private Color lowColor = Color.black;
    private Color highColor = Color.yellow;
    private Image Fill;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerController.instace;
        spedometer = gameObject.GetComponent<Slider>();
        Fill = gameObject.GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            player = PlayerController.instace;
        }
        spedometer.value = player.accel;
        Fill.color = Color.Lerp(lowColor, highColor, spedometer.value/spedometer.maxValue);
    }
}
