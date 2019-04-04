﻿using ColossalFramework.UI;
using NetworkSkins.Net;
using UnityEngine;

namespace NetworkSkins.GUI
{
    public class CatenaryPanel : ListPanelBase<CatenaryList, PropInfo>
    {
        protected override void RefreshUI(NetInfo netInfo) {

        }

        protected override void OnSearchLostFocus() {
        }

        protected override void OnSearchTextChanged(string text) {
        }

        protected override void OnPanelBuilt() {
            tabStrip.isVisible = false;
            RefreshAfterBuild();
        }

        protected override void OnFavouriteChanged(string itemID, bool favourite) {
            if (favourite) Persistence.AddFavourite(itemID, PanelType.Catenary);
            else Persistence.RemoveFavourite(itemID, PanelType.Catenary);
        }

        protected override void OnSelectedChanged(string itemID, bool selected) {
            if(selected) SkinController.SetCatenary(itemID);
        }
    }
}
