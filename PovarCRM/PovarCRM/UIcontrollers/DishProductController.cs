using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using PovarCRM.Models;
using PovarCRM.Models.Views;
using PovarCRM.Repositories;
using PovarCRM.UIcontrollers.UImembers;
using PovarCRM.UIelements;

namespace PovarCRM.UIcontrollers
{
    public class DishProductController : IUpdateMember
    {
        BindingListEx<DishProductView> dishViewProducts;
        BindingListEx<Unit> units;

        public DishProductController()
        {
            dishViewProducts = new BindingListEx<DishProductView>(true);
            units = new BindingListEx<Unit>();
            FillLists();
        }
        public void FillLists() {
            using (var unit = new UnitOfWork())
            {
                dishViewProducts.Clear();
                units.Clear();

                dishViewProducts.AppendList(
                    DataExtractor.GetDishViewProduct(unit)
                 );
                units.AppendList(unit.Units.GetCollection().ToList());
                unit.Save();
            }
        }
        public BindingListEx<Unit> GetUnits()
        {
            return units;
        }
        public BindingListEx<DishProductView> GetDishViewProducts()
        {
            return dishViewProducts;
        }
        public void SaveDataChanging()
        {

            if (units != null && dishViewProducts != null)
            {
                if (DataExtractor.Sync<Unit>.SyncRepositoryes(this.units.ToList()) == null ||
                   DataExtractor.Sync<DishProduct>.SyncRepositoryes(this.dishViewProducts.Select(dv => dv.ToDishProduct()).ToList()) == null)
                {
                    MessageBox.Show("Cant synchronize. It may be deleting");
                }
                FillLists();
                //unit.DishProducts.Clear();
                //unit.Units.Clear();
                //unit.Units.AddRange(this.units);
                //unit.DishProducts.AddRange(this.dishViewProducts.Select(dv => dv.ToDishProduct()).ToList());

            }
        }
        public void onUpdateState()
        {
            this.SaveDataChanging();
        }
    }

}
