using System;
using System.Linq.Expressions;
using Core.Entities.OrderAggregate;

namespace Core.Specifications
{
    public class OrdersWithItemsAndOrderingSpecification : BaseSpecification<Order>
    {
        public OrdersWithItemsAndOrderingSpecification(string email) : base(o => o.BuyerEmail == email)
        {

            AddIclude(o => o.OrderItems);
            AddIclude(o => o.DeliveryMethod);
            AddOrderByDescending(o => o.OrderDate);
        }

        public OrdersWithItemsAndOrderingSpecification(int id, string email) : base(o => o.ID == id && o.BuyerEmail == email)
        {

            AddIclude(o => o.OrderItems);
            AddIclude(o => o.DeliveryMethod);
        }
    }
}