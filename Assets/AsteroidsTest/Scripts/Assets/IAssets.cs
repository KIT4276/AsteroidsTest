using UnityEngine;

namespace AsteroidsTest.Assets
{
    public interface IAssets 
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 position);
    }
}
