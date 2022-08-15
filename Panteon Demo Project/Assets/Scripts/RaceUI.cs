using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaceUI : MonoBehaviour
{
    public TextMeshProUGUI[] text;
    public Transform[] characters;
    float[,] array;
    int startFrom=0;
    private void Start()
    {
        array = new float[11,3];
        for(int i=0; i<11; i++)
        {
            for(int j=0; j<3; j++)
            {
                if (j == 0)
                {
                    array[i,j] = i;
                }
                else if(j == 1)
                {
                    array[i, j] = characters[i].position.z;
                }
                else if(j == 2)
                {
                    array[i, j] = 0;
                }
            }
            
        }
        //InvokeRepeating("SortPlayers", 0f, 0.05f);
    }
    private void Update()
    {
        SortPlayers();
    }


    void SortPlayers()
    {

        for (int i = startFrom; i < 11 - 1; i++)
        {
            
            for( int j = startFrom; j < 11 - 1; j++)
            {
                
                if (array[j, 1] < array[j + 1, 1])
                {

                    float tempIndex = array[j, 0];
                    float temp = array[j,1];

                    array[j, 0] = array[j + 1, 0];
                    array[j,1] = array[j + 1,1];

                    array[j + 1, 0] = tempIndex;
                    array[j + 1,1] = temp;
                }
                    
            }
            
        }
        for(int i = startFrom; i < 11; i++)
        {
            
            if(array[i, 1] > 4.65f)
            {
                
                startFrom++;
                array[i, 2] = 1;
                break;
                
            }
        }
        for(int i=0; i<11; ++i)
        {
            
            text[i].text = characters[(int)array[i, 0]].name;
        }

        for (int i = startFrom; i < 11; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if ((int)array[i, 0] == j && (int) array[i, 2] == 0)
                {
                    
                    array[i, 1] = characters[j].position.z;
                }
            }
        }
        
        
    }
  

}
