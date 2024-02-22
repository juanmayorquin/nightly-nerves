using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    private bool isDone = false;

    private void Start()
    {
        isDone = false;
    }
    public void setDone()
    {
        if (!isDone) 
        { 
            isDone= true;
            Debug.Log("Done");
        }
    }
}
