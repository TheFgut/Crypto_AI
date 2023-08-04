using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Collections.ObjectModel;

namespace CryptoAnalizerAI
{

    public class BinanceWebParser
    {

        private IWebDriver driver { get; set; }
        public BinanceWebParser(CryptoPair pair)
        {
            string url = "https://www.binance.com/en/trade/" + pair.first.ToString() + "_" + pair.second.ToString();
            driver = new EdgeDriver(System.IO.Directory.GetCurrentDirectory() + @"\EdgeDriver");
            driver.Manage().Window.Maximize();
            driver.Url = url;

        }



        public float curentPrice()
        {
            string[] value = driver.FindElement(By.ClassName("showPrice")).Text.Split('.');
            return float.Parse(value[0] + "," + value[1]);
        }

        public void curentBinanceBuyAndSellOrders(out float[] SellOrders, out float[] BuyOrders, int limit = 6)
        {
            //нахождение ордеров на продажу
            ReadOnlyCollection<IWebElement> lists = driver.FindElements(By.ClassName("orderbook-list-container"));
            ReadOnlyCollection<IWebElement> elements = lists[0].FindElements(By.ClassName("orderbook-progress"));

            int count = elements.Count;
            if (count > limit)
            {
                count = limit;
            }
            SellOrders = new float[count];
            int num = 0;
            int coef = elements.Count - SellOrders.Length;
            for (int i = SellOrders.Length - 1; i >= 0; i--)
            {
                string[] info = elements[i + coef].Text.Split((char)10);
                string[] fl = info[2].Split(',');
                string strg = null;
                for (int o = 0; o < fl.Length - 1; o++)
                {
                    strg += fl[o];
                }
                fl = fl[fl.Length - 1].Split('.');
                if (fl.Length > 1)
                {
                    strg += fl[0] + "," + fl[1];
                }
                else
                {
                    strg += fl[0];
                }
                SellOrders[num] = float.Parse(strg);
                num++;
            }
            //нахождение ордеров на покупку
            elements = lists[1].FindElements(By.ClassName("orderbook-progress"));

            count = elements.Count;
            if (count > limit)
            {
                count = limit;
            }
            BuyOrders = new float[count];
            num = 1;
            for (int i = BuyOrders.Length - 1; i >= 0; i--)
            {
                string[] info = elements[i].Text.Split((char)10);
                string[] fl = info[2].Split(',');
                string strg = null;
                for (int o = 0; o < fl.Length - 1; o++)
                {
                    strg += fl[o];
                }
                fl = fl[fl.Length - 1].Split('.');
                if (fl.Length > 1)
                {
                    strg += fl[0] + "," + fl[1];
                }
                else
                {
                    strg += fl[0];
                }

                BuyOrders[BuyOrders.Length - num] = float.Parse(strg);
                num++;
            }

        }

        public void Close()
        {
            driver.Quit();
        }
    }
}
