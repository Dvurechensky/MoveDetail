using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class MovePosition : MonoBehaviour
    {
        [SerializeField] private float X;
        [SerializeField] private float Y;
        [SerializeField] private float Z;
        [SerializeField] private float speedMove;
        [HideInInspector]
        public bool EnableMove { get; set; }

        private void Update()
        {
            if(EnableMove)
                transform.position = Vector3.Lerp(this.transform.position, new Vector3(X, Y, Z), Time.deltaTime * speedMove);
        }

        void OnMouseDown()
        {
            EnableMove = !EnableMove;
        }
    }
}
