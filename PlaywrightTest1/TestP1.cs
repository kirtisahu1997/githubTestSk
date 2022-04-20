using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
// Edit By Kirti Sahu

namespace PlaywrightTest1
{
    [TestFixture]
    class TestP1
    {
        [Test]
        public async Task Launch()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            { Headless = false });
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://en.wikipedia.org/wiki/Login");
            Thread.Sleep(2000);

            // Title
            var title = await page.TitleAsync();
            Console.WriteLine(title);

            // click
            await page.ClickAsync("#pt-login > a");
            Thread.Sleep(2000);

            // Type
            await page.TypeAsync("#wpName1", "some@account");
            await page.TypeAsync("#wpPassword1", "account123");
            Thread.Sleep(3000);
              
            // Hover
            await page.HoverAsync("#wpLoginAttempt");
            Thread.Sleep(3000);
             
            await page.ClickAsync("#wpLoginAttempt");
            Thread.Sleep(3000);

            await page.TypeAsync("#searchInput","playwright" );
            await page.ClickAsync("#searchButton");
            Thread.Sleep(4000);
            
            Thread.Sleep(3000);

            await page.CloseAsync();
        }
    }
}
