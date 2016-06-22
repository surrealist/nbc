using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBC.DataAccess;
using NBC.Models;
using NBC.Services;
using Should;
using Xunit;
using Xunit.Abstractions;
using NBC.DataAccess.Repositories;
using NBC.DataAccess.Contexts;
using Moq;
using NBC.DataAccess.Bases;

namespace NBC.Facts.Services
{
    public class YearServiceFacts
    {
        public class AddMethod
        {
            [Fact]
            public void CanAddAYear()
            {
                var m = new Mock<IRepository<Year>>();
                //m.Setup(x => x.Add(It.IsAny<Year>()));

                var s = new YearService(m.Object);
                var y = new Year();
                y.Id = 2555;
                y.Name = "2555";

                s.Add(y);

                m.Verify(x => x.Add(y), Times.Once);
                m.Verify(x => x.SaveChanges(), Times.Once);
            }
 
        }
    }

    //    public class SharedService
    //    {
    //        public YearService YearService { get; set; }        
    //        public YearRepository Db { get; set; }
    //        public SharedService()
    //        {
    //            Db = new YearRepository(new NBC.DataAccess.Contexts.FakeAppDbContext());
    //            YearService = new YearService(Db);
    //        }
    //    }

    //    [CollectionDefinition("collection1")]
    //    public class YearServiceFactCollection : ICollectionFixture<SharedService>
    //    {
    //        //
    //    }
    //    public class YearServiceFacts
    //    {        
    //        [Collection("collection1")]      
    //        public class AddYearMethod
    //        {

    //            private YearService s;
    //            private YearRepository db;
    //            private ITestOutputHelper output;

    //            public AddYearMethod(ITestOutputHelper output, SharedService service)
    //            {
    //                this.output = output;
    //                s = service.YearService;
    //                db = service.Db;

    //                output.WriteLine("ctor");
    //            }

    //            [Fact]
    //            public void AddYear()
    //            {
    //                var mock = new Mock<YearRepository>();

    //                // mock.Setup(db => db.Add(It.IsAny<Year>())).Returns((Year year) => year);

    //                YearRepository Db = new YearRepository(new NBC.DataAccess.Contexts.AppDbContext());
    //                YearService YearService = new YearService(Db);

    //                output.WriteLine("AddYear");
    //                var c = new Year();
    //                c.Id = 2560;
    //                c.Name = "ปีงบประมาณ 2560";                
    //                YearService.Add(c);

    //                //Assert
    //                Assert.Equal(true, true);             
    //            }
    //        }
    //    }
}
