using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] bool canPlace;
    [SerializeField] realTower tower;   
      [SerializeField] AudioClip build;

    public bool CanPlace {get {return canPlace;}}
    
    private void OnMouseDown()  
    {
       if(canPlace)
       {
        bool isPlaced = tower.CreateTower(transform.position);
        GetComponent<AudioSource>().PlayOneShot(build);
       canPlace = !isPlaced;
       }
    }

   
}
