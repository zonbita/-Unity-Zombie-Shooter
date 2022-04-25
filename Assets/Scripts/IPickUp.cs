using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class IPickUp : MonoBehaviour
{
        [Tooltip("Frequency at which the item will move up and down")]
        public float Frequency = 1f;

        [Tooltip("Distance the item will move up and down")]
        public float Bobbing = 1f;

        [Tooltip("Rotation angle per second")] public float RotatingSpeed = 360f;

        [Tooltip("Sound played on pickup")] public AudioClip PickupSfx;
        [Tooltip("VFX spawned on pickup")] public GameObject PickupVfxPrefab;

        public Rigidbody rb { get; private set; }

        Collider Collider;
        Vector3 Position;
        bool m_HasPlayedFeedback;

        protected virtual void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
            Collider = GetComponent<Collider>();
            Collider.isTrigger = true;
            Position = transform.position;
        }

        void Update()
        {
            // Handle bobbing
            float bobbingAnimationPhase = ((Mathf.Sin(Time.time * Frequency) * 0.5f) + 0.5f) * Bobbing;
            transform.position = Position + Vector3.up * bobbingAnimationPhase;

            // Handle rotating
            transform.Rotate(Vector3.up, RotatingSpeed * Time.deltaTime, Space.Self);
        }

        void OnTriggerEnter(Collider other)
        {
            OnPicked();
        }

        protected virtual void OnPicked()
        {
            PlayPickupFeedback();
        }

        public void PlayPickupFeedback()
        {
            if (m_HasPlayedFeedback)
                return;

            if (PickupSfx)
            {
                //AudioUtility.CreateSFX(PickupSfx, transform.position, AudioUtility.AudioGroups.Pickup, 0f);
            }

            if (PickupVfxPrefab)
            {
                var pickupVfxInstance = Instantiate(PickupVfxPrefab, transform.position, Quaternion.identity);
            }

            m_HasPlayedFeedback = true;
        }
}

