using AutoMapper;
using CMS.API.Models;
using CMS.API.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace CMS.Test
{
    [TestClass]
    public class GroupServiceTest
    {
        private readonly GroupServiceFacade _groupServiceFacade;
        public GroupServiceTest()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<MapperProfile>();
            });
            _groupServiceFacade = LazyInstanceProvider.Group.Service;
        }

        [TestMethod]
        public void CrudTest()
        {
            //GetAll test
            var result = _groupServiceFacade.GetAll();
            Assert.IsTrue(result.IsSucceed);

            var allGroups = result.Data;

            //Create test
            var groupModel = new GroupModel
            {
                Name = "Test entity"
            };
            var createResult = _groupServiceFacade.Create(groupModel);
            Assert.IsTrue(createResult.IsSucceed);

            //Get test
            var group = allGroups.FirstOrDefault(m => m.Name == groupModel.Name);
            Assert.IsNotNull(group);

            var getResult = _groupServiceFacade.Get(group.Id);
            Assert.IsTrue(getResult.IsSucceed);
            Assert.AreEqual(getResult.Data.Name, group.Name);

            //Edit test
            var editModel = new GroupModel
            {
                Id = group.Id,
                Name = "Test for edit"
            };
            var editResult = _groupServiceFacade.Edit(editModel);
            Assert.IsTrue(editResult.IsSucceed);

            //Remove test
            var removeResult = _groupServiceFacade.Remove(editModel.Id);
            Assert.IsTrue(editResult.IsSucceed);


            //Total test
            var res = _groupServiceFacade.Get(editModel.Id).Data;
            Assert.IsNull(res);
        }
    }
}
