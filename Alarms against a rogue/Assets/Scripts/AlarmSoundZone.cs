using UnityEngine;

public class AlarmSoundZone : MonoBehaviour
{
    [SerializeField] private AlarmSound _alarmSound;
    
    private void OnTriggerEnter(Collider other)
    {
        _alarmSound.FadeVolumeUp();
    }
    
    private void OnTriggerExit(Collider other)
    {
        _alarmSound.FadeVolumeDown();
    }
}
