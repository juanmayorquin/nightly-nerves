using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkIfFinished()
    {
        if(player != null)
        {
            if(player.completedTasks == player.tasks.Count)
            {
                //Code if player wins
                
            }
            else
            {
                //Code if player lose
                
            }
        }
    }
}
