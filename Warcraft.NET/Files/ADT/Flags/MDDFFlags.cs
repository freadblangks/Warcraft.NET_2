using System;

namespace Warcraft.NET.Files.ADT.Flags
{
    /// <summary>
    /// Flags for the <see cref="MDDFEntry"/>.
    /// </summary>
    [Flags]
    public enum MDDFFlags : ushort
    {
        /// <summary>
        /// Biodome. Perhaps a skybox?
        /// </summary>
        Biodome = 0x1,

        /// <summary>
        /// Possibly used for vegetation and grass.
        /// </summary>
        Shrubbery = 0x2,

        /// <summary>
        /// Unknown Flag (Legion)
        /// </summary>
        Unknown4 = 0x4,

        /// <summary>
        /// Unknown Flag (Legion)
        /// </summary>
        Unknown8 = 0x8,

        /// <summary>
        /// Liquied_Known 
        /// </summary>
        LiquidKnown = 0x20,

        /// <summary>
        /// Flag to skip MMID and MMDX and point directly to CASC Filedata Ids for more performance (Legion)
        /// </summary>
        NameIdIsFiledataId = 0x40,

        /// <summary>
        /// Unknown Flag (Legion)
        /// </summary>
        Unknown100 = 0x100,

        /// <summary>
        /// Unknown Flag
        /// </summary>
        Unknown200 = 0x200,

        /// <summary>
        /// Unknown Flag
        /// </summary>
        Unknown400 = 0x400,

        /// <summary>
        /// Unknown Flag
        /// </summary>
        Unknown800 = 0x800,

        /// <summary>
        /// Unknown Flag
        /// </summary>
        Unknown1000 = 0x1000,

        /// <summary>
        /// Unknown Flag
        /// </summary>
        Unknown2000 = 0x2000,

        /// <summary>
        /// Unknown Flag
        /// </summary>
        Unknown4000 = 0x4000,
    }
}
