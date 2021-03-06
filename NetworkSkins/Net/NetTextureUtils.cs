﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Object = UnityEngine.Object;

namespace NetworkSkins.Net
{
    public static class NetTextureUtils
    {
        private static readonly Dictionary<string, bool> PavementTextureDict = new Dictionary<string, bool> {
            { "Pedestrian Gravel", false },
            { "Pedestrian Pavement", false },
            { "Pedestrian Elevated", true },
            { "Pedestrian Slope", true },
            { "Pedestrian Tunnel", false },
            { "Pedestrian Gravel Elevated", true },
            { "Power Line", false },
            { "Dam", true },
            { "Basic Road", true },
            { "Large Road", true },
            { "Gravel Road", true },
            { "Medium Road", true },
            { "Highway", true },
            { "Highway Elevated", true },
            { "Basic Road Bridge", true },
            { "Basic Road Decoration Trees", true },
            { "HighwayRamp", true },
            { "Highway Barrier", true },
            { "Medium Road Bridge", true },
            { "HighwayRampElevated", true },
            { "Basic Road Elevated", true },
            { "Highway Bridge", true },
            { "Large Road Elevated", true },
            { "Medium Road Elevated", true },
            { "Oneway Road", true },
            { "Oneway Road Elevated", true },
            { "Medium Road Decoration Trees", true },
            { "Medium Road Decoration Grass", true },
            { "Basic Road Decoration Grass", true },
            { "Large Road Decoration Grass", true },
            { "Oneway Road Decoration Grass", true },
            { "Oneway Road Decoration Trees", true },
            { "Large Road Decoration Trees", true },
            { "Large Road Bridge", true },
            { "Oneway Road Bridge", true },
            { "Large Oneway", true },
            { "Large Oneway Bridge", true },
            { "Large Oneway Decoration Grass", true },
            { "Large Oneway Decoration Trees", true },
            { "Large Oneway Elevated", true },
            { "Basic Road Tunnel", false },
            { "Basic Road Slope", true },
            { "Medium Road Slope", true },
            { "Medium Road Tunnel", false },
            { "Oneway Road Slope", true },
            { "Oneway Road Tunnel", false },
            { "Large Road Slope", true },
            { "Large Road Tunnel", false },
            { "Large Oneway Road Slope", true },
            { "Large Oneway Road Tunnel", false },
            { "Highway Slope", true },
            { "Highway Tunnel", false },
            { "HighwayRamp Slope", true },
            { "HighwayRamp Tunnel", false },
            { "Gravel Road Bridge", true },
            { "Gravel Road Elevated", true },
            { "Oneway Toll Road Large 01", true },
            { "Oneway Toll Road Large 01c", true },
            { "Oneway Toll Road Medium 01", true },
            { "Oneway Toll Road Medium 01c", true },
            { "Twoway Toll Road Large 01", true },
            { "Twoway Toll Road Medium 01", true },
            { "Twoway Toll Road Medium 01b", true },
            { "Twoway Toll Road Large 01b", true },
            { "Water Pipe", false },
            { "Canal", true },
            { "Canal2", true },
            { "Canal3", true },
            { "Quay", false },
            { "Flood Wall", true },
            { "Castle Wall 1", false },
            { "Castle Wall 2", false },
            { "Castle Wall 3", false },
            { "Trench Ruins 01", false },
            { "Public Transport Line", false },
            { "Train Track", true },
            { "Train Station Track", true },
            { "Metro Track", false },
            { "Metro Station Track", false },
            { "Pedestrian Connection", false },
            { "Bus Line", false },
            { "Metro Line", false },
            { "Train Line", false },
            { "Airplane Line", false },
            { "Airplane Runway", true },
            { "Airplane Taxiway", true },
            { "Airplane Stop", true },
            { "Airplane Path", false },
            { "Airplane Connection Path", false },
            { "Ship Path", false },
            { "Ship Connection Path", false },
            { "Ship Line", false },
            { "Ship Dockway", false },
            { "Cargo Connection", false },
            { "Train Cargo Track", true },
            { "Train Track Bridge", true },
            { "Train Track Elevated", true },
            { "Harbor Road", true },
            { "Ship Dock", false },
            { "Pedestrian Connection Surface", false },
            { "Train Connection Track", true },
            { "Train Connection Track Elevated", true },
            { "Pedestrian Connection Inside", false },
            { "Pedestrian Connection Underground", false },
            { "Train Track Slope", false },
            { "Train Track Tunnel", false },
            { "Train Cargo Track Elevated", true },
            { "Bus Depot Road", true },
            { "Bus Station Stop", false },
            { "Bus Station Way", false },
            { "Train Oneway Track", true },
            { "Train Oneway Track Bridge", true },
            { "Train Oneway Track Elevated", true },
            { "Train Oneway Track Slope", true },
            { "Train Oneway Track Tunnel", false },
            { "Basic Road Bicycle", true },
            { "Pedestrian Pavement Bicycle", false },
            { "Pedestrian Elevated Bicycle", true },
            { "Medium Road Bicycle", true },
            { "Large Road Bicycle", true },
            { "Large Road Bus", true },
            { "Medium Road Bus", true },
            { "Pedestrian Slope Bicycle", true },
            { "Pedestrian Tunnel Bicycle", false },
            { "Medium Road Bridge Bus", true },
            { "Medium Road Elevated Bus", true },
            { "Medium Road Slope Bus", true },
            { "Medium Road Tunnel Bus", false },
            { "Large Road Bridge Bus", true },
            { "Large Road Elevated Bus", true },
            { "Large Road Slope Bus", true },
            { "Large Road Tunnel Bus", false },
            { "Basic Road Elevated Bike", true },
            { "Basic Road Bridge Bike", true },
            { "Medium Road Bridge Bike", true },
            { "Medium Road Elevated Bike", true },
            { "Large Road Bridge Bike", true },
            { "Large Road Elevated Bike", true },
            { "Basic Road Tram", true },
            { "Tram Line", false },
            { "Basic Road Elevated Tram", true },
            { "Basic Road Bridge Tram", true },
            { "Basic Road Slope Tram", true },
            { "Basic Road Tunnel Tram", false },
            { "Medium Road Tram", true },
            { "Tram Depot Road", true },
            { "Medium Road Elevated Tram", true },
            { "Medium Road Bridge Tram", true },
            { "Medium Road Slope Tram", true },
            { "Medium Road Tunnel Tram", false },
            { "Heating Pipe", false },
            { "Oneway Road Tram", true },
            { "Oneway Road Bridge Tram", true },
            { "Oneway Road Elevated Tram", true },
            { "Oneway Road Slope Tram", true },
            { "Oneway Road Tunnel Tram", false },
            { "Tram Track", true },
            { "Tram Track Bridge", true },
            { "Tram Track Elevated", true },
            { "Tram Track Slope", true },
            { "Tram Track Tunnel", false },
            { "Oneway Tram Track", true },
            { "Oneway Tram Track Bridge", true },
            { "Oneway Tram Track Elevated", true },
            { "Oneway Tram Track Slope", true },
            { "Oneway Tram Track Tunnel", false },
            { "Radio Mast Support Cables", false },
            { "Evacuation Bus Line", false },
            { "Canal Wide", true },
            { "Canal Wide2", true },
            { "Canal Wide3", true },
            { "Two Lane Highway Twoway", true },
            { "Two Lane Highway Twoway Barrier", true },
            { "Two Lane Highway Twoway Bridge", true },
            { "Two Lane Highway Twoway Elevated", true },
            { "Two Lane Highway Twoway Slope", true },
            { "Two Lane Highway Twoway Tunnel", false },
            { "Four Lane Highway", true },
            { "Four Lane Highway Barrier", true },
            { "Four Lane Highway Bridge", true },
            { "Four Lane Highway Elevated", true },
            { "Four Lane Highway Slope", true },
            { "Four Lane Highway Tunnel", false },
            { "Avenue Large With Grass", true },
            { "Avenue Large With Grass Bridge", true },
            { "Avenue Large With Grass Elevated", true },
            { "Avenue Large With Grass Slope", true },
            { "Avenue Large With Grass Tunnel", false },
            { "Ferry Line", false },
            { "Avenue Large With Buslanes Grass", true },
            { "Avenue Large With Buslanes Grass Bridge", true },
            { "Avenue Large With Buslanes Grass Elevated", true },
            { "Avenue Large With Buslanes Grass Slope", true },
            { "Avenue Large With Buslanes Grass Tunnel", false },
            { "Ferry Path", false },
            { "Two Lane Highway", true },
            { "Two Lane Highway Barrier", true },
            { "Two Lane Highway Bridge", true },
            { "Two Lane Highway Elevated", true },
            { "Two Lane Highway Slope", true },
            { "Two Lane Highway Tunnel", false },
            { "Ferry Dock", false },
            { "Asymmetrical Three Lane Road", true },
            { "Asymmetrical Three Lane Road Bridge", true },
            { "Asymmetrical Three Lane Road Elevated", true },
            { "Asymmetrical Three Lane Road Slope", true },
            { "Asymmetrical Three Lane Road Tunnel", false },
            { "Ferry Dockway", false },
            { "CableCar Path", false },
            { "CableCar Stop", false },
            { "CableCar Line", false },
            { "Monorail Track", false },
            { "Medium Road Monorail", true },
            { "Monorail Station Track", false },
            { "Monorail Line", false },
            { "Monorail Oneway Track", false },
            { "Medium Road Monorail Station", true },
            { "Blimp Line", false },
            { "Blimp Stop", false },
            { "Blimp Path", false },
            { "Medium Road Monorail Elevated", true },
            { "Blimp Depot Path", false },
            { "Small Road Monorail", true },
            { "Small Road Monorail Bridge", true },
            { "Small Road Monorail Elevated", true },
            { "Zoo Path 01 Elevated", false },
            { "Zoo Path 01 Propless Elevated", false },
            { "Zoo Path 01 Propless", true },
            { "Zoo Path 01", true },
            { "Zoo Path 02", true },
            { "Pedestrian Line", false },
            { "Park Fence 01", true },
            { "Nature Reserve Path 01", true },
            { "Park Path 01", true },
            { "Nature Reserve Fence 01", true },
            { "Zoo Fence 01", false },
            { "Park Path 01 Elevated", false },
            { "Amusement Park Path 01", true },
            { "Sightseeing Bus Line", false },
            { "Amusement Park Path 01 Elevated", false },
            { "Nature Reserve Path 01 Elevated", false },
            { "Amusement Park Fence", false },
            { "Amusement Park Path 01 Propless", true },
            { "Nature Reserve Path 01 Propless", true },
            { "Park Path 01 Propless", true },
            { "Nature Reserve Path 02", true },
            { "Nature Reserve Path 02 Elevated", false },
            { "Park Path 02", true },
            { "Amusement Park Path 02", true },
            { "Amusement Park Path 01 Propless Elevated", false },
            { "Nature Reserve Path 01 Propless Elevated", false },
            { "Park Path 01 Propless Elevated", false },
            { "Farm Fence 01", false },
            { "Forestry Fence 01", false },
            { "Oil Industry Fence 01", false },
            { "Ore Industry Fence 01", false },
            { "Industry Road Medium 01", true },
            { "Industry Road Small 01", true },
            { "Industry Road Medium 01 Bridge", true },
            { "Industry Road Medium 01 Elevated", true },
            { "Industry Road Small 01 Bridge", true },
            { "Industry Road Small 01 Elevated", true },
            { "Industry Road Small 01 Slope", true },
            { "Industry Road Small 01 Tunnel", false },
            { "Industry Road Medium 01 Slope", true },
            { "Industry Road Medium 01 Tunnel", false },
            { "Airplane Cargo Stop", true },
            { "Industry Road Small 01 Oneway", true },
            { "Industry Road Small 01 Oneway Bridge", true },
            { "Industry Road Small 01 Oneway Elevated", true },
            { "Industry Road Small 01 Oneway Slope", true },
            { "Industry Road Small 01 Oneway Tunnel", false },
            { "Liberal Arts Path 01", true },
            { "Liberal Arts Path 01 Elevated", false },
            { "Liberal Arts Path 01 Propless", true },
            { "Liberal Arts Path 01 Propless Elevated", false },
            { "Liberal Arts Path 02", true },
            { "Trade School Path 01", true },
            { "Trade School Path 01 Elevated", false },
            { "Trade School Path 01 Propless", true },
            { "Trade School Path 01 Propless Elevated", false },
            { "Trade School Path 02", true },
            { "University Path 01", true },
            { "University Path 01 Elevated", false },
            { "University Path 01 Propless", true },
            { "University Path 01 Propless Elevated", false },
            { "University Path 02", true },
        };
        private static readonly Dictionary<string, bool> RoadTextureDict = new Dictionary<string, bool> {
            { "Pedestrian Gravel", false },
            { "Pedestrian Pavement", false },
            { "Pedestrian Elevated", false },
            { "Pedestrian Slope", false },
            { "Pedestrian Tunnel", false },
            { "Pedestrian Gravel Elevated", false },
            { "Power Line", false },
            { "Dam", true },
            { "Basic Road", true },
            { "Large Road", true },
            { "Gravel Road", false },
            { "Medium Road", true },
            { "Highway", true },
            { "Highway Elevated", true },
            { "Basic Road Bridge", true },
            { "Basic Road Decoration Trees", true },
            { "HighwayRamp", true },
            { "Highway Barrier", true },
            { "Medium Road Bridge", true },
            { "HighwayRampElevated", true },
            { "Basic Road Elevated", true },
            { "Highway Bridge", true },
            { "Large Road Elevated", true },
            { "Medium Road Elevated", true },
            { "Oneway Road", true },
            { "Oneway Road Elevated", true },
            { "Medium Road Decoration Trees", true },
            { "Medium Road Decoration Grass", true },
            { "Basic Road Decoration Grass", true },
            { "Large Road Decoration Grass", true },
            { "Oneway Road Decoration Grass", true },
            { "Oneway Road Decoration Trees", true },
            { "Large Road Decoration Trees", true },
            { "Large Road Bridge", true },
            { "Oneway Road Bridge", true },
            { "Large Oneway", true },
            { "Large Oneway Bridge", true },
            { "Large Oneway Decoration Grass", true },
            { "Large Oneway Decoration Trees", true },
            { "Large Oneway Elevated", true },
            { "Basic Road Tunnel", false },
            { "Basic Road Slope", true },
            { "Medium Road Slope", true },
            { "Medium Road Tunnel", false },
            { "Oneway Road Slope", true },
            { "Oneway Road Tunnel", false },
            { "Large Road Slope", true },
            { "Large Road Tunnel", false },
            { "Large Oneway Road Slope", true },
            { "Large Oneway Road Tunnel", false },
            { "Highway Slope", true },
            { "Highway Tunnel", false },
            { "HighwayRamp Slope", true },
            { "HighwayRamp Tunnel", false },
            { "Gravel Road Bridge", false },
            { "Gravel Road Elevated", false },
            { "Oneway Toll Road Large 01", true },
            { "Oneway Toll Road Large 01c", true },
            { "Oneway Toll Road Medium 01", true },
            { "Oneway Toll Road Medium 01c", true },
            { "Twoway Toll Road Large 01", true },
            { "Twoway Toll Road Medium 01", true },
            { "Twoway Toll Road Medium 01b", true },
            { "Twoway Toll Road Large 01b", true },
            { "Water Pipe", false },
            { "Canal", true },
            { "Canal2", true },
            { "Canal3", true },
            { "Quay", false },
            { "Flood Wall", false },
            { "Castle Wall 1", false },
            { "Castle Wall 2", false },
            { "Castle Wall 3", false },
            { "Trench Ruins 01", false },
            { "Public Transport Line", false },
            { "Train Track", false },
            { "Train Station Track", false },
            { "Metro Track", false },
            { "Metro Station Track", false },
            { "Pedestrian Connection", false },
            { "Bus Line", false },
            { "Metro Line", false },
            { "Train Line", false },
            { "Airplane Line", false },
            { "Airplane Runway", true },
            { "Airplane Taxiway", false },
            { "Airplane Stop", false },
            { "Airplane Path", false },
            { "Airplane Connection Path", false },
            { "Ship Path", false },
            { "Ship Connection Path", false },
            { "Ship Line", false },
            { "Ship Dockway", false },
            { "Cargo Connection", false },
            { "Train Cargo Track", false },
            { "Train Track Bridge", false },
            { "Train Track Elevated", false },
            { "Harbor Road", true },
            { "Ship Dock", false },
            { "Pedestrian Connection Surface", false },
            { "Train Connection Track", false },
            { "Train Connection Track Elevated", false },
            { "Pedestrian Connection Inside", false },
            { "Pedestrian Connection Underground", false },
            { "Train Track Slope", false },
            { "Train Track Tunnel", false },
            { "Train Cargo Track Elevated", false },
            { "Bus Depot Road", true },
            { "Bus Station Stop", false },
            { "Bus Station Way", false },
            { "Train Oneway Track", false },
            { "Train Oneway Track Bridge", false },
            { "Train Oneway Track Elevated", false },
            { "Train Oneway Track Slope", false },
            { "Train Oneway Track Tunnel", false },
            { "Basic Road Bicycle", true },
            { "Pedestrian Pavement Bicycle", false },
            { "Pedestrian Elevated Bicycle", false },
            { "Medium Road Bicycle", true },
            { "Large Road Bicycle", true },
            { "Large Road Bus", true },
            { "Medium Road Bus", true },
            { "Pedestrian Slope Bicycle", false },
            { "Pedestrian Tunnel Bicycle", false },
            { "Medium Road Bridge Bus", true },
            { "Medium Road Elevated Bus", true },
            { "Medium Road Slope Bus", true },
            { "Medium Road Tunnel Bus", false },
            { "Large Road Bridge Bus", true },
            { "Large Road Elevated Bus", true },
            { "Large Road Slope Bus", true },
            { "Large Road Tunnel Bus", false },
            { "Basic Road Elevated Bike", true },
            { "Basic Road Bridge Bike", true },
            { "Medium Road Bridge Bike", true },
            { "Medium Road Elevated Bike", true },
            { "Large Road Bridge Bike", true },
            { "Large Road Elevated Bike", true },
            { "Basic Road Tram", true },
            { "Tram Line", false },
            { "Basic Road Elevated Tram", true },
            { "Basic Road Bridge Tram", true },
            { "Basic Road Slope Tram", true },
            { "Basic Road Tunnel Tram", false },
            { "Medium Road Tram", true },
            { "Tram Depot Road", true },
            { "Medium Road Elevated Tram", true },
            { "Medium Road Bridge Tram", true },
            { "Medium Road Slope Tram", true },
            { "Medium Road Tunnel Tram", false },
            { "Heating Pipe", false },
            { "Oneway Road Tram", true },
            { "Oneway Road Bridge Tram", true },
            { "Oneway Road Elevated Tram", true },
            { "Oneway Road Slope Tram", true },
            { "Oneway Road Tunnel Tram", false },
            { "Tram Track", true },
            { "Tram Track Bridge", true },
            { "Tram Track Elevated", true },
            { "Tram Track Slope", true },
            { "Tram Track Tunnel", false },
            { "Oneway Tram Track", true },
            { "Oneway Tram Track Bridge", true },
            { "Oneway Tram Track Elevated", true },
            { "Oneway Tram Track Slope", true },
            { "Oneway Tram Track Tunnel", false },
            { "Radio Mast Support Cables", false },
            { "Evacuation Bus Line", false },
            { "Canal Wide", true },
            { "Canal Wide2", true },
            { "Canal Wide3", true },
            { "Two Lane Highway Twoway", true },
            { "Two Lane Highway Twoway Barrier", true },
            { "Two Lane Highway Twoway Bridge", true },
            { "Two Lane Highway Twoway Elevated", true },
            { "Two Lane Highway Twoway Slope", true },
            { "Two Lane Highway Twoway Tunnel", false },
            { "Four Lane Highway", true },
            { "Four Lane Highway Barrier", true },
            { "Four Lane Highway Bridge", true },
            { "Four Lane Highway Elevated", true },
            { "Four Lane Highway Slope", true },
            { "Four Lane Highway Tunnel", false },
            { "Avenue Large With Grass", true },
            { "Avenue Large With Grass Bridge", true },
            { "Avenue Large With Grass Elevated", true },
            { "Avenue Large With Grass Slope", true },
            { "Avenue Large With Grass Tunnel", false },
            { "Ferry Line", false },
            { "Avenue Large With Buslanes Grass", true },
            { "Avenue Large With Buslanes Grass Bridge", true },
            { "Avenue Large With Buslanes Grass Elevated", true },
            { "Avenue Large With Buslanes Grass Slope", true },
            { "Avenue Large With Buslanes Grass Tunnel", false },
            { "Ferry Path", false },
            { "Two Lane Highway", true },
            { "Two Lane Highway Barrier", true },
            { "Two Lane Highway Bridge", true },
            { "Two Lane Highway Elevated", true },
            { "Two Lane Highway Slope", true },
            { "Two Lane Highway Tunnel", false },
            { "Ferry Dock", false },
            { "Asymmetrical Three Lane Road", true },
            { "Asymmetrical Three Lane Road Bridge", true },
            { "Asymmetrical Three Lane Road Elevated", true },
            { "Asymmetrical Three Lane Road Slope", true },
            { "Asymmetrical Three Lane Road Tunnel", false },
            { "Ferry Dockway", false },
            { "CableCar Path", false },
            { "CableCar Stop", false },
            { "CableCar Line", false },
            { "Monorail Track", false },
            { "Medium Road Monorail", true },
            { "Monorail Station Track", false },
            { "Monorail Line", false },
            { "Monorail Oneway Track", false },
            { "Medium Road Monorail Station", true },
            { "Blimp Line", false },
            { "Blimp Stop", false },
            { "Blimp Path", false },
            { "Medium Road Monorail Elevated", true },
            { "Blimp Depot Path", false },
            { "Small Road Monorail", true },
            { "Small Road Monorail Bridge", true },
            { "Small Road Monorail Elevated", true },
            { "Zoo Path 01 Elevated", false },
            { "Zoo Path 01 Propless Elevated", false },
            { "Zoo Path 01 Propless", true },
            { "Zoo Path 01", true },
            { "Zoo Path 02", true },
            { "Pedestrian Line", false },
            { "Park Fence 01", false },
            { "Nature Reserve Path 01", true },
            { "Park Path 01", true },
            { "Nature Reserve Fence 01", false },
            { "Zoo Fence 01", false },
            { "Park Path 01 Elevated", true },
            { "Amusement Park Path 01", true },
            { "Sightseeing Bus Line", false },
            { "Amusement Park Path 01 Elevated", true },
            { "Nature Reserve Path 01 Elevated", false },
            { "Amusement Park Fence", false },
            { "Amusement Park Path 01 Propless", true },
            { "Nature Reserve Path 01 Propless", true },
            { "Park Path 01 Propless", true },
            { "Nature Reserve Path 02", true },
            { "Nature Reserve Path 02 Elevated", false },
            { "Park Path 02", true },
            { "Amusement Park Path 02", true },
            { "Amusement Park Path 01 Propless Elevated", true },
            { "Nature Reserve Path 01 Propless Elevated", false },
            { "Park Path 01 Propless Elevated", true },
            { "Farm Fence 01", false },
            { "Forestry Fence 01", false },
            { "Oil Industry Fence 01", false },
            { "Ore Industry Fence 01", false },
            { "Industry Road Medium 01", true },
            { "Industry Road Small 01", true },
            { "Industry Road Medium 01 Bridge", true },
            { "Industry Road Medium 01 Elevated", true },
            { "Industry Road Small 01 Bridge", true },
            { "Industry Road Small 01 Elevated", true },
            { "Industry Road Small 01 Slope", true },
            { "Industry Road Small 01 Tunnel", false },
            { "Industry Road Medium 01 Slope", true },
            { "Industry Road Medium 01 Tunnel", false },
            { "Airplane Cargo Stop", false },
            { "Industry Road Small 01 Oneway", true },
            { "Industry Road Small 01 Oneway Bridge", true },
            { "Industry Road Small 01 Oneway Elevated", true },
            { "Industry Road Small 01 Oneway Slope", true },
            { "Industry Road Small 01 Oneway Tunnel", false },
            { "Liberal Arts Path 01", true },
            { "Liberal Arts Path 01 Elevated", true },
            { "Liberal Arts Path 01 Propless", true },
            { "Liberal Arts Path 01 Propless Elevated", true },
            { "Liberal Arts Path 02", true },
            { "Trade School Path 01", true },
            { "Trade School Path 01 Elevated", true },
            { "Trade School Path 01 Propless", true },
            { "Trade School Path 01 Propless Elevated", true },
            { "Trade School Path 02", true },
            { "University Path 01", true },
            { "University Path 01 Elevated", true },
            { "University Path 01 Propless", true },
            { "University Path 01 Propless Elevated", true },
            { "University Path 02", true },
        };

