using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    public static int CurrentLevel;
    public static string CurrentMode;
    public static int CurrentTruck;
    public static ModeType modeType;
    public static int TotalLevel;


}
public enum ModeType
{
    Alpha, Beta, Gamma
}