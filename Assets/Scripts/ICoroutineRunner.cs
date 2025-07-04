using System.Collections;
using UnityEngine;

namespace AsteroidsTest
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(Coroutine spawnCoroutine);
    }
}
