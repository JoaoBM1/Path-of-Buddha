using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightIncreaser : MonoBehaviour {

    GameObject playerObject;
    Player player;
    int increaseAmount = 20;

    void Start()
    {
        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player.IncreaseWeight(increaseAmount);
            Destroy(this.gameObject);
            if(DatabaseManager.activeTheme == 0)
            {
                if(this.gameObject.tag.Equals("Food 1"))
                {
                    DatabaseManager.totalFoodItem1++;
                } else if(this.gameObject.tag.Equals("Food 2"))
                {
                    DatabaseManager.totalFoodItem2++;
                } else if (this.gameObject.tag.Equals("Food 3"))
                {
                    DatabaseManager.totalFoodItem3++;
                }
            }
            else if (DatabaseManager.activeTheme == 1)
            {
                if (this.gameObject.tag.Equals("Food 1"))
                {
                    DatabaseManager.totalFoodItem4++;
                }
                else if (this.gameObject.tag.Equals("Food 2"))
                {
                    DatabaseManager.totalFoodItem5++;
                }
                else if (this.gameObject.tag.Equals("Food 3"))
                {
                    DatabaseManager.totalFoodItem6++;
                }
            }
            else if (DatabaseManager.activeTheme == 2)
            {
                if (this.gameObject.tag.Equals("Food 1"))
                {
                    DatabaseManager.totalFoodItem7++;
                }
                else if (this.gameObject.tag.Equals("Food 2"))
                {
                    DatabaseManager.totalFoodItem8++;
                }
                else if (this.gameObject.tag.Equals("Food 3"))
                {
                    DatabaseManager.totalFoodItem9++;
                }
            }
            else if (DatabaseManager.activeTheme == 3)
            {
                if (this.gameObject.tag.Equals("Food 1"))
                {
                    DatabaseManager.totalFoodItem10++;
                }
                else if (this.gameObject.tag.Equals("Food 2"))
                {
                    DatabaseManager.totalFoodItem11++;
                }
                else if (this.gameObject.tag.Equals("Food 3"))
                {
                    DatabaseManager.totalFoodItem12++;
                }
            }
        }
    }
}
