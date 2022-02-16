﻿using BlazorFurnitureStoreCourse.Shared;

namespace BlazorFurnitureStoreCourse.Repositories
{
    public interface IOrderRepository
    {
        Task<bool> InsertOrder(Order order);
    }
}