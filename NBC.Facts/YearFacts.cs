using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBC.Models;
using NBC.Services;
using Xunit;
using Should;
using NBC.DataAccess.Repositories;

namespace NBC.Facts
{
    public class YearFacts
    {
        public class General
        {

            //[Fact]
            //public void NewYear()
            //{

            //    var Db = new YearRepository(new NBC.DataAccess.Contexts.FakeAppDbContext());
            //    var YearService = new YearService(Db);

            //    var c = new Year();

            //    c.Id = 2558;
            //    c.Name = "ปีงบประมาณ 2558";
            //    Assert.NotNull(YearService.Add(c));

            //    int key1 = 2558;
            //    Year thisYear =  YearService.Query(x => x.Id == key1).SingleOrDefault();
            //    bool isNull = false;
            //    if (thisYear == null)
            //        isNull = true;
                
            //    Assert.Equal(false, isNull);
            //}

        }
    }
}


