using Unity.VisualScripting;
using UnityEngine;

public class GameEvents : MonoBehaviour
{

    static GameObject[] enemies;
    
    void Awake()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
    public static void handleAlertEnemyEvent(GameObject furniture)
    {
        Debug.Log("Enemy Alerted!");
        //there will always be at least one enemy
        GameObject closestEnemy = enemies.Length > 0 ? enemies[0] : null;
        float closestDistance = Mathf.Infinity;

        foreach(GameObject enemy in enemies)
        {
            if(enemy != null)
            {
                float currDistance = Vector3.Distance(enemy.transform.position,furniture.transform.position);
                if(currDistance <= closestDistance)
                {
                    closestEnemy = enemy;
                    closestDistance = currDistance;
                }
                if(closestEnemy != null)
                {
                    closestEnemy.GetComponent<EnemyController>().InspectFurniture(furniture.transform);
                }
            }
        }
    }
    

    

    void Update()
    {

    }
    // public static void AlertEnemy(GameObject furniture)
    // {
    //     GameObject closestEnemy = enemies.Length > 0 ? enemies[0] : null;

    //     float closestDistance = Mathf.Infinity;


    //     // foreach (GameObject enemy in enemies)
    //     // {
    //     //     if (enemy != null)
    //     //     {
    //     //         float currDistance = Vector3.Distance(enemy.transform.position, furniture.transform.position);
    //     //         if (currDistance <= closestDistance)
    //     //         {
    //     //             closestEnemy = enemy;
    //     //             closestDistance = currDistance;
    //     //         }
    //     //         if (closestEnemy != null)
    //     //         {
    //     //             closestEnemy.GetComponent<EnemyController>().InspectFurniture(furniture.transform);
    //     //         }
    //     //     }
    //     //     Debug.Log(enemy);
    //     // }
    // }
}
