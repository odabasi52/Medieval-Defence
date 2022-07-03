using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class Coordinates : MonoBehaviour
{    

    TextMeshPro coLabel;
    Vector2Int coordinates = new Vector2Int();
    WayPoint waypoint;
    bool shower;

    void Awake() 
    {
       coLabel = GetComponent<TextMeshPro>(); 
       DisplayCoordinate();
       waypoint = GetComponentInParent<WayPoint>();
       coLabel.enabled = false;
    }
    void Update()
    {

        if (!Application.isPlaying)
        {
            DisplayCoordinate();
            UpdateName();
        }

        ColorChanger();
        CoordinateToogle();
       
    }

    void CoordinateToogle()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            coLabel.enabled = !coLabel.IsActive();
        }
    }

    void ColorChanger()
    {
        if (waypoint.CanPlace)
        {
            coLabel.color = Color.white;
        }
        if (!waypoint.CanPlace)
        {
            coLabel.color = Color.red;
        }
    }

    void DisplayCoordinate()
    {  
        //UnityEditor.EditorSnapSettings.move.x ile kaç birim hareket ettirdiğimizi görüyoruz
       coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x); 
       coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

       coLabel.text =  coordinates.ToString(); 
    }

    void UpdateName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
