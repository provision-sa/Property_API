﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Property_API.Models
{
    public class Property
    {        
        [Key]
        public int Id { get; set; }
        public int PropertyTypeId { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal Price { get; set; }
        public string PricePer { get; set; }
        public bool IsSale { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }


        public virtual PropertyType PropertyType { get; set; }

        public ICollection<PropertyUserField> PropertyUserFields { get; set; }        

        [NotMapped]
        public List<PropertyDetailGroup> DisplayData { get; set; }

        [NotMapped]
        public string DisplayPrice
        {
            get
            {
                return string.Format("R {0}", Price.ToString("N0")); //.Replace(System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator, ""));
            }
        }

        [NotMapped]
        public string DisplayDesc2
        {
            get
            {
                var value = "";

                if (!string.IsNullOrEmpty(AddressLine1))
                    value += AddressLine1 + " ";
                if (!string.IsNullOrEmpty(AddressLine2))
                    value += AddressLine2 + " ";
                if (!string.IsNullOrEmpty(AddressLine3))
                    value += AddressLine3;

                return value.Trim();
            }
        }
    }   

    public class PropertyDetailGroup
    {
        public string GroupName { get; set; }
        public List<PropertyDetail> Values { get; set; }
    }

    public class PropertyDetail
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}