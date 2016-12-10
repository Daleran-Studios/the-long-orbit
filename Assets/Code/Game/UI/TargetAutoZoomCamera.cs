﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLongOrbit
{
    public class TargetAutoZoomCamera : MonoBehaviour
    {

        [ReadOnly]
        [SerializeField]
        private GameObject target;
        [SerializeField]
        private Vector3 offset = new Vector3(0f, 0f, -10f);
        [SerializeField]
        private float defaultOrthographicSize = 32f;

        private Camera cam;
        private SpriteRenderer targetSpriteRenderer;

        void Awake()
        {
            cam = gameObject.GetRequiredComponent<Camera>();
            cam.orthographicSize = defaultOrthographicSize;
        }
        
        // Use this for initialization
        void Start()
        {

            CommandManager.Instance.OnSelection += SetTarget;
            if (CheckIfTargetIsNull())
            {
                gameObject.SetActive(false);
            }
        }

        // Update is called once per frame
        void LateUpdate()
        {
            if(CheckIfTargetIsNull())
            {
                TrackTarget();
            }

        }

        void OnDestroy()
        {
            CommandManager.Instance.OnSelection -= SetTarget;
        }

        bool CheckIfTargetIsNull()
        {
            if (target != null)
                return true;
            else
                return false;
        }

        void TrackTarget()
        {
            transform.position = target.transform.position + offset;
        }

        float GetOrthographicSizeForSprite(SpriteRenderer renderer)
        {
            Vector3 maxSpritePoint = renderer.bounds.max;
            return MathExtensions.GetMaxAbsoluteDimmension(maxSpritePoint);

        }

        public void ClearTarget()
        {
            target = null;
        }

        public void SetTarget(Selector tar)
        {
            gameObject.SetActive(true);
            target = tar.gameObject;
            targetSpriteRenderer = target.GetComponent<SpriteRenderer>();

            if (targetSpriteRenderer != null)
            {
                cam.orthographicSize = GetOrthographicSizeForSprite(targetSpriteRenderer);
            }
            else
            {
                cam.orthographicSize = defaultOrthographicSize;
            }
        }

    }
}
