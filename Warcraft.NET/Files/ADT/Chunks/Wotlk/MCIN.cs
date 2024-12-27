﻿using Warcraft.NET.Files.ADT.Entries.Wotlk;
using Warcraft.NET.Files.Interfaces;
using System.Collections.Generic;
using System.IO;
using Warcraft.NET.Attribute;

namespace Warcraft.NET.Files.ADT.Chunks.Wotlk
{
    /// <summary>
    /// MCIN Chunk - Contains a list of all MCNKs with associated information in the ADT file.
    /// </summary>
    [AutoDocChunk(AutoDocChunkVersion.LK, AutoDocChunkVersionHelper.VersionAfterLK)]
    public class MCIN : IIFFChunk, IBinarySerializable
    {
        public const string Signature = "MCIN";

        /// <summary>
        /// Gets or sets <see cref="MCNK"/> pointers.
        /// <para>Should always be 256.</para>
        /// </summary>
        public List<MCINEntry> Entries { get; set; } = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="MCIN"/> class.
        /// </summary>
        public MCIN()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MCIN"/> class.
        /// </summary>
        /// <param name="inData">ExtendedData.</param>
        public MCIN(byte[] inData)
        {
            LoadBinaryData(inData);
        }

        /// <inheritdoc/>
        public string GetSignature()
        {
            return Signature;
        }

        /// <inheritdoc/>
        public uint GetSize()
        {
            return (uint)Serialize().Length;
        }

        /// <inheritdoc/>
        public void LoadBinaryData(byte[] inData)
        {
            using (var ms = new MemoryStream(inData))
            using (var br = new BinaryReader(ms))
            {
                var entryCount = br.BaseStream.Length / MCINEntry.GetSize();

                for (var i = 0; i < entryCount; ++i)
                {
                    Entries.Add(new MCINEntry(br.ReadBytes(MCINEntry.GetSize())));
                }
            }
        }

        /// <inheritdoc/>
        public byte[] Serialize(long offset = 0)
        {
            using (var ms = new MemoryStream())
            using (var bw = new BinaryWriter(ms))
            {
                foreach (MCINEntry entry in Entries)
                {
                    bw.Write(entry.Serialize());
                }

                return ms.ToArray();
            }
        }
    }
}
