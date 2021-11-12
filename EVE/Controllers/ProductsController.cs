using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EVE.Data;
using EVE.Models;
using System.IO;
using TweetSharp;
using Microsoft.AspNetCore.Authorization;

namespace EVE.Controllers
{
    public class ProductsController : Controller
    {
        private readonly EVEContext _context;
        private string key;
        private string secret;
        private string token;
        private string tokenSecret;

        public ProductsController(EVEContext context)
        {
            _context = context;
            key = "fN5m70wwnh1q28jNUlB0u3mVS";
            secret = "0iTut7xdPEdGAd8kgOS4joe4C2kc8TOEcMAF8ksRtvJizS6SFI";
            token = "1458295109842309120-74SAtZaKBMD91fYmSH4HeCfwIPHL0X";
            tokenSecret = "59bIGSheKID3VJKRgQI3pRgGBnhcSN5cqrwRDAQtQNkeL";
        }



        // GET: Products
        public async Task<IActionResult> Index()
        {
            var eVEContext = _context.Product.Include(p => p.ProductType);
            return View(await eVEContext.ToListAsync());
        }

        public async Task<IActionResult> Search(string title)
        {
            var q = _context.Product.Where(p => p.ProductName.Contains(title) || p.Description.Contains(title));

            return View("Index", await q.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,ProductName,ProductTypeId,Description,Stock,Price,FrontImage,BackImage")] Product product)
        {
            if (ModelState.IsValid)
            {
                // Insert the string of the images into the parameters
                if (product.FrontImage != null)
                {
                    using (MemoryStream ms1 = new MemoryStream())
                    {
                        product.FrontImage.CopyTo(ms1);
                        product.Image1 = ms1.ToArray();
                    }
                }
                if (product.BackImage != null)
                {
                    using (MemoryStream ms2 = new MemoryStream())
                    {
                        product.BackImage.CopyTo(ms2);
                        product.Image2 = ms2.ToArray();
                    }
                }

                _context.Add(product);
                await _context.SaveChangesAsync();

                ViewData["ProductTypeId"] = new SelectList(_context.Set<ProductType>(), "Id", "Name", product.ProductTypeId);
                var service = new TweetSharp.TwitterService(key, secret);
                service.AuthenticateWith(token, tokenSecret);
                TwitterUser twitteruser = service.VerifyCredentials(new VerifyCredentialsOptions());
                var tempproduct = await _context.Product.FirstOrDefaultAsync(p => p.ProductID == product.ProductID);
                string tweetmsg = string.Format("Come to see our new {0} only for {1}₪", tempproduct.ProductName,
                    tempproduct.Price);
                service.SendTweet(new SendTweetOptions { Status = tweetmsg });



                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "Id", "Name", product.ProductTypeId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,ProductTypeId,Description,Stock,Price,FrontImage,BackImage")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Insert the string of the images into the parameters
                if (product.FrontImage != null)
                {
                    using (MemoryStream ms1 = new MemoryStream())
                    {
                        product.FrontImage.CopyTo(ms1);
                        product.Image1 = ms1.ToArray();
                    }
                }


                if (product.BackImage != null)
                {
                    using (MemoryStream ms2 = new MemoryStream())
                    {
                        product.BackImage.CopyTo(ms2);
                        product.Image2 = ms2.ToArray();
                    }
                }

                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "Id", "Name", product.ProductTypeId);
            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductID == id);
        }
    }
}
