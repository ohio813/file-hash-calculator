﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace FileHashCalculator.CustomHashAlgorithms
{
    public class MD2
    {
        byte[] data = new byte[16];
        byte[] state = new byte[48];
        byte[] checksum = new byte[16];
        int len; 

        private byte[] s = new byte[] { 41, 46, 67, 201, 162, 216, 124, 1, 61, 54, 84, 161, 236, 240, 6, 
            19, 98, 167, 5, 243, 192, 199, 115, 140, 152, 147, 43, 217, 188,
            76, 130, 202, 30, 155, 87, 60, 253, 212, 224, 22, 103, 66, 111, 24,
            138, 23, 229, 18, 190, 78, 196, 214, 218, 158, 222, 73, 160, 251,
            245, 142, 187, 47, 238, 122, 169, 104, 121, 145, 21, 178, 7, 63,
            148, 194, 16, 137, 11, 34, 95, 33, 128, 127, 93, 154, 90, 144, 50,
            39, 53, 62, 204, 231, 191, 247, 151, 3, 255, 25, 48, 179, 72, 165,
            181, 209, 215, 94, 146, 42, 172, 86, 170, 198, 79, 184, 56, 210,
            150, 164, 125, 182, 118, 252, 107, 226, 156, 116, 4, 241, 69, 157,
            112, 89, 100, 113, 135, 32, 134, 91, 207, 101, 230, 45, 168, 2, 27,
            96, 37, 173, 174, 176, 185, 246, 28, 70, 97, 105, 52, 64, 126, 15,
            85, 71, 163, 35, 221, 81, 175, 58, 195, 92, 249, 206, 186, 197,
            234, 38, 44, 83, 13, 110, 133, 40, 132, 9, 211, 223, 205, 244, 65,
            129, 77, 82, 106, 220, 55, 200, 108, 193, 171, 250, 36, 225, 123,
            8, 12, 189, 177, 74, 120, 136, 149, 139, 227, 99, 232, 109, 233,
            203, 213, 254, 59, 0, 29, 57, 242, 239, 183, 14, 102, 88, 208, 228,
            166, 119, 114, 248, 235, 117, 75, 10, 49, 68, 80, 180, 143, 237,
            31, 26, 219, 153, 141, 51, 159, 17, 131, 20 
        };

        public void Initialize()
        {
            int i;

            for (i = 0; i < 48; ++i)
                this.state[i] = 0;

            for (i = 0; i < 16; ++i)
                this.checksum[i] = 0;

            this.len = 0; 
        }

        public void Transform(byte[] data)
        {
            int j, k, t;
 
            for (j = 0; j < 16; ++j)
            {
                this.state[j + 16] = data[j];
                this.state[j + 32] = (byte)(this.state[j + 16] ^ this.state[j]);
            }

            t = 0;
            for (j = 0; j < 18; ++j)
            {
                for (k = 0; k < 48; ++k)
                {
                    this.state[k] ^= s[t];
                    t = this.state[k];
                }
                t = (t + j) & 0xFF;
            }

            t = this.checksum[15];
            for (j = 0; j < 16; ++j)
            {
                this.checksum[j] ^= s[data[j] ^ t];
                t = this.checksum[j];
            }  
        }

        public void Update(byte[] data, int len) 
        {  
           int t,i;
           for (i=0; i < len; ++i) { 
              this.data[this.len] = data[i]; 
              this.len++; 
              if (this.len == 16) { 
                 Transform(this.data); 
                 this.len = 0; 
              }
           }      
        }

        public byte[] Final()
        {
            int to_pad = 16 - this.len;
            byte[] output = new byte[16];

            while (this.len < 16)
                this.data[this.len++] = (byte)to_pad;

            Transform(this.data);
            Transform(this.checksum);

            Array.Copy(this.state, output, 16);
            return output;
        }

        public byte[] Compute(byte[] data)
        {
            Initialize();
            Update(data, data.Length);
            return Final();
        }
    }
}
