using System.Collections;
using UnityEngine;

public abstract class DayAction : MonoBehaviour
{
    public abstract IEnumerator PerformDayAction();
}
