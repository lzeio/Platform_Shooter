using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if(player)
        {
            gameCam.transform.position = new Vector3(Mathf.Lerp(gameCam.transform.position.x, player.transform.position.x, 0.5f), player.transform.position.y, gameCam.transform.position.z);
 
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
