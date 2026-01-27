using UnityEngine;

public static class GetComposantFromGameObject<T>
{
    /// <summary>
    /// Will return an existant composant from the gameobject or will create add a new one
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="objectFrom"></param>
    /// <returns></returns>
    public static T TryGetComposant<T>(GameObject objectFrom) where T : Component
    {
        return objectFrom.TryGetComponent(out T composantOwned) ? composantOwned : objectFrom.AddComponent<T>();
    }
}
