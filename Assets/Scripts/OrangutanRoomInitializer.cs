using UnityEngine;

public class OrangutanRoomInitializer : MonoBehaviour
{
    [SerializeField]
    private GameObject orangutanPrefab;

    [SerializeField]
    private Transform playerRig;

    [SerializeField]
    private Vector3 orangutanPosition = new Vector3(0f, 0f, 2f);

    [SerializeField]
    private float orangutanScale = 2f;

    private void Start()
    {
        SpawnOrangutan();
        PositionPlayer();
    }

    private void SpawnOrangutan()
    {
        if (orangutanPrefab == null)
        {
            return;
        }

        GameObject orangutan = Instantiate(orangutanPrefab, orangutanPosition, Quaternion.identity);
        orangutan.transform.localScale = Vector3.one * orangutanScale;
    }

    private void PositionPlayer()
    {
        if (playerRig == null)
        {
            return;
        }

        playerRig.position = Vector3.zero;
        playerRig.rotation = Quaternion.identity;
    }
}
