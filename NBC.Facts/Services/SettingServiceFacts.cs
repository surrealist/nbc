using NBC.Facts.Fakes;
using NBC.Models;
using NBC.Services;
using Xunit;

namespace NBC.Facts.Services
{
    public class SettingServiceFacts
    {

        public class General
        {

            [Fact]
            public void EnsureGetDefaultSetting_HasSetting()
            {
                // arrange
                var s = new SettingService(new FakeRepository<Setting>());
                var def = new Setting();
                def.Profile = "DEFAULT";
                s.Add(def);

                // act
                var setting = s.Current;

                // assert
                Assert.NotNull(setting);
                Assert.Equal("DEFAULT", setting.Profile);
            }

            [Fact]
            public void EnsureGetDefaultSetting_NoSetting()
            {
                var s = new SettingService(new FakeRepository<Setting>());

                var setting = s.Current;

                Assert.NotNull(setting);
                Assert.Equal("DEFAULT", setting.Profile);
            }


        }
    }
}