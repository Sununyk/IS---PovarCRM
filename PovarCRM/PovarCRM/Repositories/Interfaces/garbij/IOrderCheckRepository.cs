using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Models;

namespace PovarCRM.Repositories.Interfaces.garbij
{
    internal interface IOrderCheckRepository
    {
        IEnumerable<OrderCheck> GetOrderChecks();
        OrderCheck GetOrderCheckByID(int orderCheckId);
        void InsertOrderCheck(OrderCheck student);
        void DeleteOrderCheck(int studentID);
        void UpdateOrderCheck(OrderCheck student);
        void Save();
    }
}
