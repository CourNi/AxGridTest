using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;

namespace Test2
{
    [State("ReadyState")]
    public class ReadyState : FSMState
    {
        [Enter]
        private void OnEnter()
        {
            Debug.Log("FSM Ready");
        }

        [Bind]
        private void OnCollectionCreate(string collectionName)
        {
            Model.GetList<string>("CollectionList").Add(collectionName);
        }

        [Bind]
        private void OnDeckClick(Card card)
        {
            Model.Inc("CardIndex");
            card.SetIndex(Model.GetInt("CardIndex"));
            Model.GetList<Card>("MainList").Add(card);
            Model.EventManager.Invoke("OnMainListChanged");
        }

        [Bind]
        private void OnCardClick(string currentCollection, int index)
        {
            var card = Model.GetList<CardObject>("DeckPool").Where(i => i.GetCard().Index == index).FirstOrDefault().GetCard();
            string targetCollection = GeneralActions.GetNextCollection(currentCollection);
            if (Model.GetList<Card>($"{targetCollection}List").Count < Model.GetInt($"{targetCollection}Pool"))
            {
                Model.GetList<Card>($"{currentCollection}List").Remove(card);
                Model.GetList<Card>($"{targetCollection}List").Add(card);
                Model.EventManager.Invoke($"On{currentCollection}ListChanged");                
                Model.EventManager.Invoke($"On{targetCollection}ListChanged");
            }
        }
    }
}