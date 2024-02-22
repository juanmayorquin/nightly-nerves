using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    private Player player;
    private AnimationManager animationManager;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        animationManager = GameObject.FindObjectOfType<AnimationManager>();
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
                animationManager.setAnim(0);
                animationManager.Play();
            }
            else
            {
                //Code if player lose
                Task taskDone = null;

                foreach (Task task in player.tasks)
                {
                    if ((task.id == 1 || task.id == 2) && task.isDone)
                    {
                        taskDone = task;
                    }
                }
                
                if(taskDone != null)
                {
                    animationManager.setAnim(taskDone.id);
                    animationManager.Play();
                }
                else
                {
                    animationManager.setAnim(3);
                    animationManager.Play();
                }
                

            }
        }
    }
}
