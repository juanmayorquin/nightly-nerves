using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Task> tasks = new List<Task>();
    public int completedTasks = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Task task in GameObject.FindObjectsOfType(typeof(Task)))
        {
            tasks.Add(task);
        }

        //GameObject.FindObjectOfType<AudioManager>().Play("storm");
    }

    // Update is called once per frame
    void Update()
    {
        completedTasks = tasks.Count(t => t.isDone);

    }
}