        public static bool HasPavementTexture(NetInfo prefab)
        {
            if (PavementTextureDict.TryGetValue(prefab.name, out var result)) return result;

            // The P channel is inverted in APR map!
            return PavementTextureDict[prefab.name] = CalculateHasMatchingPixels(prefab, color => color.g < 0.95);
        }

        public static bool HasRoadTexture(NetInfo prefab)
        {
            if (RoadTextureDict.TryGetValue(prefab.name, out var result)) return result;

            return RoadTextureDict[prefab.name] = CalculateHasMatchingPixels(prefab, color => color.b > 0.05);
        }

        // Caution: Expensive operation, cache result if possible!
        private static bool CalculateHasMatchingPixels(NetInfo prefab, Func<Color, bool> predicate)
        {
            if (prefab != null && prefab.m_segments != null)
            {
                foreach (var segment in prefab.m_segments)
                {
                    if(segment.m_material == null) continue;

                    Texture2D texture = segment.m_material.GetTexture("_APRMap") as Texture2D;
                    if (texture != null)
                    {
                        try
                        {
                            return HasMatchingPixels(texture.GetPixels(), predicate);
                        }
                        catch (UnityException) // texture not readable
                        {
                            Texture2D readableTexture = texture.MakeReadable();
                            bool hasBluePixels = HasMatchingPixels(readableTexture.GetPixels(), predicate);
                            Object.Destroy(readableTexture);
                            return hasBluePixels;
                        }
                    }
                }

            }
            return false;
        }

