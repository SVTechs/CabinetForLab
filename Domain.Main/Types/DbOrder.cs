using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Types
{
    public class DbOrder
    {
        public enum OrderTypeEnum
        {
            Asc,
            Desc
        }

        public class OrderInfo
        {
            public OrderTypeEnum OrderType;
            public string OrderField;

            public OrderInfo(OrderTypeEnum orderType, string orderField)
            {
                OrderType = orderType;
                OrderField = orderField;
            }

            public OrderInfo(string orderType, string orderField)
            {
                if (orderType == "ASC")
                {
                    OrderType = OrderTypeEnum.Asc;
                }
                else
                {
                    OrderType = OrderTypeEnum.Desc;
                }
                OrderField = orderField;
            }
        }

        public static List<OrderInfo> GetOrderList(string orderType, string orderField)
        {
            if (string.IsNullOrEmpty(orderType) || string.IsNullOrEmpty(orderField)) return null;
            List<OrderInfo> orderList = new List<OrderInfo>
            {
                new OrderInfo(orderType, orderField)
            };
            return orderList;
        }

        public static List<Order> ToOrderList(List<OrderInfo> infoList)
        {
            if (infoList == null || infoList.Count == 0) return null;
            List<Order> orderList = new List<Order>();
            for (int i = 0; i < infoList.Count; i++)
            {
                Order order;
                if (infoList[i].OrderType == OrderTypeEnum.Asc)
                {
                    order = Order.Asc(infoList[i].OrderField);
                }
                else
                {
                    order = Order.Desc(infoList[i].OrderField);
                }
                orderList.Add(order);
            }
            return orderList;
        }
    }
}