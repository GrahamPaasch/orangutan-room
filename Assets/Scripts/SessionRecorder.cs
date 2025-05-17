using System;
using System.IO;
using UnityEngine;

public class SessionRecorder : MonoBehaviour
{
    [SerializeField]
    private int sampleRate = 44100;

    private AudioClip recording;
    private string filePath;
    private float startTime;

    public void StartRecording()
    {
        recording = Microphone.Start(null, false, 300, sampleRate);
        filePath = Path.Combine(Application.persistentDataPath, GetTimestamp() + ".wav");
        startTime = Time.time;
    }

    public void StopRecording()
    {
        if (recording == null)
        {
            return;
        }

        Microphone.End(null);
        float duration = Time.time - startTime;
        SaveRecording();
        SaveMetrics(duration, recording.length);
    }

    private void SaveRecording()
    {
        Directory.CreateDirectory(Application.persistentDataPath);
        var data = new float[recording.samples * recording.channels];
        recording.GetData(data, 0);
        var bytes = ConvertToWav(data, recording.channels, recording.frequency);
        File.WriteAllBytes(filePath, bytes);
    }

    private void SaveMetrics(float duration, float audioLength)
    {
        var metrics = new SessionMetrics
        {
            Duration = duration,
            AudioLength = audioLength
        };
        var json = JsonUtility.ToJson(metrics, true);
        File.WriteAllText(Path.ChangeExtension(filePath, ".json"), json);
    }

    private static string GetTimestamp()
    {
        return DateTime.Now.ToString("yyyyMMdd_HHmmss");
    }

    private static byte[] ConvertToWav(float[] samples, int channels, int hz)
    {
        MemoryStream stream = new MemoryStream();
        int sampleCount = samples.Length;
        int byteRate = hz * channels * 2;
        int blockAlign = channels * 2;
        // RIFF header
        using (BinaryWriter writer = new BinaryWriter(stream))
        {
            writer.Write(System.Text.Encoding.UTF8.GetBytes("RIFF"));
            writer.Write(36 + sampleCount * 2);
            writer.Write(System.Text.Encoding.UTF8.GetBytes("WAVE"));
            writer.Write(System.Text.Encoding.UTF8.GetBytes("fmt "));
            writer.Write(16);
            writer.Write((short)1);
            writer.Write((short)channels);
            writer.Write(hz);
            writer.Write(byteRate);
            writer.Write((short)blockAlign);
            writer.Write((short)16);
            writer.Write(System.Text.Encoding.UTF8.GetBytes("data"));
            writer.Write(sampleCount * 2);
            foreach (var sample in samples)
            {
                short intSample = (short)(Mathf.Clamp(sample, -1f, 1f) * short.MaxValue);
                writer.Write(intSample);
            }
        }
        return stream.ToArray();
    }

    [Serializable]
    private class SessionMetrics
    {
        public float Duration;
        public float AudioLength;
    }
}
