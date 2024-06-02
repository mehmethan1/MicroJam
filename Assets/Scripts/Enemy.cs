using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public ParticleSystem explosion;

    public float detectionRange = 10f; // Algılama mesafesi
    public string playerTag = "Player"; // Oyuncu etiketi

    private Transform target; // Hedef oyuncu
    private bool isTargetPlayer1; // Düşmanın hedefi oyuncu 1 mi?
    private CameraShake cameraShake;
    private GameManager gamemanager;
    void Start()
    {
        // Başlangıçta herhangi bir oyuncuya hedeflenmemiş
        target = null;
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    void Update()
    {
        // Yakındaki oyuncuyu kontrol et
        CheckClosestPlayer();

        // Hedef oyuncu varsa ona doğru hareket et
        if (target != null)
        {
            MoveTowardsTarget();
        }
    }

    void CheckClosestPlayer()
    {
        // Tüm oyuncuları bul
        GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);

        // En yakın oyuncuyu bulmak için varsayılan bir mesafe belirleyin
        float closestDistance = detectionRange + 1f;

        // En yakın oyuncuyu bul
        foreach (GameObject player in players)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer < closestDistance)
            {
                // Eğer bu oyuncu, diğerine daha yakınsa hedef olarak belirle
                closestDistance = distanceToPlayer;
                target = player.transform;
                // Hedef oyuncu 1 ise isTargetPlayer1'i true yap, değilse false yap
                isTargetPlayer1 = player.tag == "Player1";
            }
        }

        // Eğer hedef oyuncu varsa ve artık hedef oyuncu yakınlık aralığının dışındaysa hedefi null yap
        if (target != null && closestDistance > detectionRange)
        {
            target = null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Deneme");
        }
        if (collision.CompareTag("Line"))
        {
            Debug.Log("Öldü");
            ParticleSystem a = Instantiate(explosion, this.transform.position, Quaternion.identity);
            a.Play();
            Destroy(this.gameObject);
            cameraShake.ShakeCamera();
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.EnemyKilled();
            }
        }
    }

    void MoveTowardsTarget()
    {
        // Hedef oyuncunun yönüne doğru hareket et
        Vector3 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        // Hedef oyuncu değişirse, düşmanın yönünü güncelle
        if ((isTargetPlayer1 && target.tag != "Player1") || (!isTargetPlayer1 && target.tag != "Player2"))
        {
            CheckClosestPlayer();
        }
    }
}
