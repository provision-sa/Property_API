using Microsoft.EntityFrameworkCore;
using Property_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Property_API.Repository
{
    public interface IPropertyImageRepository : IRepository<PropertyImage>
    {
        List<string> GetImages(int PropertyId);
    }

    public class PropertyImageRepository : IPropertyImageRepository
    {
        private readonly DBContext dBContext;

        public PropertyImageRepository(DBContext _dBContext)
        {
            dBContext = _dBContext;
        }
        public List<PropertyImage> Get(Func<PropertyImage, bool> where)
        {            
            return dBContext.PropertyImages.Where(where).ToList();
        }

        public List<PropertyImage> GetAll()
        {
            return dBContext.PropertyImages.ToList();
        }

        public PropertyImage GetDetailed(Func<PropertyImage, bool> first)
        {
            return dBContext.PropertyImages.FirstOrDefault(first);
        }

        public List<PropertyImage> GetDetailedAll()
        {
            throw new NotImplementedException();
        }        

        public List<string> GetImages(int PropertyId)
        {
            var images = (from p in dBContext.PropertyImages
                          where p.PropertyId == PropertyId
                          select p.Image).ToList();

            return images;
        }

        public void Insert(PropertyImage item)
        {
            dBContext.PropertyImages.Add(item);
            Save();
        }

        public void Insert(IEnumerable<PropertyImage> items)
        {
            foreach(var item in items)
            {
                dBContext.PropertyImages.Add(item);                
            }
            Save();
        }

        public void Remove(PropertyImage item)
        {
            dBContext.PropertyImages.Remove(item);
            Save();
        }

        public void Remove(IEnumerable<PropertyImage> items)
        {
            foreach(var item in items)
            {
                dBContext.PropertyImages.Remove(item);                
            }
            Save();
        }

        public void RemoveAtId(int item)
        {
            var image = Get(x => x.Id == item).FirstOrDefault();
            if (image != null)
            {
                dBContext.PropertyImages.Remove(image);
                Save();
            }
        }

        public void Save()
        {
            dBContext.SaveChanges();
        }

        public void Update(PropertyImage item)
        {
            dBContext.Entry(item).State = EntityState.Modified;
            Save();
        }
    }
}
