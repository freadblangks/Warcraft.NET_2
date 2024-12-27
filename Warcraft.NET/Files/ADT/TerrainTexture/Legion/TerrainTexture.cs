using Warcraft.NET.Attribute;

namespace Warcraft.NET.Files.ADT.TerrainTexture.Legion
{
    [AutoDocFile("adt", "_tex0 ADT")]
    public class TerrainTexture : TerrainTextureBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TerrainTexture"/> class.
        /// </summary>
        public TerrainTexture() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TerrainTexture"/> class.
        /// </summary>
        /// <param name="inData">The binary data.</param>
        public TerrainTexture(byte[] inData) : base(inData)
        {
        }
    }
}
