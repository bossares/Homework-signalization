using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signalization : MonoBehaviour
{
    [SerializeField] private float _volumeToggleStep = 0.1f;
    [SerializeField] private float _toggleVolumeStepTime = 1f;
    [SerializeField] private Sensor _sensor;

    private Coroutine _toggleVolumePrevious = null;
    private AudioSource _audioSource;
    private float _minValue = 0;
    private float _maxValue = 1;
    private float _targetValue;

    private void OnValidate()
    {
        if (_sensor == null)
            throw new ArgumentNullException("Sensor");
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _targetValue = _maxValue;
    }

    private void OnEnable()
    {
        _sensor.MotionDetected += OnMotionDetected;
    }

    private void OnDisable()
    {
        _sensor.MotionDetected -= OnMotionDetected;
    }

    private void OnMotionDetected()
    {
        if (_toggleVolumePrevious != null)
        {
            StopCoroutine(_toggleVolumePrevious);

            if (_targetValue == _maxValue)
                _targetValue = _minValue;
            else
                _targetValue = _maxValue;
        }

        _toggleVolumePrevious = StartCoroutine(ToggleVolume());
    }

    private IEnumerator ToggleVolume()
    {
        WaitForSeconds waitTime = new WaitForSeconds(_toggleVolumeStepTime);

        while (_audioSource.volume != _targetValue)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetValue, _volumeToggleStep);

            yield return waitTime;
        }
    }
}
