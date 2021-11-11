using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EVE.Data;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using System.Net;
using System.Xml.Linq;
using System.Web.Helpers;

namespace EVE.Controllers
{
    public class Location
    {
        [JsonProperty("lat")]
        public string lat;
        [JsonProperty("lng")]
        public string lng;
        [JsonProperty("address")]
        public string address;

        public Location(string lat, string lng,string address)
        {
            this.lat = lat;
            this.lng = lng;
            this.address = address;
        }
    }
    public class StoresController : Controller
    {
        private readonly EVEContext _context;
        private readonly HttpClient client;
        private List<Location> storesLocation;

        public StoresController(EVEContext context)
        {
            _context = context;
            storesLocation = new List<Location>();
        }


        private void GetStoreCoor(string street, string city, string countrey, string housenumber)
        {

            string address = street + "," + housenumber + "," + city + "," + countrey;
            string address2 = street + " " + housenumber + " " + city + " " + countrey;
            string apiKey = "AIzaSyDVuiJ4kCTsVZkbihbJOhBO2Cm0qFAssJw";
            string requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key={1}&address={0}&sensor=false", Uri.EscapeDataString(address), apiKey);

            WebRequest request = WebRequest.Create(requestUri);
            WebResponse response = request.GetResponse();
            XDocument xdoc = XDocument.Load(response.GetResponseStream());

            XElement result = xdoc.Element("GeocodeResponse").Element("result");
            XElement locationElement = result.Element("geometry").Element("location");
            XElement lat = locationElement.Element("lat");
            XElement lng = locationElement.Element("lng");
            storesLocation.Add(new Location(lat.Value, lng.Value, address2));
      



        }
        // GET: Stores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stores.ToListAsync());
        }

        // GET: Stores/Stores
        public async Task<IActionResult> Stores()
        {
            foreach (Stores store in _context.Stores.ToList())
            {
                GetStoreCoor(store.street, store.city, store.countrey, store.houseNumber);
            
            }
            ViewBag.storesLocation = storesLocation.ToArray();
            ViewBag.storesaddress = _context.Stores.ToList();

            return View(await _context.Stores.ToListAsync());
        }

        // GET: Stores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stores = await _context.Stores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stores == null)
            {
                return NotFound();
            }

            return View(stores);
        }

        // GET: Stores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,countrey,city,street,houseNumber")] Stores stores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stores);
        }

        // GET: Stores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stores = await _context.Stores.FindAsync(id);
            if (stores == null)
            {
                return NotFound();
            }
            return View(stores);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,countrey,city,street,houseNumber")] Stores stores)
        {
            if (id != stores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoresExists(stores.Id))
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
            return View(stores);
        }

        // GET: Stores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stores = await _context.Stores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stores == null)
            {
                return NotFound();
            }

            return View(stores);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stores = await _context.Stores.FindAsync(id);
            _context.Stores.Remove(stores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoresExists(int id)
        {
            return _context.Stores.Any(e => e.Id == id);
        }
    }
}
