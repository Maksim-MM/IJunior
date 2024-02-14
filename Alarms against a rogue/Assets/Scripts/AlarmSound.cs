using System.Collections;
using UnityEngine;

public class AlarmSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _maxVolume = 1f; 
    private float _minVolume = 0f;
    private float _volumeStep = 0.25f;
    
    private void Start()
    {
        _audioSource.volume = 0f;
    }
    
    private IEnumerator ChangeVolume(float level)
    {
        while (_audioSource.volume != level)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, level, _volumeStep * Time.deltaTime);
            yield return null;
        }
    }

    public void FadeVolumeUp()
    {
        _audioSource.Play();
        StartCoroutine(ChangeVolume(_maxVolume));
    }
    
    public void FadeVolumeDown()
    {
        StartCoroutine(ChangeVolume(_minVolume));
        if (_audioSource.volume == 0f) _audioSource.Stop();
    }
}