        private static bool HasMatchingPixels(Color[] pixels, Func<Color, bool> predicate)
        {
            for (int i = 0; i < pixels.Length; i++)
            {
                if (predicate(pixels[i]))
                {
                    return true;
                }
            }
            return false;
        }

#if DEBUG
        // Call this to output values for PavementTextureDict and RoadTextureDict and insert them into this file!
        // That way HasPavementTexture and HasRoadTexture are fast for vanilla prefabs!
        public static void DisplayNetTextureDicts()
        {
            PavementTextureDict.Clear();
            RoadTextureDict.Clear();

            var pavementTexture = new StringBuilder();
            var roadTexture = new StringBuilder();

            for (uint i = 0; i < PrefabCollection<NetInfo>.LoadedCount(); i++)
            {
                var prefab = PrefabCollection<NetInfo>.GetLoaded(i);

                if (prefab == null) continue;

                pavementTexture.Append($"{{ \"{prefab.name}\", {HasPavementTexture(prefab).ToString().ToLower()} }},\n");
                roadTexture.Append($"{{ \"{prefab.name}\", {HasRoadTexture(prefab).ToString().ToLower()} }},\n");
            }

            Debug.Log("PavementTextureDict");
            Debug.Log(pavementTexture.ToString());

            Debug.Log("RoadTextureDict");
            Debug.Log(roadTexture.ToString());
        }
#endif
    }
}
