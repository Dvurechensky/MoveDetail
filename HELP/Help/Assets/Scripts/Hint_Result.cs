using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Hint_Result : MonoBehaviour
    {
        void Update()
        {
            if (FlyCamera.ActiveMove)
                GetComponent<Text>().text = "Move: <color='green'>Active</color>";
            else
                GetComponent<Text>().text = "Move: <color='red'>Inactive</color>";
        }
    }
}