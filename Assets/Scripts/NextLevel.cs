using UnityEngine;
using System.Collections;
using Image = UnityEngine.UI.Image;
using Text = UnityEngine.UI.Text;

public class NextLevel : MonoBehaviour {

    private GameObject[] players;
    private int playerCount;
    private GameObject world;
    public float speed = 100f;
    private float targetX;
    private bool isMoving = false;
    private bool countDown = false;

    void Start()
    {
        world = GameObject.FindGameObjectWithTag("World");
    }

    void Update () {
        if (gameObject.GetComponent<MeshRenderer>().enabled)
        {
        players = GameObject.FindGameObjectsWithTag("Player");
        playerCount = 0;

        foreach(GameObject player in players)   //how many players are on the activating point?
        {
            if (Mathf.Abs(player.transform.position.x - transform.position.x) < transform.lossyScale.x/2f &&
                Mathf.Abs(player.transform.position.y - transform.position.y) < transform.lossyScale.y/2f)
            {
                playerCount++;
            }
               
        }

        if (playerCount >= 2 && !isMoving)   //at least two players have to be on the activating point for the next level
        {
                isMoving = true;
                targetX = world.transform.position.x - 3840;

            }
            if (isMoving)

                {
                SpriteRenderer stage = new SpriteRenderer();
                if (this.name == "lvl1->lvl2")
                {
                    stage = GameObject.Find("stage2").GetComponent<SpriteRenderer>();
                }
                else if (this.name == "lvl2->lvl3")
                {
                    stage = GameObject.Find("stage3").GetComponent<SpriteRenderer>();
                }
                else if (this.name == "lvl3->lvl4")
                {
                    stage = GameObject.Find("stage4").GetComponent<SpriteRenderer>();
                }
                stage.enabled = true;
                GameObject.Find("overlay").GetComponent<Image>().enabled = true;
                moveToNextLevel();
                countDown = true;
                    
                }
        }
        if (world.transform.position.x == targetX)
        {
            isMoving = false;
            if(countDown)
            {
                StartCoroutine(startCountDown());
            }
            
            
        }
        if (isMoving)
        {
            ActivatingPoint[] points = GameObject.FindGameObjectWithTag("World").GetComponentsInChildren<ActivatingPoint>();
            foreach(ActivatingPoint point in points)
            {
                point.disablePoint();
            }
        }
        
	}

    private IEnumerator startCountDown()
    {
        
        //yield return new WaitForSeconds(1f);
        SpriteRenderer three = GameObject.Find("3").GetComponent<SpriteRenderer>();
        three.enabled = true;
        yield return new WaitForSeconds(1f);
        SpriteRenderer two = GameObject.Find("2").GetComponent<SpriteRenderer>();
        three.enabled = false;
        two.enabled = true;
        yield return new WaitForSeconds(1f);
        SpriteRenderer one = GameObject.Find("1").GetComponent<SpriteRenderer>();
        two.enabled = false;
        one.enabled = true;
        yield return new WaitForSeconds(1f);
        one.enabled = false;
        GameObject.Find("overlay").GetComponent<Image>().enabled = false;
        countDown = false;

        ActivatingPoint[] points = GameObject.FindGameObjectWithTag("World").GetComponentsInChildren<ActivatingPoint>();
        foreach (ActivatingPoint point in points)
        {
            point.enablePoint();
        }
    }

    private void moveToNextLevel()
    {
        
        
        
        float step = speed * Time.deltaTime;
        
        world.transform.position = Vector3.MoveTowards(world.transform.position, new Vector3(targetX, world.transform.position.y, world.transform.position.z), step);
        if (world.transform.position.x < targetX + 1920 && speed > 100f) //if the camera has moved half the way
        {
            speed -= 1;
        }
        else
        {
            speed += 1;
        }
    }

}
