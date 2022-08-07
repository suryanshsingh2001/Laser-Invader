using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projetileSpeed = 10f;
    [SerializeField] float projetileLifetime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;


    [HideInInspector] public bool isFiring;

    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;
    
    
    
    
    
    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }

   
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine==null)
        {
            firingCoroutine=StartCoroutine(FireCountinuosly());
        }
        else if(!isFiring && firingCoroutine!= null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireCountinuosly()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();

            if (rb != null) 
            {
                rb.velocity = transform.up * projetileSpeed;
            }
            


            Destroy(instance,projetileLifetime);
            float TimeToNextProjectile = Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);
            TimeToNextProjectile = Mathf.Clamp(TimeToNextProjectile, minimumFiringRate, float.MaxValue);


            audioPlayer.PlayShootingClip();
            
            yield return new WaitForSeconds(TimeToNextProjectile);
        }
    }
}
