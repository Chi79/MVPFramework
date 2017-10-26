﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.FetchDataInterfaces;
using ERP.Common.RepositoryInterfaces;

namespace ERP.Model.FetchDataServices
{
    public class FetchAllCustomerOrders : IFetchCustomerOrderData
    {

        private IUnitOfWork _uOW;

        public FetchAllCustomerOrders(IUnitOfWork uOW)
        {

            _uOW = uOW;

        }

        public string InfoMessage { get { return "Viewing all orders. Please click a row to view the order items."; } }

        public IEnumerable<object> FetchDataForCustomer(string customerEmail)
        {

            var result = _uOW.ORDERs.GetAllOrdersForCustomerByEmail(customerEmail).ToList();

            //return result;

            //var result = _uOW.ORDERs.GetFirstOrderInProductionAndNotCompleted();

            //var result = _uOW.ORDERs.GetFirstOrderNotInProductionAndNotCompleted();

            //var result = _uOW.ORDERs.GetAllItemsFromFirstOrderNotInProductionAndNotCompleted();

            //var result = _uOW.ORDERs.GetAllItemsInProductionButNotCompletedFromFirstOrderInProductionAndNotCompleted();

            //var result = _uOW.ORDERs.GetFirstItemInProductionButNotCompletedFromFirstOrderInProductionAndNotCompletedAsEnumerable();

            //var result = _uOW.ORDERs.GetFirstItemNotInProductionAndNotCompletedFromFirstOrderInProductionAndNotCompletedAsEnumerable();

            //var result = _uOW.ORDERs.GetAllItemsFromFirstOrderNotInProductionAndNotCompleted();

            //var result = _uOW.ORDERs.GetFirstOrderInProductionAndNotCompletedAsEnumerable();

            return result;


            //TODO GET FIRST ITEM NOT IN PRODUCTION FROM ORDER IN PRODUCTION 
            //TODO GET FIRST ITEM IN PRODUCTION BUT NOT COMPLETE FROM ORDER IN PRODUCTION 
            //TODO INSERT ORDERTRACKER ENTRY STATUS CHANGES
            //TODO INSERT ITEMTRACKER ENTRY STATUS CHANGES

        }
    }
}
