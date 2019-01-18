using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour {

    public static string username;
    public static int totalDeaths;
    public static int totalPlays;
    public static int totalWeight;
    public static int totalTime;

    public static int hasThemeDefault0;
    public static int hasThemeMcDonalds1;
    public static int hasThemePizza2;
    public static int hasThemeSushi3;

    public static int totalFoodItem1, totalFoodItem2, totalFoodItem3, totalFoodItem4, totalFoodItem5, totalFoodItem6, totalFoodItem7,
                      totalFoodItem8, totalFoodItem9, totalFoodItem10, totalFoodItem11, totalFoodItem12;

    public static int activeTheme;

    public static bool LoggedIn { get { return username != null; } }

    public static void LogOut()
    {
        username = null;
    }


}
