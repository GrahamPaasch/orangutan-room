using UnityEngine;
using UnityEngine.UI;

public class SessionController : MonoBehaviour
{
    [SerializeField]
    private SessionRecorder recorder;

    [SerializeField]
    private float sessionLength = 60f;

    [SerializeField]
    private Button startButton;

    [SerializeField]
    private Button stopButton;

    private float startTime;
    private bool running;

    private void OnEnable()
    {
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartSession);
        }

        if (stopButton != null)
        {
            stopButton.onClick.AddListener(StopSession);
        }
    }

    private void OnDisable()
    {
        if (startButton != null)
        {
            startButton.onClick.RemoveListener(StartSession);
        }

        if (stopButton != null)
        {
            stopButton.onClick.RemoveListener(StopSession);
        }
    }

    private void Update()
    {
        if (running && Time.time - startTime >= sessionLength)
        {
            StopSession();
        }
    }

    public void StartSession()
    {
        if (recorder == null || running)
        {
            return;
        }

        startTime = Time.time;
        running = true;
        recorder.StartRecording();
    }

    public void StopSession()
    {
        if (recorder == null || !running)
        {
            return;
        }

        running = false;
        recorder.StopRecording();
    }
}
