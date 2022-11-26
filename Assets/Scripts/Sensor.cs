using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sensor : MonoBehaviour
{
    public UnityAction MotionDetected;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        MotionDetected?.Invoke();
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        MotionDetected?.Invoke();
    }
}
