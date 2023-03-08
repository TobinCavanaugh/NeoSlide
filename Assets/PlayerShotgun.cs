using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerShotgun : MonoBehaviour
    {
        public float knockBackForce = 4f;
        public float coolDownTime = 4f;
        private float curTime = 0;

        public Animator animator;

        public string animShootName = "Shoot";

        public Rigidbody rb;
        public Transform cameraTransform;

        private void Update()
        {
            curTime += Time.deltaTime;

            if (curTime >= coolDownTime)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    
                    StartCoroutine(Shoot());
                    animator.Play(animShootName);
                }
            }
        }

        IEnumerator Shoot()
        {
            yield return new WaitForSeconds(.3f);
            rb.AddForce(-cameraTransform.forward * knockBackForce, ForceMode.Impulse);
            curTime = 0;
        }
    }
}