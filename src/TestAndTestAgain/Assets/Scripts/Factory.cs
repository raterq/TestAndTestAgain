using UnityEngine;

namespace Vova.TestAndTestAgain
{
    public class Factory<T> where T : MonoBehaviour
    {
        private string PrefabName { get; }
        private T Prefab => Resources.Load<T>(PrefabName);

        public Factory(string prefabName) => PrefabName = prefabName;

        public T Create(Vector2 position, Transform parent)
        {
            var item = Object.Instantiate(Prefab, parent);
            item.transform.localPosition = position;
            
            return item;
        }
    }
}