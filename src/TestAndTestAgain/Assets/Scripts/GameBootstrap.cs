using System.Collections;
using UnityEngine;


namespace Vova.TestAndTestAgain
{
    public class GameBootstrap : MonoBehaviour
    {
        public Transform MapParent;
        public Game Game;
        
        private readonly Map map = new Map();
        
        private void Awake() => 
            Game.Initialize(map.Generate(MapParent));
    }
}
