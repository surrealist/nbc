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
using NBC.Facts.Fakes;

namespace NBC.Facts.Services
{
    public class YearServiceFacts
    {
        public class AddMethod
        {
            //ตัวอย่าง mock
            //[Fact]
            //public void CanAddAYear()
            //{
            //    var m = new Mock<IRepository<Year>>();
            //    //m.Setup(x => x.Add(It.IsAny<Year>()));

            //    var s = new YearService(m.Object);
            //    var y = new Year();
            //    y.Id = 2555;
            //    y.Name = "2555";

            //    s.Add(y);

            //    m.Verify(x => x.Add(y), Times.Once);
            //    m.Verify(x => x.SaveChanges(), Times.Once);
            //}

            [Fact]
            public void CanAddAYear()
            {
                //Arrange
                var m = new YearService(new FakeRepository<Year>());        

                var y = new Year();
                y.Id = 2555;
                y.Name = "ปีงบประมาณ 2555";

                //Act
                var ret =  m.Add(y);

                //Assert
                var x = m.All();
                Assert.NotNull(x);
                Assert.Equal(2555, ret.Id);
                Assert.Equal("ปีงบประมาณ 2555",ret.Name);
                Assert.Equal(1, x.Count());
            }
            [Fact]
            public void CanAdd2Year()
            {
                //Arrange
                var m = new YearService(new FakeRepository<Year>());

                var y = new Year();
                y.Id = 2555;
                y.Name = "ปีงบประมาณ 2555";

                var y2 = new Year();
                y2.Id = 2556;
                y2.Name = "ปีงบประมาณ 2556";

                //Act
                var ret = m.Add(y);
                var ret2 = m.Add(y2);

                //Assert
                var x = m.All();
                Assert.Equal(2, x.Count());
            }
            [Fact]
            public void CannotAddDupYear()
            {
                //Arrange
                var m = new YearService(new FakeRepository<Year>());

                var y = new Year();
                y.Id = 2555;
                y.Name = "ปีงบประมาณ 2555";

                var y2 = new Year();
                y2.Id = 2555;
                y2.Name = "ปีงบประมาณ 2555";

                //Act
                var ret = m.Add(y);

                var ex = Assert.Throws<Exception>(() =>
                {
                    var ret2 = m.Add(y2);
                });
                Assert.Equal("Already exist.", ex.Message);
            }
         
            [Fact]
            public void CannotDelteYearHasSVTarget()
            {
                //Arrange
                var yearService = new YearService(new FakeRepository<Year>());
                var svService = new SVService(new FakeRepository<SV>());
                var svActityYearService = new SVActivityYearService(new FakeRepository<SVActivityYear>());
                var ActivityTypeService = new ActivityTypeService(new FakeRepository<ActivityType>());

                var y = new Year();
                y.Id = 2559;
                y.Name = "ปีงบประมาณ 2559";
               yearService.Add(y);

                var sv = new SV();
                sv.Name = "ศภ.1";
                svService.Add(sv);

                var incu = new ActivityType();
                incu.Id = "INCU";
                incu.Name = "กิจกรรมบ่มเพาะ";
               ActivityTypeService.Add(incu);           

                var svTarget = new SVActivityYear();
                svTarget.SV = sv;
                svTarget.ActitivityType = incu;
                svTarget.Target = 10;
                svTarget.Year = y;
                svActityYearService.Add(svTarget);


                //Act
                yearService.Remove(y);                

                //Assert  
                var x = yearService.All();
                Assert.Equal(1, x.Count());
            }
        }
    }
}
