using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu]
    public class ScaleTransform : Command
    {
        [SerializeField] float scale = 1f;

        public override void Execute(GameObject gameObject)
        {
            var localScale = gameObject.transform.localScale;
            gameObject.transform.localScale = Vector3.ClampMagnitude(localScale + Vector3.one * scale * Time.deltaTime, 10f);

        }
    }
