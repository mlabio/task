using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Project.DAL.Models
{
    public class Product
    { 
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }

    public class ProductResponse : Product
    {
        public string CategoryName { get; set; }
    }
}
