using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public Transform player;              // Referensi ke Transform Player
    public GameObject groundPrefab;   // Prefab untuk background
    public float backgroundWidth = 30f;   // Lebar background
    public float spawnDistance = 33f;     // Jarak trigger untuk spawn background

    private GameObject[] backgrounds = new GameObject[2]; // Menyimpan 2 background aktif
    private int currentIndex = 0;         // Indeks background yang akan di-loop
    private float nextSpawnX;             // Posisi x untuk spawn background berikutnya

    void Start()
    {
        // Spawn dua background awal
        for (int i = 0; i < backgrounds.Length; i++)
        {
            Vector3 spawnPosition = new Vector3(i * backgroundWidth, -4, transform.position.z);
            backgrounds[i] = Instantiate(groundPrefab, spawnPosition, Quaternion.identity);
        }

        // Tentukan posisi spawn berikutnya
        nextSpawnX = backgrounds[1].transform.position.x + backgroundWidth;
    }

    void Update()
    {
        // Cek jika player cukup dekat dengan background terakhir untuk spawn baru
        if (player.position.x - backgrounds[currentIndex].transform.position.x >= spawnDistance)
        {
            RepositionBackground();
        }
    }

    void RepositionBackground()
    {
        // Reposisi background yang lama ke posisi berikutnya
        GameObject bgToMove = backgrounds[currentIndex];
        bgToMove.transform.position = new Vector3(nextSpawnX, -4, transform.position.z);

        // Update indeks dan posisi spawn berikutnya
        currentIndex = (currentIndex + 1) % backgrounds.Length;
        nextSpawnX += backgroundWidth;
    }
}
