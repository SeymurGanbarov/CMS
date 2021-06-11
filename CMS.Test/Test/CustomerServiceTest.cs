using AutoMapper;
using CMS.API.Models;
using CMS.API.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace CMS.Test
{
    [TestClass]
    public class CustomerServiceTest
    {
        private readonly CustomerServiceFacade _customerServiceFacade;
        public CustomerServiceTest()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<MapperProfile>();
            });
            _customerServiceFacade = LazyInstanceProvider.Customer.Service;
        }

        [TestMethod]
        public void CrudTest()
        {
            //GetAll test
            var result = _customerServiceFacade.GetAll();
            Assert.IsTrue(result.IsSucceed);

            var allCustomers = result.Data;

            //Create test
            var customerModel = new CustomerModel
            {
                FirstName = "Test firstname",
                LastName = "Test lastname",
                Age=22,
                Address = "Test address"
            };
            var createResult = _customerServiceFacade.Create(customerModel);
            Assert.IsTrue(createResult.IsSucceed);

            //Get test
            var customer = allCustomers.FirstOrDefault(m => m.FirstName == customerModel.FirstName);
            Assert.IsNotNull(customer);

            var getResult = _customerServiceFacade.Get(customer.Id);
            Assert.IsTrue(getResult.IsSucceed);
            Assert.AreEqual(getResult.Data.FirstName, customer.FirstName);

            //Edit test
            var editModel = new CustomerModel
            {
                Id = customer.Id,
                FirstName = "Test edit firstname",
                LastName = "Test edit lastname",
                Age = 24,
                Address = "Test edit address"
            };
            var editResult = _customerServiceFacade.Edit(editModel);
            Assert.IsTrue(editResult.IsSucceed);

            //Remove test
            var removeResult = _customerServiceFacade.Remove(editModel.Id);
            Assert.IsTrue(editResult.IsSucceed);


            //Total test
            var res = _customerServiceFacade.Get(editModel.Id).Data;
            Assert.IsNull(res);
        }
    }
}
