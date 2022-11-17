using _Project.Shared.Scripts.InspectorButton;
using UnityEngine;
using UnityEngine.UI;

namespace Shared.Scripts
{
    public class BackgroundOffsetBehaviour : MonoBehaviour
    {
        public float scrollX = -2f;
        public float scrollY = -2f;

        RawImage rend;

        void Start()
        {
            rend = GetComponent<RawImage>();
        }

        void Update()
        {
            float offsetX = Time.time * scrollX;
            float offsetY = Time.time * scrollY;

            rend.uvRect = new Rect(offsetX, offsetY, 1, 1); 
        }
    }
}