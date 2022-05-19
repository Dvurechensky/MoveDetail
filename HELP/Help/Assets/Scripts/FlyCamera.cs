using UnityEngine;

namespace Assets.Scripts
{
    public class FlyCamera : MonoBehaviour
    {
        [SerializeField] private float mouseSensitivity = 3.0f;
        [SerializeField] private float speed = 2.0f;
        [SerializeField] private float minimumX = -360F;
        [SerializeField] private float maximumX = 360F;
        [SerializeField] private float minimumY = -60F;
        [SerializeField] private float maximumY = 60F;
        private Vector3 transfer;
        private float rotationX = 0F; 
        private float rotationY = 0F;
        private Quaternion originalRotation;
        [HideInInspector]
        public static bool ActiveMove { get; set; }

        void Awake()
        {
            GetComponent<Camera>().orthographic = false;
        }

        void Start()
        {
            originalRotation = transform.rotation;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                ActiveMove = !ActiveMove;

            if (ActiveMove)
            {
                rotationX += Input.GetAxis("Mouse X") * mouseSensitivity;
                rotationY += Input.GetAxis("Mouse Y") * mouseSensitivity;
                rotationX = ClampAngle(rotationX, minimumX, maximumX);
                rotationY = ClampAngle(rotationY, minimumY, maximumY);
                Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
                Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.left);
                transform.rotation = originalRotation * xQuaternion * yQuaternion;
                transfer = transform.forward * Input.GetAxis("Vertical");
                transfer += transform.right * Input.GetAxis("Horizontal");
                transform.position += transfer * speed * Time.deltaTime;
            }
        }

        /// <summary>
        /// Просчет угла
        /// </summary>
        /// <param name="value">Ограничиваемое значение.</param>
        /// <param name="min">Нижняя граница результата.</param>
        /// <param name="max">Верхняя граница результата.</param>
        /// <returns>value, ограниченное диапазоном от min до max</returns>
        private float ClampAngle(float value, float min, float max)
        {
            if (value < -360F) value += 360F;
            if (value > 360F) value -= 360F;
            return Mathf.Clamp(value, min, max);
        }
    }
}
