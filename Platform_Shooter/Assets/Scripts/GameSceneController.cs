using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    [SerializeField]
    PlayerController player;
    [SerializeField]
    Camera gameCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameCam.transform.position = new Vector3 (Mathf.Lerp(gameCam.transform.position.x, player.transform.position.x,0.5f), player.transform.position.y, gameCam.transform.position.z);
    }
}
