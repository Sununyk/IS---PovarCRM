using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Models;

namespace PovarCRM.Repositories.Interfaces.garbij
{
    internal interface IItemRepository
    {
        IEnumerable<Item> GetItems();
        Item GetcheckItemByID(int checkItemID);
        void InsertCheckItem(Item checkItem);
        void DeleteCheckItem(int checkItemID);
        void UpdateCheckItem(Item checkItem);
        void Save();
    }
}
