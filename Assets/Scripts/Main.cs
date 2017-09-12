using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

    private List<GameObject> platformList;
    private GameObject player;
    private Vector3 playerDestination;
    private float xPosition;
    private int count;
    public Text scoreUI;
    private Color nextColor;
    /*This method setup everything for the game
     * It creates 2 platorm and set the position of each one and the speed
     * */
	void Start () {
        xPosition = 0;
        count = 0;
        MovingState.speed = 0.05f;
        platformList = new List<GameObject>();
        platformList.Add((GameObject)Instantiate(Resources.Load("Platform"),new Vector3(xPosition,0f,0f), Quaternion.identity));
        platformList[0].GetComponent<Platform>().nextState();
        player = ((GameObject)Instantiate(Resources.Load("Player"), new Vector3(xPosition, 3f, 0f), Quaternion.identity));
        xPosition += 5;
        platformList.Add((GameObject)Instantiate(Resources.Load("Platform"),new Vector3(xPosition, 0f,0f), Quaternion.identity));
        nextColor = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
    /*This method check if the player fall and check if the user touch the screen
     */
    void Update()
    {   

        player.transform.Find("PlayerCamera").GetComponent<Camera>().backgroundColor = Color.Lerp(player.transform.Find("PlayerCamera").GetComponent<Camera>().backgroundColor,nextColor, 0.5f);
        if (player.transform.Find("PlayerModel").position.y <= -2f)
        {
           int highscore = PlayerPrefs.GetInt("High Score");
           if (count > highscore)
           {
                PlayerPrefs.SetInt("High Score", count);
           }
            SceneManager.LoadScene("Menu");
        }
        if (Input.touches.Any(x => x.phase == TouchPhase.Began) || Input.GetMouseButtonDown(0))
        {
            count++;
            scoreUI.text = count.ToString();
            nextColor = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            platformList[platformList.Count-1].GetComponent<Platform>().nextState();
            player.transform.Find("PlayerModel").GetComponent<Rigidbody>().useGravity=false;
            playerDestination = new Vector3(player.transform.position.x + 5, 0f, 0f);
            if (platformList.Count - 2 >= 0)
            {
                for (int i = 0; i <= platformList.Count - 2; i++)
                {
                    if (platformList[i] != null)
                    {
                        platformList[i].GetComponent<Platform>().nextState();
                    }
                }
            }
            player.transform.Find("PlayerModel").GetComponent<Rigidbody>().useGravity = true;
            xPosition += 5;
            platformList.Add((GameObject)Instantiate(Resources.Load("Platform"), new Vector3(xPosition, 0.001f, 0f), Quaternion.identity));

        }
        player.transform.position = Vector3.MoveTowards(player.transform.position, playerDestination, 0.5f);

    }
}
