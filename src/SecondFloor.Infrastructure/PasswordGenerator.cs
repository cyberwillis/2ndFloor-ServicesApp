/*
 Util para geracao de passwords
 http://www.codeproject.com/Articles/2393/A-C-Password-Generator
 * 
 * 
 */
using System;
using System.Security.Cryptography;
using System.Text;

namespace SecondFloor.Infrastructure
{
    public class PasswordGenerator
    {
        private const int DefaultMinimum = 6;
        private const int DefaultMaximum = 10;
        private const int UBoundDigit = 61;

        private readonly RNGCryptoServiceProvider _rng;
        private int _minSize;
        private int _maxSize;
        private readonly char[] _pwdCharArray = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789`~!@#$%^&*()-_=+[]{}\\|;:'\",<.>/?".ToCharArray(); 

        public string Exclusions { get; set; }

        public int Minimum
        {
            get { return this._minSize; }
            set	
            { 
                this._minSize = value;
                if ( PasswordGenerator.DefaultMinimum > this._minSize )
                {
                    this._minSize = PasswordGenerator.DefaultMinimum;
                }
            }
        }

        public int Maximum
        {
            get { return this._maxSize; }
            set	
            { 
                this._maxSize = value;
                if ( this._minSize >= this._maxSize )
                {
                    this._maxSize = PasswordGenerator.DefaultMaximum;
                }
            }
        }

        public bool ExcludeSymbols { get; set; }

        public bool RepeatCharacters { get; set; }

        public bool ConsecutiveCharacters { get; set; }

        public PasswordGenerator()
        {
            this.Minimum = DefaultMinimum;
            this.Maximum = DefaultMaximum;
            this.ConsecutiveCharacters = true;
            this.RepeatCharacters = true;
            this.ExcludeSymbols = true;
            this.Exclusions = null;

            _rng = new RNGCryptoServiceProvider();
        }	

        protected int GetCryptographicRandomNumber(int lBound, int uBound)
        {
            // Assumes lBound >= 0 && lBound < uBound
            // returns an int >= lBound and < uBound
            uint urndnum;
            byte[] rndnum = new Byte[4];
            if (lBound == uBound - 1)
            {
                // test for degenerate case where only lBound can be returned   
                return lBound;
            }

            uint xcludeRndBase = (uint.MaxValue - (uint.MaxValue % (uint)(uBound - lBound)));

            do
            {
                _rng.GetBytes(rndnum);
                urndnum = System.BitConverter.ToUInt32(rndnum, 0);
            } while (urndnum >= xcludeRndBase);

            return (int)(urndnum % (uBound - lBound)) + lBound;
        }

        protected char GetRandomCharacter()
        {
            int upperBound = _pwdCharArray.GetUpperBound(0);

            if (true == this.ExcludeSymbols)
            {
                upperBound = PasswordGenerator.UBoundDigit;
            }

            int randomCharPosition = GetCryptographicRandomNumber(_pwdCharArray.GetLowerBound(0), upperBound);

            char randomChar = _pwdCharArray[randomCharPosition];

            return randomChar;
        }

        public string Generate()
        {
            // Pick random length between minimum and maximum   
            int pwdLength = GetCryptographicRandomNumber(this.Minimum, this.Maximum);

            StringBuilder pwdBuffer = new StringBuilder();
            pwdBuffer.Capacity = this.Maximum;

            // Generate random characters
            char lastCharacter, nextCharacter;

            // Initial dummy character flag
            lastCharacter = nextCharacter = '\n';

            for (int i = 0; i < pwdLength; i++)
            {
                nextCharacter = GetRandomCharacter();

                if (false == this.ConsecutiveCharacters)
                {
                    while (lastCharacter == nextCharacter)
                    {
                        nextCharacter = GetRandomCharacter();
                    }
                }

                if (false == this.RepeatCharacters)
                {
                    string temp = pwdBuffer.ToString();
                    int duplicateIndex = temp.IndexOf(nextCharacter);
                    while (-1 != duplicateIndex)
                    {
                        nextCharacter = GetRandomCharacter();
                        duplicateIndex = temp.IndexOf(nextCharacter);
                    }
                }

                if ((null != this.Exclusions))
                {
                    while (-1 != this.Exclusions.IndexOf(nextCharacter))
                    {
                        nextCharacter = GetRandomCharacter();
                    }
                }

                pwdBuffer.Append(nextCharacter);
                lastCharacter = nextCharacter;
            }

            if (null != pwdBuffer)
            {
                return pwdBuffer.ToString();
            }
            else
            {
                return String.Empty;
            }
        }
    }
}