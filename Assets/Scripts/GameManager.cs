using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Untuk mengakses fungsi SceneManager

public class GameManager : MonoBehaviour
{
    public GameObject startingText;    // Text yang muncul di awal
    public TMP_Text skorText;          // Text untuk skor
    public Transform player;           // Referensi ke Transform Player

    private float skor = 0f;           // Nilai skor awal
    private bool isGameRunning = false; // Status apakah game sedang berjalan

    void Start()
    {
        // Tampilkan teks awal dan pause game
        startingText.SetActive(true);
        Time.timeScale = 0f; // Pause game
    }

    void Update()
    {
        // Memulai game ketika tombol Space ditekan
        if (!isGameRunning && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }

        // Perbarui skor selama game berjalan
        if (isGameRunning)
        {
            UpdateScore();
        }

        // Cek kondisi kematian pemain
        CheckDeathCondition();
    }

    void StartGame()
    {
        Time.timeScale = 1f;              // Resume game
        startingText.SetActive(false);    // Sembunyikan teks awal
        isGameRunning = true;             // Tandai game dimulai
    }

    void UpdateScore()
    {
        // Tambahkan skor secara bertahap
        skor += 10 * Time.deltaTime * 10; // 10 poin per 0.1 detik
        skorText.text = "Skor: " + Mathf.FloorToInt(skor).ToString();
    }

    void CheckDeathCondition()
    {
        // Jika posisi y pemain <= -6, ulangi scene
        if (player.position.y <= -6f)
        {
            RestartGame();
        }
    }

    void RestartGame()
    {
        // Reload scene saat kematian terjadi
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
