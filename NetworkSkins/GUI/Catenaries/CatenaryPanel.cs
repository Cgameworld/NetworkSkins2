﻿using NetworkSkins.GUI.Abstraction;

namespace NetworkSkins.GUI.Catenaries
{
    public class CatenaryPanel : ListPanelBase<CatenaryList, PropInfo>
    {
        protected override void RefreshUI(NetInfo netInfo) {
            list.RefreshRowsData();
        }

        protected override void OnSearchLostFocus() {
        }

        protected override void OnSearchTextChanged(string text) {
        }

        protected override void OnPanelBuilt() {
            pillarTabStrip.isVisible = false;
            laneTabStrip.isVisible = false;
            Refresh();
        }

        protected override void OnFavouriteChanged(string itemID, bool favourite) {
            if (favourite) Persistence.AddFavourite(itemID, ItemType.Catenary);
            else Persistence.RemoveFavourite(itemID, ItemType.Catenary);
        }

        protected override void OnSelectedChanged(string itemID, bool selected) {
            if (!selected) return;
            NetworkSkinPanelController.Catenary.SetSelectedItem(itemID);
        }
    }
}
