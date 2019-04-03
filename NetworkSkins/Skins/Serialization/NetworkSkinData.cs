﻿using System;
using System.Collections.Generic;
using ColossalFramework.IO;

namespace NetworkSkins.Skins.Serialization
{
    public class NetworkSkinData : IDataContainer
    {
        public const int Version = 0;

        public readonly NetworkSkinLoadErrors Errors = new NetworkSkinLoadErrors();

        public readonly List<NetworkSkin> AppliedSkins;

        public readonly NetworkSkin[] SegmentSkins;
        public readonly NetworkSkin[] NodeSkins;

        // empty constructor is required!
        public NetworkSkinData()
        {
            // This is not nice, but this is how the IDataContainer contract works!
            AppliedSkins = new List<NetworkSkin>(NetworkSkinManager.instance.AppliedSkins);
            SegmentSkins = NetworkSkinManager.SegmentSkins;
            NodeSkins = NetworkSkinManager.NodeSkins;
        }

        public void Serialize(DataSerializer s)
        {
            if (AppliedSkins.Count >= ushort.MaxValue - 1)
            {
                throw new Exception("Too many applied skins, cannot serialize!");
            }

            s.WriteInt32(AppliedSkins.Count);
            foreach (var appliedSkin in AppliedSkins)
            {
                appliedSkin.Serialize(s);
            }

            s.WriteInt32(SegmentSkins.Length);
            foreach (var segmentSkin in SegmentSkins)
            {
                s.WriteUInt16(IndexOfAppliedSkin(segmentSkin));
            }

            s.WriteInt32(NodeSkins.Length);
            foreach (var nodeSkin in NodeSkins)
            {
                s.WriteUInt16(IndexOfAppliedSkin(nodeSkin));
            }
        }

        public ushort IndexOfAppliedSkin(NetworkSkin skin)
        {
            if (skin != null)
            {
                for (ushort j = 0; j < AppliedSkins.Count; j++)
                {
                    if (ReferenceEquals(skin, AppliedSkins[j]))
                    {
                        return (ushort)(j + 1);
                    }
                }
            }
            return 0;
        }

        public void Deserialize(DataSerializer s)
        {
            var appliedSkinsLength = s.ReadInt32();
            AppliedSkins.Clear();
            for (var i = 0; i < appliedSkinsLength; i++)
            {
                AppliedSkins.Add(NetworkSkin.Deserialize(s, Errors));
            }

            var segmentSkinsLength = s.ReadInt32();
            for (var i = 0; i < segmentSkinsLength; i++)
            {
                var skinIndex = s.ReadUInt16();
                if (SegmentSkins.Length > i)
                {
                    SegmentSkins[i] = AppliedSkinForIndex(skinIndex);
                }
            }

            var nodeSkinsLength = s.ReadInt32();
            for (var i = 0; i < nodeSkinsLength; i++)
            {
                var skinIndex = s.ReadUInt16();
                if (NodeSkins.Length > i)
                {
                    NodeSkins[i] = AppliedSkinForIndex(skinIndex);
                }
            }
        }

        public NetworkSkin AppliedSkinForIndex(uint index)
        {
            if (index > 0 && AppliedSkins.Count > index)
            {
                return AppliedSkins[(int)(index - 1)];
            }
            else
            {
                return null;
            }
        }

        public void AfterDeserialize(DataSerializer s) { }
    }
}
