using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using products_service.Models;

namespace products_service.Repositories
{
  public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
  {
    protected ProductsContext productsContext { get; set; }

    public RepositoryBase(ProductsContext productsContext)
    {
      this.productsContext = productsContext;
    }

    public IEnumerable<T> FindAll()
    {
      return this.productsContext.Set<T>().ToList();
    }

    public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
      return this.productsContext.Set<T>().Where(expression).AsNoTracking();
    }

    public void Create(T entity)
    {
      this.productsContext.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
      this.productsContext.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
      this.productsContext.Set<T>().Remove(entity);
    }
  }
}