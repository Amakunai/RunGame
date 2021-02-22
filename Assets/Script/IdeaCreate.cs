using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdeaCreate : MonoBehaviour
{
    public List<GameObject> poolIdea = new List<GameObject>();

    [SerializeField] private List<float> upList = new List<float>();
    [SerializeField] private List<float> downList = new List<float>();

    [SerializeField] private Transform player;
    [SerializeField] private GameObject idea;

    [SerializeField] private int ideaCount;
    [SerializeField] private int distans;

    private float ideaY;
    private int numx = 0;
    private int numy = 0;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++) 
        { 
            GameObject ideas = (GameObject)Instantiate(idea);
            ideas.name = "idea" + i;
            ideas.SetActive(false);
            ideas.transform.SetParent(this.transform,false);
            poolIdea.Add(ideas);
        }

        ideaY = 2;
        numx = 0;
        numy = 0;
        ideaCount = 0;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > count * distans - 30) 
        {
            poolIdea[ideaCount % 20].SetActive(true);
            poolIdea[ideaCount % 20].transform.position = new Vector3(distans*count,ideaY,0);
            ideaCount++;
            count++;
            
        }
        if (player.position.x > upList[numx]  -30)
        {
            ideaY += 2 ;
            poolIdea[ideaCount % 20].SetActive(true);
            poolIdea[ideaCount % 20].transform.position = new Vector3(distans * (count-1) + distans / 2 , ideaY, 0);
            ideaCount++;

            ideaY += 2;
            numx++;
        }
        if (player.position.x > downList[numy] - 30)
        {
            ideaY -= 2;
            poolIdea[ideaCount % 20].SetActive(true);
            poolIdea[ideaCount % 20].transform.position = new Vector3(distans * (count - 1) + distans / 2, ideaY, 0);
            ideaCount++;

            ideaY -= 2;
            numy++;
        }

    }
}
