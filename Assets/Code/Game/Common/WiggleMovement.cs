using UnityEngine;

namespace ClearCursesProto.Game
{
    public class WiggleMovement : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _wiggleVector;

        [SerializeField]
        private float _wiggleSpeed;

        private void Update()
        {
            var wiggle = _wiggleVector * Mathf.Sin(Time.time * _wiggleSpeed);

            transform.localPosition = wiggle;
        }
    }
}