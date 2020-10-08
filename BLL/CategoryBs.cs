using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryBs
    {
        private Categorydb objDb;

        public CategoryBs()
        {
            objDb = new Categorydb();  
        }

        public IEnumerable<tbl_Category> GetALL()
        {
            return objDb.GetALL();
        }
        public tbl_Category GetbyID(int Id)
        {
            return objDb.GetByID(Id);
        }
        public void Insert(tbl_Category Category)
        {
            objDb.Insert(Category);
        }

        public void Delete(int Id)
        {
            objDb.Delete(Id);
        }

        public void Update(tbl_Category Category)
        {
            objDb.Update(Category);
        }
    }
}
