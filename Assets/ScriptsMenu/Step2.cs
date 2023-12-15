using UnityEngine;
using UnityEngine.EventSystems;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class Step2 : MonoBehaviour
{
    public Transform posit;
    public void OnPointerEnter()
    {
        posit.position = new Vector3((posit.position.x +50), (posit.position.y));
    }
    

}
