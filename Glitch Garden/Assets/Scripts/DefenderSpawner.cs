using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defenderPrefab;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defender";

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defenderPrefab = defenderToSelect;
        int defenderCost = defenderPrefab.GetComponent<Defender>().GetDefenderCost();
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defenderPrefab.GetDefenderCost();      
        if (starDisplay.HaveEnoughStars(defenderCost))                     //if we have enough stars
        {
            SpawnDefender(gridPos);                                        //spawn the defender
            starDisplay.SpendStars(defenderCost);                          //spend the stars
        }                                                                                 
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX,newY); 
    }

    private void SpawnDefender(Vector2 roundedPos)
    {
        Defender newDefender = Instantiate(defenderPrefab, roundedPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }  
}
