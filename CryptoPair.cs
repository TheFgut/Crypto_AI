using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoAnalizerAI
{
    public class CryptoPair
    {
        public Crypto first { get; set; }
        public Crypto second { get; set; }
        public CryptoPair()
        {

        }

        public CryptoPair(Crypto first, Crypto second)
        {
            this.first = first;
            this.second = second;
        }
    }

    public enum Crypto
    {
        BNB,
        ALICE,
        BTC,
        BUSD,
        USDT,
        USDC,
        APE,
        GAL,
        LUNA
    }
}
