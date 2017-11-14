using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public GameObject startTank;
    public GameObject gunnerTank;

    private Transform currentPlayer;
    private int levelToUpdate = 5;
    private bool isPlayerUpdated = false;

    private CameraController camera;
    
    void Start()
    {
        ExperienceManager.Instance.onLevelUp += OnLevelUp;
        currentPlayer = GameObject.FindWithTag("Player").transform;
        camera = Camera.main.GetComponent<CameraController>();
    }

    public Transform GetPlayer()
    {
        return currentPlayer;
    }

    void OnLevelUp(int level)
    {
        if (level >= levelToUpdate && !isPlayerUpdated)
        {
            Vector3 newPosition = currentPlayer.position;
            Quaternion newRotation = currentPlayer.rotation;
            Transform newPlayer = UpdatePlayer(newPosition, newRotation);
            currentPlayer.GetComponent<PlayerController>().DestroyPlayer();
            camera.UpdateTarget(newPlayer);
        }
    }

    Transform UpdatePlayer(Vector3 newPosition, Quaternion newRotation)
    {
        isPlayerUpdated = true;
        return  Instantiate(gunnerTank, newPosition, newRotation).transform;
    }
}
