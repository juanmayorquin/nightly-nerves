using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] List<Task> tasks = new List<Task>();
    // Start is called before the first frame update
    void Start()
    {
        foreach(Task task in GameObject.FindObjectsOfType(typeof(Task)))
        {
            tasks.Add(task);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
