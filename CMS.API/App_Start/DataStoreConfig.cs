using CMS.DAL.DAO;
using CMS.DAL.Repository;
using System.Collections.Generic;

namespace CMS.API.App_Start
{
    public static class DataStoreConfig
    {
        private readonly static IGroupRepository _groupRepository;

        static DataStoreConfig()
        {
            _groupRepository = new GroupRepository();
        }

        public static void Initialize()
        {
            AddGroups();
        }

        private static void AddGroups()
        {
            var paymentTypes = new List<GroupDAO>
            {
                new GroupDAO
                {
                    Name="Gold",
                },
                 new GroupDAO
                {
                    Name= "Silver",
                },
                 new GroupDAO
                 {
                    Name= "Platinum",
                 }
            };
            foreach (var item in paymentTypes)
            {
                _groupRepository.Save(item);
            }
        }
    }
}