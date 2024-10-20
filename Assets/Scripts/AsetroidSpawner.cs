using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsetroidSpawner : MonoBehaviour
{

    [SerializeField] private GameObject asetroid;
    [SerializeField] private float spawnDuration;
    private float timeHolder;
    [SerializeField] private float amplitude;
    [SerializeField] private float speed;

    [SerializeField] private float hardModeTimer;
    [SerializeField] private float hSpawnDuration;
    [SerializeField] private bool hardMode;

    // Start is called before the first frame update
    void Start()
    {
        hardMode = false;
        timeHolder = spawnDuration;
    }

    // Update is called once per frame
    void Update()
    {

        if (!hardMode) 
        hardModeTimer -= Time.deltaTime;


        if (hardModeTimer <= 0)
        {
            hardMode = true;
            timeHolder = hSpawnDuration;
        }


        float sin = Mathf.Sin(Time.time * speed) * amplitude;

        transform.position = new Vector2(transform.position.x, sin);

        spawnDuration -= Time.deltaTime;
        if (spawnDuration <= 0)
        {
            StartCoroutine(SpawnAsetroid());
            if (timeHolder < hSpawnDuration) timeHolder = hSpawnDuration;
            spawnDuration = timeHolder;

        }

    }

    IEnumerator SpawnAsetroid()
    {
        yield return new WaitForSeconds(timeHolder);
        Instantiate(asetroid, transform.position, Quaternion.identity);


    }

    IEnumerator MakeGameHarder()
    {
        yield return new WaitForSeconds(timeHolder);
    }
}
