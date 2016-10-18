using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


    private GameObject[] woolpies;
    private GameObject[] players;
    private int playerCount;
    private ActivatingPoint[] points;
    public GameObject startButton;
    public GameObject[] UI;

    void Start()
    {
        Cursor.visible = false;
        points = GameObject.FindGameObjectWithTag("World").GetComponentsInChildren<ActivatingPoint>();
        foreach (ActivatingPoint point in points)
        {
            point.disablePoint();
        
        }

    }

	// Update is called once per frame
	void Update () {
        players = GameObject.FindGameObjectsWithTag("Player");
        playerCount = 0;

        foreach (GameObject player in players)   //how many players are on the activating point?
        {
            if (Mathf.Abs(player.transform.position.x - startButton.transform.position.x) < startButton.transform.lossyScale.x / 2f &&
                Mathf.Abs(player.transform.position.y - startButton.transform.position.y) < startButton.transform.lossyScale.y / 2f)
            {
                playerCount++;
            }

        }
        if (playerCount >= 2)
        {
            foreach (GameObject uiElement in UI)
            {
                uiElement.GetComponent<SpriteRenderer>().enabled = false;
            }
            foreach (ActivatingPoint point in points)
            {
                point.enablePoint();

            }
        }
        



        woolpies = GameObject.FindGameObjectsWithTag("Woolpy");

        if (woolpies.Length == 0)
        {
            reloadGame();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            reloadGame();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Vector3 position = GameObject.FindGameObjectWithTag("World").transform.position;
            GameObject.FindGameObjectWithTag("World").transform.position = new Vector3(position.x - 3840, position.y, position.z);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Vector3 position = GameObject.FindGameObjectWithTag("World").transform.position;
            GameObject.FindGameObjectWithTag("World").transform.position = new Vector3(position.x + 3840, position.y, position.z);
        }
    }

    private void reloadGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
