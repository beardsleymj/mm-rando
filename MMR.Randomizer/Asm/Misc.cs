﻿using Be.IO;
using MMR.Common.Extensions;
using MMR.Randomizer.Models;
using MMR.Randomizer.Models.Settings;
using MMR.Randomizer.Utils;
using System.IO;

namespace MMR.Randomizer.Asm
{
    /// <summary>
    /// Crit wiggle state value.
    /// </summary>
    public enum CritWiggleState : byte
    {
        Default,
        AlwaysOn,
        AlwaysOff,
    }

    public enum QuestConsumeState : byte
    {
        Default,
        Always,
        Never,
    }

    /// <summary>
    /// Speedups.
    /// </summary>
    public class MiscSpeedups
    {
        /// <summary>
        /// Whether or not to end Blast Mask Thief escape sequence early once the luggage is dropped.
        /// </summary>
        public bool BlastMaskThief { get; set; }

        /// <summary>
        /// Whether or not to end Boat Archery early if the player has enough points.
        /// </summary>
        public bool BoatArchery { get; set; }

        /// <summary>
        /// Whether or not to end Fisherman's Game early if the player has enough points.
        /// </summary>
        public bool FishermanGame { get; set; }

        /// <summary>
        /// Whether or not to change Sound Check to speed up actor cutscenes until song is fully composed.
        /// </summary>
        public bool SoundCheck { get; set; }

        /// <summary>
        /// Whether or not to change the hungry Goron to set a different value when rolling away and add more coordinates to his path.
        /// </summary>
        public bool DonGero { get; set; }

        /// <summary>
        /// Convert to a <see cref="uint"/> integer.
        /// </summary>
        /// <returns>Integer</returns>
        public uint ToInt()
        {
            uint flags = 0;
            flags |= (this.SoundCheck ? (uint)1 : 0) << 31;
            flags |= (this.BlastMaskThief ? (uint)1 : 0) << 30;
            flags |= (this.FishermanGame ? (uint)1 : 0) << 29;
            flags |= (this.BoatArchery ? (uint)1 : 0) << 28;
            flags |= (this.DonGero ? (uint)1 : 0) << 27;
            return flags;
        }
    }

    /// <summary>
    /// Miscellaneous flags.
    /// </summary>
    public class MiscFlags
    {
        /// <summary>
        /// Whether or not to enable cycling arrow types while using the bow.
        /// </summary>
        public bool ArrowCycling { get; set; }

        /// <summary>
        /// Whether or not to show magic being consumed ahead of time when using elemental arrows.
        /// </summary>
        public bool ArrowMagic => ArrowCycling;

        /// <summary>
        /// Behaviour of crit wiggle.
        /// </summary>
        public CritWiggleState CritWiggle { get; set; }

        /// <summary>
        /// Whether or not to disable crit wiggle (alternative state is default behaviour).
        /// </summary>
        public bool CritWiggleDisable {
            get { return (this.CritWiggle == CritWiggleState.AlwaysOff) ? true : false; }
            set { this.CritWiggle = (value ? CritWiggleState.AlwaysOff : CritWiggleState.Default); }
        }

        /// <summary>
        /// Whether or not to use the closest cow to the player when giving an item.
        /// </summary>
        public bool CloseCows { get; set; }

        /// <summary>
        /// Whether or not to draw hash icons on the file select screen.
        /// </summary>
        public bool DrawHash { get; set; } = true;

        /// <summary>
        /// Whether or not to apply Elegy of Emptiness speedups.
        /// </summary>
        public bool ElegySpeedup { get; set; }

        /// <summary>
        /// Whether or not to enable faster pushing and pulling speeds.
        /// </summary>
        public bool FastPush { get; set; }

        /// <summary>
        /// Whether or not to enable freestanding models.
        /// </summary>
        public bool FreestandingModels { get; set; } = true;

        /// <summary>
        /// Whether or not to enable continuous deku hopping.
        /// </summary>
        public bool ContinuousDekuHopping { get; set; } = false;

        /// <summary>
        /// Whether or not to enable shop models.
        /// </summary>
        public bool ShopModels { get; set; } = true;

        /// <summary>
        /// Whether or not to enable progressive upgrades.
        /// </summary>
        public bool ProgressiveUpgrades { get; set; } = true;

        /// <summary>
        /// Whether or not ice traps should behave slightly differently from other items in certain situations.
        /// </summary>
        public bool IceTrapQuirks { get; set; }

        /// <summary>
        /// Whether or not to allow using the ocarina underwater.
        /// </summary>
        public bool OcarinaUnderwater { get; set; }

        /// <summary>
        /// Behaviour of how quest items should be consumed.
        /// </summary>
        public QuestConsumeState QuestConsume => this.QuestItemStorage ? QuestConsumeState.Always : QuestConsumeState.Default;

        /// <summary>
        /// Whether or not to enable Quest Item Storage.
        /// </summary>
        public bool QuestItemStorage { get; set; } = true;

        public MiscFlags()
        {
        }

        public MiscFlags(uint flags)
        {
            Load(flags);
        }

        /// <summary>
        /// Load from a <see cref="uint"/> integer.
        /// </summary>
        /// <param name="flags">Flags integer</param>
        void Load(uint flags)
        {
            this.CritWiggle = (CritWiggleState)(flags >> 30);
            this.DrawHash = ((flags >> 29) & 1) == 1;
            this.FastPush = ((flags >> 28) & 1) == 1;
            this.OcarinaUnderwater = ((flags >> 27) & 1) == 1;
            this.QuestItemStorage = ((flags >> 26) & 1) == 1;
            this.CloseCows = ((flags >> 25) & 1) == 1;
            this.FreestandingModels = ((flags >> 24) & 1) == 1;
            this.ArrowCycling = ((flags >> 21) & 1) == 1;
            this.ContinuousDekuHopping = ((flags >> 18) & 1) == 1;
            this.ShopModels = ((flags >> 17) & 1) == 1;
            this.ProgressiveUpgrades = ((flags >> 16) & 1) == 1;
            this.IceTrapQuirks = ((flags >> 15) & 1) == 1;
        }

