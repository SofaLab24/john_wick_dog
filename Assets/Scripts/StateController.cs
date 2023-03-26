using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class StateController : MonoBehaviour
{
    [SerializeField] private GameObject dogState;

    [SerializeField] private GameObject johnState;
    public CinemachineVirtualCamera playerCam;
    private bool firstJohn;

    public bool isJohn = false;

    private PlayerStats stats;
    public CameraMovement cameraMovement;
    
    private Movement dogMovement;
    private Movement johnMovement;

    private Vector3 position;

    public GameObject dog, john;

    private SoundManager soundManager;
    public List<AudioClip> dogMusic;
    public List<AudioClip> johnMusic;

    public PlayableDirector transformationTimeline;
    private Vector3 betweenTransformPosition;

    void Awake()
    {
        stats = GetComponent<PlayerStats>();
        soundManager = GetComponent<SoundManager>();
        isJohn = false;
        firstJohn = true;
        playerCam.Follow = dogState.transform;
        soundManager.Play2Music(dogMusic[0], dogMusic[1]);

        //SpawnDog(Vector3.zero);
    }

    void SpawnDog(Vector3 position)
    {
        dogState = Instantiate(dog, position, quaternion.identity);
        playerCam.Follow = dogState.transform;
        
        soundManager.Play2Music(dogMusic[0], dogMusic[1]);
    }
    
    void SpawnJohn(Vector3 position)
    {
        johnState = Instantiate(john, position, quaternion.identity);
        playerCam.Follow = johnState.transform;
        soundManager.Play2Music(johnMusic[0], johnMusic[1]);
    }


    public void FinishTransformation()
    {
        johnState.transform.position = new Vector3(betweenTransformPosition.x, 1, betweenTransformPosition.z);
        
        playerCam.Follow = johnState.transform;
        dogMovement.enabled = true;
        johnMovement.enabled = true;
        dogState.SetActive(false);
        ChangeAllStats(true);
        Destroy(dogState);

    }
    public void ChangeToJohn()
    {
        if (firstJohn)
        {
            dogMovement = dogState.GetComponent<Movement>();
            dogMovement.enabled = false;
            firstJohn = false; // a shit ton of extra rewriting required to enable it more than once, fuck that
            betweenTransformPosition = dogState.transform.position;
            johnState.transform.position = betweenTransformPosition;
            johnState.SetActive(true);
            johnMovement = johnState.GetComponent<Movement>();
            johnMovement.enabled = false;
            soundManager.Play2Music(johnMusic[0], johnMusic[1]);
            transformationTimeline.Play();

            //dogState.SetActive(false);
        }
        else
        {
            firstJohn = false;
            position = dogState.transform.position;
            SpawnJohn(position);
            dogState.SetActive(false);
            ChangeAllStats(true);
            Destroy(dogState);
        }

    }
    public void ChangeToDog()
    {
       // StartCoroutine(stopMovementDog());
        position = johnState.transform.position;
        SpawnDog(position);
        johnState.SetActive(false);
        
        //=========
        // dogState.SetActive(true);
        // dogState.gameObject.transform.position = position;
        // johnState.SetActive(false);
        //=========
        ChangeAllStats(false);
        cameraMovement.FindPlayer();
        Destroy(johnState);
    }

    IEnumerator stopMovementJohn()
    {
        johnState.gameObject.GetComponent<Movement>().enabled = false;
        yield return new WaitForSeconds(1f);
        johnState.gameObject.GetComponent<Movement>().enabled = true;
    }
    
    IEnumerator stopMovementDog()
    {
        dogState.gameObject.GetComponent<Movement>().enabled = false;
        yield return new WaitForSeconds(1f);
        dogState.gameObject.GetComponent<Movement>().enabled = true;
    }

    void ChangeAllStats(bool isJohn)
    {
        if (isJohn)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in enemies)
            {
                enemy.GetComponent<EnemyMovement>().target = johnState.transform;
            }
        }
        else
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in enemies)
            {
                enemy.GetComponent<EnemyMovement>().target = dogState.transform;
            }
        }
        
    }
}
