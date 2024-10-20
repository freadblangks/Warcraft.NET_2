using System.IO;
using Warcraft.NET.Extensions;
using Warcraft.NET.Files.Structures;

namespace Warcraft.NET.Files.WMO.Entries
{
    /// <summary>
    /// An entry struct containing information about a WMO group.
    /// </summary>
    public class MOGIEntry
    {
        /// <summary>
        /// Gets or sets group flags
        /// </summary>
        public uint Flags { get; set; }

        /// <summary>
        /// Gets or sets group bounding box
        /// </summary>
        public BoundingBox BoundingBox { get; set; }

        /// <summary>
        /// Gets or sets offset into MOGN chunk
        /// </summary>
        public int NameOffset { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MOGIEntry"/> class.
        /// </summary>
        public MOGIEntry()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MOGIEntry"/> class.
        /// </summary>
        /// <param name="inData">ExtendedData.</param>
        public MOGIEntry(byte[] inData)
        {
            LoadBinaryData(inData);
        }

        /// <inheritdoc/>
        public static int GetSize()
        {
            return 32;
        }

        /// <inheritdoc/>
        public void LoadBinaryData(byte[] inData)
        {
            using (var ms = new MemoryStream(inData))
            using (var br = new BinaryReader(ms))
            {
                Flags = br.ReadUInt32();
                BoundingBox = br.ReadBoundingBox();
                NameOffset = br.ReadInt32();
            }
        }

        /// <inheritdoc/>
        public byte[] Serialize(long offset = 0)
        {
            using (var ms = new MemoryStream())
            using (var bw = new BinaryWriter(ms))
            {
                bw.Write(Flags);
                bw.WriteBoundingBox(BoundingBox);
                bw.Write(NameOffset);
                return ms.ToArray();
            }
        }
    }
}
