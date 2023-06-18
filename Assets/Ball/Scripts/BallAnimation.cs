using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Ball.Scripts
{
    public class BallAnimation : MonoBehaviour
    {
        public MeshRenderer mesh;
        public Material normalMat;
        public Material hitMat;
        public float animTime;
        public float flashDur;
        public float animSize;
        
        public void Play()
        {
            StartCoroutine(ChangeMaterial());
        }

        IEnumerator ChangeMaterial()
        {
            var t = mesh.transform.parent;
            t.DOScale(animSize, animTime/2).OnComplete(()
                => t.DOScale(1f, animTime/2));
            
            mesh.material = hitMat;
            yield return new WaitForSeconds(flashDur);
            mesh.material = normalMat;
        }
    }
}