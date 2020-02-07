using System;
using UnityEngine;

namespace Danyas
{
    public class DanyasLoader
    {
        static void Init()
        {
            DanyasLoader.Load = new GameObject();
            DanyasLoader.Load.AddComponent<DanyaLOL>();
            UnityEngine.Object.DontDestroyOnLoad(DanyasLoader.Load);
        }

        static void Unload()
        {
            GameObject.Destroy(DanyasLoader.Load);
        }

        private static GameObject Load;
    }
}
