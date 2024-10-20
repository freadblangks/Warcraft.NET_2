using System.Collections.Generic;
using System.IO;
using Warcraft.NET.Attribute;
using Warcraft.NET.Files.Interfaces;
using Warcraft.NET.Files.WMO.Entries;

namespace Warcraft.NET.Files.WMO.Chunks
{
    /// <summary>
    /// MOGI Chunk - Contains information about the groups in the WMO.
    /// </summary>
    [AutoDocChunk(AutoDocChunkVersionHelper.VersionAll)]
    public class MOGI : IIFFChunk, IBinarySerializable
    {
        /// <summary>
        /// Holds the binary chunk signature.
        /// </summary>
        public const string Signature = "MOGI";

        /// <summary>
        /// Gets or sets <see cref="MOGIEntry"s />
        /// </summary>
        public List<MOGIEntry> GroupInfoEntries { get; set; } = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="MOGI"/> class.
        /// </summary>
        public MOGI()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MOGI"/> class.
        /// </summary>
        /// <param name="inData">ExtendedData.</param>
        public MOGI(byte[] inData)
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
                while (ms.Position < ms.Length)
                {
                    var groupCount = br.BaseStream.Length / MOGIEntry.GetSize();
                    for (var i = 0; i < groupCount; ++i)
                        GroupInfoEntries.Add(new MOGIEntry(br.ReadBytes(MOGIEntry.GetSize())));
                }
            }
        }

        /// <inheritdoc/>
        public byte[] Serialize(long offset = 0)
        {
            using (var ms = new MemoryStream())
            using (var bw = new BinaryWriter(ms))
            {
                foreach (var groupInfo in GroupInfoEntries)
                    bw.Write(groupInfo.Serialize());
                return ms.ToArray();
            }
        }
    }
}
