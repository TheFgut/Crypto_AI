using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CryptoAnalizerAI
{
    
    public class Settings
    {
        //availbale pairs
        
        public AwailableCryptoPairs awailablePairs { get; private set; } = new AwailableCryptoPairs();

        public CryptoPair choosedPair { get; set; } = new CryptoPair(Crypto.APE, Crypto.BUSD);
        public Settings()
        {

        }

        public void setCurrentPair(CryptoPair pair)
        {
            choosedPair = pair;
        }
        
        public class AwailableCryptoPairs
        {
            public CryptoPair[] availablePairs { get; private set; }

            public AwailableCryptoPairs()
            {
                availablePairs = new CryptoPair[] { new CryptoPair(Crypto.BNB, Crypto.BUSD), new CryptoPair(Crypto.ALICE, Crypto.BUSD),
            new CryptoPair(Crypto.BTC, Crypto.BUSD),new CryptoPair(Crypto.APE, Crypto.BUSD),new CryptoPair(Crypto.GAL, Crypto.BUSD),
            new CryptoPair(Crypto.LUNA, Crypto.BUSD),new CryptoPair(Crypto.BTC, Crypto.USDC),new CryptoPair(Crypto.BTC, Crypto.USDT),
                new CryptoPair(Crypto.APE, Crypto.USDT)};
            }

            public Crypto[] getAvailableMainCryptos()
            {
                List<Crypto> types = new List<Crypto>();
                foreach (CryptoPair pair in availablePairs)
                {
                    if (!types.Contains(pair.first))
                    {
                        types.Add(pair.first);
                    }
                }
                return types.ToArray();
            }

            public Crypto[] getAvailableComparedCryptos(Crypto main)
            {
                List<Crypto> types = new List<Crypto>();
                foreach (CryptoPair pair in availablePairs)
                {
                    if (main != pair.first) continue;
                    if (!types.Contains(pair.second))
                    {
                        types.Add(pair.second);
                    }
                }
                return types.ToArray();
            }
        }
    }



}
