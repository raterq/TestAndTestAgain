using System.Collections.Generic;
using UnityEngine;

namespace Vova.TestAndTestAgain
{
    public class Map
    {
        private readonly Factory<Item> factory = new Factory<Item>(nameof(Item));
        
        private readonly List<int> itemsToCreate = new List<int> {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16};
        private const int RowSize = 4;
        private readonly Vector2 itemSize = new Vector2(40,40);

        private int RandomItemNumber
        {
            get
            {
                var random = Random.Range(0, itemsToCreate.Count - 1);
                
                var result = itemsToCreate[random];
                itemsToCreate.RemoveAt(random);
                
                return result;
            }
        }
            
        public List<Item> Generate(Transform parent)
        {
            var result = new List<Item>();
            
            for (var i = 1; i <= RowSize; i++)
            for (var j = 1; j <= RowSize; j++)
            {
                var yPosition = itemSize.y * -i;
                var xPosition = itemSize.x * j;

                var item = factory.Create(new Vector2(xPosition, yPosition), parent);
                
                item.Initialize(RandomItemNumber, result);

                result.Add(item);
            }

            return result;
        }
    }
}