using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    List<GameObject> listOfOpponents = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        listOfOpponents.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        Debug.Log(listOfOpponents.Count);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void KilledOpponent(GameObject Enemy)
    {
        if (listOfOpponents.Contains(Enemy))
        {
            listOfOpponents.Remove(Enemy);
        }

        Debug.Log(listOfOpponents.Count);
    }

    public bool AreOpponentsDead()
    {
        if (listOfOpponents.Count <= 0)
        {
            // They are dead!
            return true;
        }
        else
        {
            // They're still alive dangit
            return false;
        }
    }
}
