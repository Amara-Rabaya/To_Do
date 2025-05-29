using DAL.Data;
using DAL.Interface;
using DAL.ModelsDAL;
using DAL.RepositoryDAL;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trianing_App.BL;
using Trianing_App.ViewModels;

namespace Training_App.Tests
{
    [TestClass]
    public class CityRepositoryDALTests
    {
        [TestMethod]
        public void GivenValidCity_WhenInsertCity_ThenReturnsTrue()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            using var context = new DBContext(options);
            var repo = new CityRepositoryDAL(context);

            var city = new CityDAL
            {
                CityID = 1,
                CityName = "Jenin",
                Population = 100000,
                Governorate = "Jenin",
                Country = "Palestine",
                CityRank = 1
            };

            // Act
            var result = repo.InsertCity(city);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, context.Citys.Count());
        }
        [TestMethod]
       
        public void GivenValidCity_WhenInsertCityWithoutRank_ThenReturnsTrue()
        {
            // Arrange
            var mockRepo = new Mock<ICityRepositoryDAL>();
            var mockLogs = new Mock<ILogsRepositoriesDAL>();

            // أي قيمة تُمرر إلى InsertCity سترجع true
            mockRepo.Setup(r => r.InsertCity(It.IsAny<CityDAL>())).Returns(true);

            var service = new CityBLService(mockRepo.Object, mockLogs.Object);

            var input = new CityInputModel
            {
                CityID = 1,
                CityName = "Jenin",
                Population = 100000, 
                Governorate = "Jenin",
                Country = "Palestine"
            };

            // Act
            var result = service.InsertCity(input);

            // Assert
            Assert.IsTrue(result);

           
            mockRepo.Verify(r => r.InsertCity(It.IsAny<CityDAL>()), Times.Once);

            mockLogs.Verify(l => l.AddLog(It.Is<string>(s => s.Contains("Created Successfully"))), Times.Once);
        }



        [TestMethod]
            public void GivenExistingCity_WhenDeleteCity_ThenReturnsTrueAndRemovesCity()
            {
                // Arrange
                var options = new DbContextOptionsBuilder<DBContext>()
                    .UseInMemoryDatabase(databaseName: "TestDB_Delete") // اسم مختلف لتكون قاعدة منفصلة
                    .Options;

                using var context = new DBContext(options);

                // أضف مدينة للاختبار
                var city = new CityDAL
                {
                    CityID = 1,
                    CityName = "Jenin",
                    Population = 100000,
                    Governorate = "Jenin",
                    Country = "Palestine",
                    CityRank = 1
                };

                context.Citys.Add(city);
                context.SaveChanges();

                var repo = new CityRepositoryDAL(context);

                // Act
                var result = repo.DeleteCity(1);

                // Assert
                Assert.IsTrue(result);  // تحقق أن الحذف نجح
                Assert.AreEqual(0, context.Citys.Count()); // تأكد أن المدينة لم تعد موجودة
            }
        }
    }

