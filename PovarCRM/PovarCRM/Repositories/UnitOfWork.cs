using Microsoft.EntityFrameworkCore;
using PovarCRM.Models;
using PovarCRM.Repositories;
using PovarCRM.Repositories.Abstracts;
using PovarCRM.Repositories.Interfaces;
using PovarCRM.Repositories.Interfaces.garbij;

public class UnitOfWork : IDisposable
{
    private PovarDbContext db;
    public UnitOfWork()
    {
        db = new PovarDbContext();
    }
    public UnitOfWork(PovarDbContext.DbMode mode)
    {
        //if (mode == PovarDbContext.DbMode.DataBaseOff)
        //{
        //    var options = new DbContextOptionsBuilder<PovarDbContext>()
        //        .UseInMemoryDatabase("TempDatabase") // имя временной базы
        //        .Options;
        //    db = new PovarDbContext(options, mode);
        //}
        //else
        db = new PovarDbContext();
    }
    public void CopyReps(UnitOfWork anotherUnit)
    {

        this.InitRepositoryes();
        dishRepository.AddRange(anotherUnit.Dishes.GetCollection());
        dishTypeRepository.AddRange(anotherUnit.DishTypes.GetCollection());
        itemRepository.AddRange(anotherUnit.Items.GetCollection());
        orderCheckRepository.AddRange(anotherUnit.OrderChecks.GetCollection());
        recipeRepository.AddRange(anotherUnit.Recipes.GetCollection());
        unitRepository.AddRange(anotherUnit.Units.GetCollection());
        dishProductRepository.AddRange(anotherUnit.DishProducts.GetCollection());
    }

    private DishProductRepository? dishProductRepository;
    private OrderCheckRepository? orderCheckRepository;
    private DishRepository? dishRepository;
    private ItemRepository? itemRepository;
    private RecipeRepository? recipeRepository;
    private UnitRepository? unitRepository;
    private DishTypeRepository? dishTypeRepository;

    public DishTypeRepository DishTypes
    {
        get
        {
            if (dishTypeRepository == null)
                dishTypeRepository = new DishTypeRepository(db);
            return dishTypeRepository;
        }
    }
    public UnitRepository Units
    {
        get
        {
            if (unitRepository == null)
                unitRepository = new UnitRepository(db);
            return unitRepository;
        }
    }
    public RecipeRepository Recipes{
        get
        {
            if (recipeRepository == null)
                recipeRepository = new RecipeRepository(db);
            return recipeRepository;
        }
    }
    public DishProductRepository DishProducts
    {
        get
        {
            if (dishProductRepository == null)
                dishProductRepository = new DishProductRepository(db);
            return dishProductRepository;
        }
    }

    public OrderCheckRepository OrderChecks
    {
        get
        {
            if (orderCheckRepository == null)
                orderCheckRepository = new OrderCheckRepository(db);
            return orderCheckRepository;
        }
    }

    public DishRepository Dishes
    {
        get
        {
            if (dishRepository == null)
                dishRepository = new DishRepository(db);
            return dishRepository;
        }
    }

    public ItemRepository Items
    {
        get
        {
            if (itemRepository == null)
                itemRepository = new ItemRepository(db);
            return itemRepository;
        }
    }

    public void Save()
    {
        db.SaveChanges();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                db.Dispose();
            }
            this.disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    public void Clear()
    {
        
    }
    public void InitRepositoryes()
    {
        if (dishTypeRepository == null)
            dishTypeRepository = new DishTypeRepository(db);
        if (unitRepository == null)
            unitRepository = new UnitRepository(db);
        if (recipeRepository == null)
            recipeRepository = new RecipeRepository(db);
        if (dishProductRepository == null)
            dishProductRepository = new DishProductRepository(db);
        if (orderCheckRepository == null)
            orderCheckRepository = new OrderCheckRepository(db);
        if (dishRepository == null)
            dishRepository = new DishRepository(db);
        if (itemRepository == null)
            itemRepository = new ItemRepository(db);
    }
    public IRepository<T> GetRepository<T>() where T : class
    {
        if (typeof(T) == typeof(Dish))
            return (IRepository<T>)this.Dishes;
        else if (typeof(T) == typeof(Item))
            return (IRepository<T>)this.Items;
        else if (typeof(T) == typeof(OrderCheck))
            return (IRepository<T>)this.OrderChecks;
        else if (typeof(T) == typeof(DishProduct))
            return (IRepository<T>)this.DishProducts;
        else if (typeof(T) == typeof(Unit))
            return (IRepository<T>)this.Units;

            throw new NotSupportedException($"No repository found for type {typeof(T).Name}");
    }

    
}
