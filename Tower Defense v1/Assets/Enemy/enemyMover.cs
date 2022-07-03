using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class enemyMover : MonoBehaviour
{   
    [SerializeField] List <WayPoint> enemyPath = new List<WayPoint>();
    [SerializeField] [Range(0, float.PositiveInfinity)]float speed = 1;
    Enemy enemy;
   
   void Start() 
   {
    enemy = GetComponent<Enemy>();
   }
    void OnEnable()
    {   
        PathFinder();
        transform.position = enemyPath[0].transform.position;
        StartCoroutine(Path());
    }

    void PathFinder()
    {
        enemyPath.Clear();
        
        GameObject parent = GameObject.FindGameObjectWithTag("path");

        foreach(Transform waypoint in parent.transform)
        {
        WayPoint wayPoint = waypoint.GetComponent<WayPoint>(); 

        if(wayPoint != null)
        enemyPath.Add(wayPoint); 
        }

    }

    
    IEnumerator Path()
    {
        foreach(WayPoint paths in enemyPath)
        {
            Vector3 startingPosition = transform.position;
            Vector3 endingPosition = paths.transform.position;
            float travelPercentage = 0;

            transform.LookAt(endingPosition);

            while(travelPercentage < 1f)
            {
            travelPercentage += Time.deltaTime *speed;
            transform.position = Vector3.Lerp(startingPosition, endingPosition , travelPercentage);
            yield return new WaitForEndOfFrame();
            }
        }

        enemy.PenaltyGold();
        gameObject.SetActive(false);
    }
}
