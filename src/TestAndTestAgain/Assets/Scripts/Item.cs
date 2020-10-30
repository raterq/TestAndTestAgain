using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Vova.TestAndTestAgain
{
    public class Item : MonoBehaviour, IPointerDownHandler
    {
        public TextMeshPro TextMeshPro;
        public SpriteRenderer SpriteRenderer;
        
        public int Number;
        public bool IsSixteen;

        private List<Item> allItems;
        
        private const int distanceDelta = 45;

        private Item SixteenElement => allItems.FirstOrDefault(item => item.IsSixteen);
        
        private bool CanMove => 
            Vector2.Distance(transform.position, SixteenElement.transform.position) < distanceDelta;

        public event EventHandler PositionUpdated;
        
        public void Initialize(int number, List<Item> allItems)
        {
            this.allItems = allItems;
            Number = number;
            
            CheckIsSixteen();
            GenerateNumber();
        }

        public void OnPointerDown(PointerEventData eventData) => TryToMove();

        private void TryToMove()
        {
            if(CanMove)
                Move();
        }

        private void Move()
        {
            var position = transform.localPosition;
            transform.localPosition = SixteenElement.transform.localPosition;
            SixteenElement.transform.localPosition = position;
            
            UpdateAllItemPosition();
        }

        private void UpdateAllItemPosition()
        {
            var currentElement = allItems.IndexOf(this);
            var sixteenElement = allItems.IndexOf(SixteenElement);
            
            allItems[currentElement] = SixteenElement;
            allItems[sixteenElement] = this;
            
            PositionUpdated?.Invoke(this, EventArgs.Empty);
        }

        private void CheckIsSixteen()
        {
            IsSixteen = Number == 16;
            MakeShadow(!IsSixteen);
        }

        private void GenerateNumber() => 
            TextMeshPro.text = Number.ToString();

        private void MakeShadow(bool enable)
        {
            TextMeshPro.enabled = enable;
            SpriteRenderer.enabled = enable;
        }
    }
}