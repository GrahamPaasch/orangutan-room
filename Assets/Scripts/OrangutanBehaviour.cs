using UnityEngine;

public class OrangutanBehaviour : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] idleSounds;

    [SerializeField]
    private Animator animator;

    private AudioSource audioSource;
    private float nextActionTime;
    private const float ActionInterval = 5f;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        ScheduleNextAction();
    }

    private void Update()
    {
        if (Time.time >= nextActionTime)
        {
            PlayRandomIdle();
            ScheduleNextAction();
        }
    }

    private void ScheduleNextAction()
    {
        nextActionTime = Time.time + ActionInterval;
    }

    private void PlayRandomIdle()
    {
        if (idleSounds.Length == 0 || animator == null)
        {
            return;
        }

        int index = Random.Range(0, idleSounds.Length);
        audioSource.PlayOneShot(idleSounds[index]);
        animator.SetTrigger("Idle" + index);
    }
}
