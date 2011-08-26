//-----------------------------------------------------------------------
// <copyright file="Crc32.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------

namespace NdsCRC_III
{
    #region Exemple
    ////Crc32 crc32 = new Crc32();
    ////String hash = String.Empty;

    ////using (FileStream fs = File.Open("c:\\myfile.txt", FileMode.Open))
    ////    foreach (byte b in crc32.ComputeHash(fs)) hash += b.ToString("x2").ToLower();

    ////Console.WriteLine("CRC-32 is {0}", hash);
    #endregion

    using System;
    using System.Security.Cryptography;

    /// <summary>
    /// Calculate the CRC32 of a file
    /// </summary>
    public class Crc32 : HashAlgorithm
    {
        /// <summary>
        /// DefaultPolynomial
        /// </summary>
        public const uint DefaultPolynomial = 0xedb88320;

        /// <summary>
        /// DefaultSeed
        /// </summary>
        public const uint DefaultSeed = 0xffffffff;

        /// <summary>
        /// Default table
        /// </summary>
        private static uint[] defaultTable;

        /// <summary>
        /// hash
        /// </summary>
        private uint hash;

        /// <summary>
        /// seed
        /// </summary>
        private uint seed;

        /// <summary>
        /// table
        /// </summary>
        private uint[] table;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public Crc32()
        {
            table = InitializeTable(DefaultPolynomial);
            seed = DefaultSeed;
            Initialize();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="polynomial">polynomial</param>
        /// <param name="seed">seed</param>
        public Crc32(uint polynomial, uint seed)
        {
            table = InitializeTable(polynomial);
            this.seed = seed;
            Initialize();
        }

        /// <summary>
        /// HashSize
        /// </summary>
        public override int HashSize
        {
            get { return 32; }
        }

        /// <summary>
        /// Compute
        /// </summary>
        /// <param name="buffer">buffer</param>
        /// <returns>uint</returns>
        public static uint Compute(byte[] buffer)
        {
            return ~CalculateHash(InitializeTable(DefaultPolynomial), DefaultSeed, buffer, 0, buffer.Length);
        }

        /// <summary>
        /// Compute
        /// </summary>
        /// <param name="seed">seed</param>
        /// <param name="buffer">buffer</param>
        /// <returns>uint</returns>
        public static uint Compute(uint seed, byte[] buffer)
        {
            return ~CalculateHash(InitializeTable(DefaultPolynomial), seed, buffer, 0, buffer.Length);
        }

        /// <summary>
        /// Compute
        /// </summary>
        /// <param name="polynomial">polynomial</param>
        /// <param name="seed">seed</param>
        /// <param name="buffer">buffer</param>
        /// <returns>uint</returns>
        public static uint Compute(uint polynomial, uint seed, byte[] buffer)
        {
            return ~CalculateHash(InitializeTable(polynomial), seed, buffer, 0, buffer.Length);
        }

        /// <summary>
        /// FormatCRC32Result
        /// </summary>
        /// <param name="result">result</param>
        /// <returns>string</returns>
        public static string FormatCRC32Result(byte[] result)
        {
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(result);
            }

            return BitConverter.ToUInt32(result, 0).ToString("X8").ToLower();
        }

        /// <summary>
        /// Initialize
        /// </summary>
        public override void Initialize()
        {
            hash = seed;
        }

        /// <summary>
        /// HashCore
        /// </summary>
        /// <param name="buffer">buffer</param>
        /// <param name="start">start</param>
        /// <param name="length">length</param>
        protected override void HashCore(byte[] buffer, int start, int length)
        {
            hash = CalculateHash(table, hash, buffer, start, length);
        }

        /// <summary>
        /// HashFinal
        /// </summary>
        /// <returns>byte[]</returns>
        protected override byte[] HashFinal()
        {
            byte[] hashBuffer = UInt32ToBigEndianBytes(~hash);
            this.HashValue = hashBuffer;
            return hashBuffer;
        }

        /// <summary>
        /// InitializeTable
        /// </summary>
        /// <param name="polynomial">polynomial</param>
        /// <returns>uint[]</returns>
        private static uint[] InitializeTable(uint polynomial)
        {
            if (polynomial == DefaultPolynomial && defaultTable != null)
            {
                return defaultTable;
            }

            uint[] createTable = new uint[256];
            for (int i = 0; i < 256; i++)
            {
                uint entry = (uint)i;
                for (int j = 0; j < 8; j++)
                {
                    if ((entry & 1) == 1)
                    {
                        entry = (entry >> 1) ^ polynomial;
                    }
                    else
                    {
                        entry = entry >> 1;
                    }
                }

                createTable[i] = entry;
            }

            if (polynomial == DefaultPolynomial)
            {
                defaultTable = createTable;
            }

            return createTable;
        }

        /// <summary>
        /// CalculateHash
        /// </summary>
        /// <param name="table">table</param>
        /// <param name="seed">seed</param>
        /// <param name="buffer">buffer</param>
        /// <param name="start">start</param>
        /// <param name="size">size</param>
        /// <returns>uint</returns>
        private static uint CalculateHash(uint[] table, uint seed, byte[] buffer, int start, int size)
        {
            uint crc = seed;
            for (int i = start; i < size; i++)
            {
                unchecked
                {
                    crc = (crc >> 8) ^ table[buffer[i] ^ crc & 0xff];
                }
            }

            return crc;
        }

        /// <summary>
        /// UInt32ToBigEndianBytes
        /// </summary>
        /// <param name="x">x</param>
        /// <returns>byte[]</returns>
        private byte[] UInt32ToBigEndianBytes(uint x)
        {
            return new byte[] 
            {
                (byte)((x >> 24) & 0xff),
                (byte)((x >> 16) & 0xff),
                (byte)((x >> 8) & 0xff),
                (byte)(x & 0xff)
            };
        }
    }
}
