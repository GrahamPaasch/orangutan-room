using UnityEngine;

public class OrangutanBehaviour : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] idleSounds;

    [SerializeField]
    private AudioClip yawnClip;

    [SerializeField]
    private AudioClip shiftClip;

    [SerializeField]
    private Animator animator;

    private AudioSource audioSource;
    private float nextActionTime;

    [SerializeField]
    public float ActionInterval = 5f;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.spatialBlend = 1f;
            audioSource.rolloffMode = AudioRolloffMode.Logarithmic;
        }
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
        if (animator == null)
        {
            return;
        }

        int index = Random.Range(0, idleSounds.Length + 2);
        switch (index)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                if (index < idleSounds.Length)
                {
                    audioSource.PlayOneShot(idleSounds[index]);
                }
                animator.SetTrigger("Idle" + index);
                break;
            case 4:
                if (yawnClip != null)
                {
                    audioSource.PlayOneShot(yawnClip);
                }
                animator.SetTrigger("Yawn");
                break;
            default:
                if (shiftClip != null)
                {
                    audioSource.PlayOneShot(shiftClip);
                }
                animator.SetTrigger("Shift");
                break;
        }
    }
}
