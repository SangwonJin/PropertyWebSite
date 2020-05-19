using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcRES2019.Models
{
    public class REContext: DbContext
    {
        

        public System.Data.Entity.DbSet<mvcRES2019.Models.Agent> Agents { get; set; }
        public System.Data.Entity.DbSet<mvcRES2019.Models.Customer> Customers { get; set; }
        public System.Data.Entity.DbSet<mvcRES2019.Models.Contract> Contracts { get; set; }
        //public System.Data.Entity.DbSet<mvcRES2019.Models.List> Lists { get; set; }
        public System.Data.Entity.DbSet<mvcRES2019.Models.Image> Images { get; set; }
        //public System.Data.Entity.DbSet<mvcRES2019.Models.City> Cities { get; set; }
        //public System.Data.Entity.DbSet<mvcRES2019.Models.Province> Provinces { get; set; }
        //public System.Data.Entity.DbSet<mvcRES2019.Models.Country> Countries { get; set; }

    }
}