        /// <summary>
        /// Convert to a <see cref="uint"/> integer.
        /// </summary>
        /// <returns>Integer</returns>
        public uint ToInt()
        {
            uint flags = 0;
            flags |= (((uint)this.CritWiggle) & 3) << 30;
            flags |= (this.DrawHash ? (uint)1 : 0) << 29;
            flags |= (this.FastPush ? (uint)1 : 0) << 28;
            flags |= (this.OcarinaUnderwater ? (uint)1 : 0) << 27;
            flags |= (this.QuestItemStorage ? (uint)1 : 0) << 26;
            flags |= (this.CloseCows ? (uint)1 : 0) << 25;
            flags |= (this.FreestandingModels ? (uint)1 : 0) << 24;
            flags |= (((uint)this.QuestConsume) & 3) << 22;
            flags |= (this.ArrowCycling ? (uint)1 : 0) << 21;
            flags |= (this.ArrowMagic ? (uint)1 : 0) << 20;
            flags |= (this.ElegySpeedup ? (uint)1 : 0) << 19;
            flags |= (this.ContinuousDekuHopping ? (uint)1 : 0) << 18;
            flags |= (this.ShopModels ? (uint)1 : 0) << 17;
            flags |= (this.ProgressiveUpgrades ? (uint)1 : 0) << 16;
            flags |= (this.IceTrapQuirks ? (uint)1 : 0) << 15;
            return flags;
        }
    }

    /// <summary>
    /// Internal flags.
    /// </summary>
    public class InternalFlags
    {
        /// <summary>
        /// Whether or not Vanilla Layout is being used, which determines if certain mod files are included.
        /// </summary>
        public bool VanillaLayout { get; set; }

        /// <summary>
        /// Convert to a <see cref="uint"/> integer.
        /// </summary>
        /// <returns>Integer</returns>
        public uint ToInt()
        {
            uint flags = 0;
            flags |= (this.VanillaLayout ? (uint)1 : 0) << 31;
            return flags;
        }
    }

    /// <summary>
    /// Miscellaneous configuration structure.
    /// </summary>
    public struct MiscConfigStruct : IAsmConfigStruct
    {
        public uint Version;
        public byte[] Hash;
        public uint Flags;
        public uint InternalFlags;
        public uint Speedups;

        /// <summary>
        /// Convert to bytes.
        /// </summary>
        /// <returns>Bytes</returns>
        public byte[] ToBytes()
        {
            using (var memStream = new MemoryStream())
            using (var writer = new BeBinaryWriter(memStream))
            {
                writer.WriteUInt32(this.Version);

                // Version 0
                writer.WriteBytes(this.Hash);
                writer.WriteUInt32(this.Flags);

                // Version 1
                if (this.Version >= 1)
                {
                    writer.WriteUInt32(this.InternalFlags);
                }

                // Version 3
                if (this.Version >= 3)
                {
                    writer.WriteUInt32(this.Speedups);
                }

                return memStream.ToArray();
            }
        }
    }

    /// <summary>
    /// Miscellaneous configuration.
    /// </summary>
    public class MiscConfig : AsmConfig
    {
        /// <summary>
        /// Hash bytes.
        /// </summary>
        public byte[] Hash { get; set; }

        /// <summary>
        /// Flags.
        /// </summary>
        public MiscFlags Flags { get; set; }

        /// <summary>
        /// Internal flags.
        /// </summary>
        public InternalFlags InternalFlags { get; set; }

        /// <summary>
        /// Speedups.
        /// </summary>
        public MiscSpeedups Speedups { get; set; }

        public MiscConfig()
            : this(new byte[0], new MiscFlags(), new InternalFlags(), new MiscSpeedups())
        {
        }

        public MiscConfig(byte[] hash, MiscFlags flags, InternalFlags internalFlags, MiscSpeedups speedups)
        {
            this.Hash = hash;
            this.Flags = flags;
            this.InternalFlags = internalFlags;
            this.Speedups = speedups;
        }

        /// <summary>
        /// Finalize configuration using <see cref="GameplaySettings"/>.
        /// </summary>
        /// <param name="settings">Settings</param>
        public void FinalizeSettings(GameplaySettings settings)
        {
            // Update speedup flags which correspond with ShortenCutscenes.
            this.Speedups.BlastMaskThief = settings.ShortenCutscenes;
            this.Speedups.BoatArchery = settings.ShortenCutscenes;
            this.Speedups.FishermanGame = settings.ShortenCutscenes;
            this.Speedups.SoundCheck = settings.ShortenCutscenes;
            this.Speedups.DonGero = settings.ShortenCutscenes;

            // Update internal flags.
            this.InternalFlags.VanillaLayout = settings.LogicMode == LogicMode.Vanilla;
        }

        /// <summary>
        /// Get a <see cref="MiscConfigStruct"/> representation.
        /// </summary>
        /// <param name="version">Structure version</param>
        /// <returns>Configuration structure</returns>
        public override IAsmConfigStruct ToStruct(uint version)
        {
            var hash = ReadWriteUtils.CopyBytes(this.Hash, 0x10);

            return new MiscConfigStruct
            {
                Version = version,
                Hash = hash,
                Flags = this.Flags.ToInt(),
                InternalFlags = this.InternalFlags.ToInt(),
                Speedups = this.Speedups.ToInt(),
            };
        }
    }
}
