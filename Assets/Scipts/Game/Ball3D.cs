using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Herghys
{
    public class Ball3D : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;

        public float Speed;
        public LayerMask ballMask;
        public LayerMask cornerMask;
        public ModelType modelType;

        public Material Rock;
        public Material Paper;
        public Material Scissor;

        [SerializeField] private MeshRenderer _renderer;

        private void Awake()
        {
            rb ??= GetComponent<Rigidbody>();
            _renderer ??= GetComponent<MeshRenderer>();
            Speed = UnityEngine.Random.Range(20, 30);
        }

        IEnumerator Start()
        {
            Vector3 velocity = new Vector3(GetRandomNumber(-6.0f, 6.0f), GetRandomNumber(-6.0f, 6.0f), 0);
            yield return null;

            rb.AddForce(velocity * Speed);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
                var target = collision.gameObject.GetComponent<Ball3D>();
                if (target != null)
                {
                    if (modelType < target.modelType)
                    {
                        Randomize();
                    }
                }
            }

            if (collision.gameObject.CompareTag("Boundary"))
            {
                Randomize();
            }
        }

        float GetRandomNumber(float min, float max)
        {
            float value = UnityEngine.Random.Range(min, max);

            while ((int)value == -1 || (int)value == 1)
            {
                value = UnityEngine.Random.Range(min, max);
            }

            return value;
        }


        public void Randomize()
        {
            Array values = Enum.GetValues(typeof(ModelType));
            var random = new System.Random();
            modelType = (ModelType)values.GetValue(random.Next(values.Length));

            _renderer.sharedMaterial = modelType switch
            {
                ModelType.Paper => Paper,
                ModelType.Rock => Rock,
                ModelType.Scissors => Scissor,
                _ => Paper
            };
        }
    }
}
