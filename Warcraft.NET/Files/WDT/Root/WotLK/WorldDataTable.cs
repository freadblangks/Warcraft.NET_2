using Warcraft.NET.Attribute;

namespace Warcraft.NET.Files.WDT.Root.WotLK
{
    [AutoDocFile("wdt", "Root WDT")]
    public class WorldDataTable : WorldDataTableBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorldDataTableBase"/> class.
        /// </summary>
        public WorldDataTable() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldDataTable"/> class.
        /// </summary>
        /// <param name="inData">The binary data.</param>
        public WorldDataTable(byte[] inData) : base(inData)
        {
        }
    }
}
