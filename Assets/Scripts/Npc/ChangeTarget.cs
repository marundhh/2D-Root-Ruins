using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTarget : MonoBehaviour
{
    NpcAI npc;
    Timecaculator time;

    [SerializeField] List<Transform> targets  = new List<Transform>();
    [SerializeField] int hour;

    [SerializeField] int Work, Rest, Park, Home;
    [SerializeField] List<int> works = new List<int>();

    [SerializeField] bool hasWork, hasRest, hasPark, hasHome, manyWork;
    void Start()
    {
       time = FindAnyObjectByType<Timecaculator>();    
        npc = GetComponent<NpcAI>();
    }

    void Timeline()
    {
        
        hour = time.hours;
        if(manyWork)
        {
            int indexWorks = works.Count;
            for(int i = 0; i < indexWorks; i++)
            {
                

                    if (hour == works[i])
                    {
                    npc.backHome = false;
                    npc.target = targets[i+2];
                    }
                
            }
           
            
        }
        if (hasWork)
        {
            if (hour ==  Work)
            {
                npc.backHome = false;
                npc.target = targets[2];
            }
        } 

        if (hasRest)
        {
            if (hour == Rest)
            {
                npc.backHome = true;
                npc.target = targets[0];
            }
        }


        if (hasPark)
        {
            if (hour == Park )
            {
                npc.backHome = false;
                npc.target = targets[1];
            }
        }
        if (hasHome)
        {
            if (hour == Home )
            {
                npc.backHome = true;
                npc.target = targets[0];
            }
        }
    }

    void Update()
    {
        Timeline();
    }
}
