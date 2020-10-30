using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Vova.TestAndTestAgain
{
    public class Game : MonoBehaviour
    {
        public Canvas MainCanvas;
        
        private List<Item> items;
        private int stepsCount;
        private Factory<GameOverPanel> factory = new Factory<GameOverPanel>(nameof(GameOverPanel));

        private bool GameFinished => items.All(item => item.Number == items.IndexOf(item) + 1);

        public void Initialize(List<Item> items)
        {
            this.items = items;
            
            items.ForEach(item => item.PositionUpdated += StepMade);
        }

        private void StepMade(object sender, EventArgs args)
        {
            stepsCount++;
            
            if(GameFinished)
                GameOver();
        }

        private void GameOver()
        {
            var menu = factory.Create(Vector2.zero, MainCanvas.transform);
            menu.Initialize(stepsCount);
        }
    }
}