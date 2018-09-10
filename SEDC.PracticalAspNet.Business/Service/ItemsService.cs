﻿using SEDC.PracticalAspNet.Business.Model;
using SEDC.PracticalAspNet.Data.Model;
using SEDC.PracticalAspNet.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PracticalAspNet.Business.Service
{
    public class ItemsService : BaseService<ItemsRepository>, IService<DtoItem>
    {
        public ServiceResult<DtoItem> Add(DtoItem item)
        {
            var categoryExists = Repository
                .DbContext
                .Categories
                .Any(c => c.Id == item.CatgoryId);
            if (!categoryExists)
            {
                return new ServiceResult<DtoItem>
                {
                    Success = false,
                    ErrorMessage = "3404"
                };
            }
            var newItem = new Item
            {
                Id = 0,
                Name = item.Name,
                Availability = item.Availability,
                CategoryId = item.CatgoryId,
                Contents = item.Contents,
                Description = item.Description,
                Price = item.Price
            };
            var result = Repository.Create(newItem);
            return new ServiceResult<DtoItem>()
            {
                Item = new DtoItem(result)
            };
        }

        public ServiceResult<DtoItem> Edit(DtoItem item)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<DtoItem> Load(DtoItem item)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<DtoItem> LoadAll()
        {
            throw new NotImplementedException();
        }

        public ServiceResult<DtoItem> Remove(DtoItem item)
        {
            throw new NotImplementedException();
        }
    }
}
