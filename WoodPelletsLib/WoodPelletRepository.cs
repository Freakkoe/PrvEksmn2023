using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodPelletsLib
{
    public class WoodPelletRepository
    {
        private int _nextId = 1;
        private readonly List<WoodPellet> _woodPellets = new();

        public WoodPelletRepository()
        {
            _woodPellets.Add(new WoodPellet() { Id = _nextId++, Brand = "BioWood", Price = 4995, Quality = 4});
            _woodPellets.Add(new WoodPellet() { Id = _nextId++, Brand = "BioWoodDeluxe", Price = 5195, Quality = 4 });
            _woodPellets.Add(new WoodPellet() { Id = _nextId++, Brand = "BilligPille", Price = 4125, Quality = 1 });
            _woodPellets.Add(new WoodPellet() { Id = _nextId++, Brand = "GoldenWoodPelletDeluxe", Price = 5995, Quality = 5 });
            _woodPellets.Add(new WoodPellet() { Id = _nextId++, Brand = "GoldenWoodPellet", Price = 5795, Quality = 5 });

        }

        public IEnumerable<WoodPellet> Get(int? priceAfter = null, string? brandIncludes = null, string? orderBy = null)
        {
            IEnumerable<WoodPellet> result = new List<WoodPellet>(_woodPellets);
            if (priceAfter != null)
            {
                result = result.Where(w => w.Price > priceAfter);
            }
            if (brandIncludes != null)
            {
                result = result.Where(w => w.Brand.Contains(brandIncludes));
            }

            if (orderBy != null)
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "brand": // fall through to next case
                    case "brand_asc":
                        result = result.OrderBy(w => w.Brand);
                        break;
                    case "brand_desc":
                        result = result.OrderByDescending(w => w.Brand);
                        break;
                    case "price":
                    case "price_asc":
                        result = result.OrderBy(w => w.Price);
                        break;
                    case "price_desc":
                        result = result.OrderByDescending(b => b.Price);
                        break;
                    default:
                        break; // do nothing
                        throw new ArgumentException("Unknown sort order: " + orderBy);
                }
            }
            return result;
        }

        public List<WoodPellet> GetAll(int id)
        {
            return new List<WoodPellet>(_woodPellets);
            //return _woodPellets; //Outdated metode, anvend den ovenover for at sikre sig at alle kan tilgå listen!
        }
        
        public WoodPellet GetById(int id)
        {
            return _woodPellets.Find(WoodPellet => WoodPellet.Id == id);
        }

        public WoodPellet Add(WoodPellet woodPellet)
        {
            woodPellet.Validate();

            if (woodPellet.Price < 0)
            {
                throw new ArgumentOutOfRangeException("Price", "Price must be a positive number");
            }

            woodPellet.Id = _nextId++;
            _woodPellets.Add(woodPellet);
            return woodPellet;
        }

        public WoodPellet? Update(int id, WoodPellet woodPellet)
        {
            woodPellet.Validate();

            if (woodPellet.Price < 0) 
            {
                throw new ArgumentOutOfRangeException("Price", "Price must be a positive number");
            }

            WoodPellet? existingWoodPellet = GetById(id);
            if (existingWoodPellet == null)
            {
                return null;
            }
            existingWoodPellet.Brand = woodPellet.Brand;
            existingWoodPellet.Price = woodPellet.Price;
            existingWoodPellet.Quality = woodPellet.Quality;
            return existingWoodPellet;
        }
    }
}
