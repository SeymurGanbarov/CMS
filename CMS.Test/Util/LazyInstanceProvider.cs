using CMS.API.Services;
using CMS.BL.BusinessLogic;
using CMS.DAL.Repository;
using System;

namespace CMS.Test
{
    public class LazyInstanceProvider
    {
        public class Group
        {
            private static readonly Lazy<IGroupBusinessLogic> lazyBusinessLogic = new Lazy<IGroupBusinessLogic>(() =>
                new GroupBusinessLogic(new GroupRepository()));

            private static readonly Lazy<GroupServiceFacade> lazy = new Lazy<GroupServiceFacade>(() =>
                new GroupServiceFacade(BusinessLogic));

            public static IGroupBusinessLogic BusinessLogic = lazyBusinessLogic.Value;

            public static GroupServiceFacade Service => lazy.Value;
        }

        public class Customer
        {
            private static readonly Lazy<ICustomerBusinessLogic> lazyBusinessLogic = new Lazy<ICustomerBusinessLogic>(() =>
                new CustomerBusinessLogic(new CustomerRepository()));

            private static readonly Lazy<CustomerServiceFacade> lazy = new Lazy<CustomerServiceFacade>(() =>
                new CustomerServiceFacade(BusinessLogic));

            public static ICustomerBusinessLogic BusinessLogic = lazyBusinessLogic.Value;

            public static CustomerServiceFacade Service => lazy.Value;
        }
    }
}
