using PovarCRM.Models;
using PovarCRM.Repositories;
using PovarCRM.Repositories.Abstracts;
using PovarCRM.Repositories.Interfaces;

public class UnitOfWork : IDisposable
{
    private PovarDbContext db;
    public UnitOfWork()
    {
        db = new PovarDbContext();
    }

    private DishProductRepository? dishProductRepository;
    private OrderCheckRepository? orderCheckRepository;
    private DishRepository? dishRepository;
    private ItemRepository? itemRepository;

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

        throw new NotSupportedException($"No repository found for type {typeof(T).Name}");
    }
}
